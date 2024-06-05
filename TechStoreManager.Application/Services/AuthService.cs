using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TechStoreManager.Application.Exceptions;
using TechStoreManager.Application.Identity;
using TechStoreManager.Application.Services.IServices;
using TechStoreManager.Domain.EntityUser;

namespace TechStoreManager.Application.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private string _connectionString;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(IConfiguration configuration, IPasswordHasher<User> passwordHasher)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("DefaultConnection");
        _passwordHasher = passwordHasher;
    }

    public async Task<AuthResponse> LoginAsync(AuthRequest request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var user = await connection.QuerySingleOrDefaultAsync<User>(
                "SELECT Id, Email, PasswordHash FROM AspNetUsers WHERE Email = @Email",
                new { Email = request.Email });

            if (user == null)
                throw new BadRequestException("User is null");

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
                throw new BadRequestException("Incorrect password or email");
            
            var token = GenerateJwtToken(user);
            return new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                Token = token
            };
        }
    }

    public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var existingUser = await connection.QuerySingleOrDefaultAsync<User>(
                "SELECT * FROM AspNetUsers WHERE Email = @Email",
                new { Email = request.Email });

            if (existingUser != null)
                throw new BadRequestException("User already exists with the given email.");

            var newUser = new User
            {
                Id = Guid.NewGuid().ToString(), 
                Email = request.Email,
                UserName = request.Email,
                AccessFailedCount = 0
            };

            newUser.PasswordHash = _passwordHasher.HashPassword(newUser, request.Password);
            
            var insertQuery = @"
        INSERT INTO AspNetUsers (Id, Email, UserName, PasswordHash, AccessFailedCount)
        VALUES (@Id, @Email, @UserName, @PasswordHash, @AccessFailedCount)";
            
            await connection.ExecuteAsync(insertQuery, newUser);

            return new RegistrationResponse { UserId = newUser.Id };
        }
    }


    private string GenerateJwtToken(User user)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["ApiSettings:Secret"]);
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}