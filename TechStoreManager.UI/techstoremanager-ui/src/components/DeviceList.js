import React, { useState, useEffect } from 'react';
import { Table, Modal, Button, Input, Form } from 'antd';
import DeviceService from '../services/deviceService';

const DeviceList = () => {
    const [devices, setDevices] = useState([]);
    const [isDeleteModalVisible, setIsDeleteModalVisible] = useState(false);
    const [isCreateModalVisible, setIsCreateModalVisible] = useState(false);
    const [isEditModalVisible, setIsEditModalVisible] = useState(false); // State for edit modal visibility
    const [deviceIdToDelete, setDeviceIdToDelete] = useState(null);
    const [currentDevice, setCurrentDevice] = useState(null); // State for current device being edited
    const deviceService = new DeviceService();

    useEffect(() => {
        const fetchDevices = async () => {
            const allDevices = await deviceService.getAllDevices();
            setDevices(allDevices);
        };
        fetchDevices();
    }, []);

    const columns = [
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Description',
            dataIndex: 'description',
            key: 'description',
        },
        {
            title: 'Price',
            dataIndex: 'price',
            key: 'price',
            render: (price) => `$${price}`,
        },
        {
            title: 'Store',
            dataIndex: 'store.name',
            key: 'store',
            render: (store) => store?.name,
        },
        {
            title: 'Actions',
            key: 'actions',
            render: (device) => (
                <div className="device-actions">
                    <button onClick={() => handleEditDevice(device)} className="btn btn-primary btn-sm">Edit</button>
                    <button onClick={() => {
                        setDeviceIdToDelete(device.id);
                        setIsDeleteModalVisible(true);
                    }} className="btn btn-danger btn-sm">Delete</button>
                </div>
            ),
        },
    ];

    const handleEditDevice = (device) => {
        setCurrentDevice(device);
        setIsEditModalVisible(true);
    };

    const handleDeleteDevice = async () => {
        if (deviceIdToDelete) {
            try {
                await deviceService.deleteDeviceById(deviceIdToDelete);
                const updatedDevices = devices.filter((device) => device.id !== deviceIdToDelete);
                setDevices(updatedDevices);
                setIsDeleteModalVisible(false);
            } catch (error) {
                console.error('Error deleting device:', error);
            }
        }
    };

    const handleCancelDelete = () => {
        setIsDeleteModalVisible(false);
        setDeviceIdToDelete(null);
    };

    const handleCreateDevice = async (values) => {
        try {
            const response = await deviceService.createDevice(values);
            setDevices([...devices, response]); // Assuming response is the new device object
            setIsCreateModalVisible(false);
        } catch (error) {
            console.error('Error creating device:', error);
        }
    };

    const handleEditDeviceSave = async (values) => {
        try {
            await deviceService.updateDeviceById({ ...currentDevice, ...values });
            const updatedDevices = devices.map((device) =>
                device.id === currentDevice.id ? { ...device, ...values } : device
            );
            setDevices(updatedDevices);
            setIsEditModalVisible(false);
        } catch (error) {
            console.error('Error updating device:', error);
        }
    };

    return (
        <div className="container mt-5">
            <h2>Device List</h2>
            <Button type="primary" onClick={() => setIsCreateModalVisible(true)}>Create Device</Button>
            <Table columns={columns} dataSource={devices} pagination={true} />

            <Modal
                title="Create New Device"
                visible={isCreateModalVisible}
                onCancel={() => setIsCreateModalVisible(false)}
                footer={null}
            >
                <Form onFinish={handleCreateDevice}>
                    <Form.Item name="name" rules={[{ required: true, message: 'Please input the device name!' }]}>
                        <Input placeholder="Enter device name" />
                    </Form.Item>
                    <Form.Item name="description" rules={[{ required: true, message: 'Please input the description!' }]}>
                        <Input placeholder="Enter description" />
                    </Form.Item>
                    <Form.Item name="price" rules={[{ required: true, message: 'Please input the price!' }]}>
                        <Input placeholder="Enter price" type="number" />
                    </Form.Item>
                    <Form.Item name="storeId" rules={[{ required: true, message: 'Please input the store!' }]}>
                        <Input placeholder="Enter store" type="number" />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">Submit</Button>
                    </Form.Item>
                </Form>
            </Modal>

            <Modal
                title="Edit Device"
                visible={isEditModalVisible}
                onCancel={() => setIsEditModalVisible(false)}
                footer={null}
            >
                <Form
                    onFinish={handleEditDeviceSave}
                    initialValues={currentDevice}
                >
                    <Form.Item name="name" rules={[{ required: true, message: 'Please input the device name!' }]}>
                        <Input placeholder="Enter device name" />
                    </Form.Item>
                    <Form.Item name="description" rules={[{ required: true, message: 'Please input the description!' }]}>
                        <Input placeholder="Enter description" />
                    </Form.Item>
                    <Form.Item name="price" rules={[{ required: true, message: 'Please input the price!' }]}>
                        <Input placeholder="Enter price" type="number" />
                    </Form.Item>
                    <Form.Item name="storeId" rules={[{ required: true, message: 'Please input the store!' }]}>
                        <Input placeholder="Enter store" type="number" />
                    </Form.Item>
                    <Form.Item>
                        <Button type="primary" htmlType="submit">Save</Button>
                    </Form.Item>
                </Form>
            </Modal>

            <Modal
                title="Confirm Delete Device"
                visible={isDeleteModalVisible}
                onOk={handleDeleteDevice}
                onCancel={handleCancelDelete}
            >
                <p>Are you sure you want to delete this device?</p>
            </Modal>
        </div>
    );
};

export default DeviceList;
