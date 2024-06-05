import axios from 'axios';

const BASE_URL = 'http://localhost:5274/api';

class DeviceService {
    async getAllDevices() {
        const response = await axios.get(`${BASE_URL}/Device/get-all-device`);
        const devices = response.data;
        return devices;
    }

    async deleteDeviceById(id) {
        const url = `${BASE_URL}/Device/delete-device-by-id?id=${id}`;
        await axios.delete(url);
    }

    async createDevice(device) {
        const url = `${BASE_URL}/Device/create-device`;
        const response = await axios.post(url, device);
        return response.data;
    }
    async updateDeviceById(device) {
        const url = `${BASE_URL}/Device/update-device-by-id`;
        const response = await axios.put(url, device);
        return response.data;
    }
}

export default DeviceService;
