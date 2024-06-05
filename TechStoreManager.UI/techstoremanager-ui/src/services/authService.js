import axios from 'axios';

const BASE_URL = 'http://localhost:5274';

class AuthService {
    async login(email, password) {
        const url = `${BASE_URL}/Auth/login`;
        const response = await axios.post(url, { email, password });
        const { token } = response.data; 
        localStorage.setItem('token', token); 
        return response.data; 
    }
    async register(email, password) {
        const url = `${BASE_URL}/Auth/register`;
        const response = await axios.post(url, { email, password });
        return response.data;
    }
    getAuthData() {
        const token = localStorage.getItem('token');
        return token ? { token } : null; 
    }
}

export default AuthService;
