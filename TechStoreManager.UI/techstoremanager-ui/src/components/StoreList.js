import React, { useState, useEffect } from 'react';
import { Table, Modal, Button, Input, Form } from 'antd';
import StoreService from '../services/storeService';
const StoreList = () => {
    const [store, setStore] = useState([]);
    const storeService = new StoreService();

    useEffect(() => {
        const fetchDevices = async () => {
            const allStore = await storeService.getAllStore();
            setStore(allStore);
        };
        fetchDevices();
    }, []);
    
    console.log(store)

    const columns = [
        {
            title: 'Name',
            dataIndex: 'name',
            key: 'name',
        },
        {
            title: 'Location',
            dataIndex: 'location',
            key: 'location',
        }
    ];
    return (
        <div className="container mt-5">
            <h2>Store List</h2>
            <Table columns={columns} dataSource={store} pagination={true} />
        </div>
    )
};

export default StoreList;