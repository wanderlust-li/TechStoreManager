import axios from 'axios';

const BASE_URL = 'http://localhost:5274/api';

class StoreService {
    async getAllStore() {
        const response = await axios.get(`${BASE_URL}/Store/get-all-store`);
        const devices = response.data;
        return devices;
    }
}

export default StoreService;