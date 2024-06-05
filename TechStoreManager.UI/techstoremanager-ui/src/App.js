import React, { useState } from 'react';
import DeviceList from './components/DeviceList';
import StoreList from './components/StoreList';
import Login from './components/Login';
import Register from './components/Register'; // Імпортуємо Register
import 'bootstrap/dist/css/bootstrap.min.css';

function App() {
    const [activeTab, setActiveTab] = useState('device');

    const handleTabChange = (tabName) => {
        setActiveTab(tabName);
    };

    return (
        <div className="App">
            <header className="App-header">
                <div className="container">
                    <div className="row">
                        <div className="col-md-12">
                            <ul className="nav nav-tabs justify-content-center">
                                <li className={activeTab === 'device' ? 'nav-item active' : 'nav-item'}>
                                    <button onClick={() => handleTabChange('device')} className="btn btn-secondary btn-outline-dark">Device List</button>
                                </li>
                                <li className={activeTab === 'store' ? 'nav-item active' : 'nav-item'}>
                                    <button onClick={() => handleTabChange('store')} className="btn btn-secondary btn-outline-dark">Store List</button>
                                </li>
                                <li className={activeTab === 'login' ? 'nav-item active' : 'nav-item'}>
                                    <button onClick={() => handleTabChange('login')} className="btn btn-secondary btn-outline-dark">Login</button>
                                </li>
                                <li className={activeTab === 'register' ? 'nav-item active' : 'nav-item'}>
                                    <button onClick={() => handleTabChange('register')} className="btn btn-secondary btn-outline-dark">Register</button>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </header>
            <main>
                {activeTab === 'device' && <DeviceList />}
                {activeTab === 'store' && <StoreList />}
                {activeTab === 'login' && <Login />}
                {activeTab === 'register' && <Register />}
            </main>
        </div>
    );
}

export default App;
