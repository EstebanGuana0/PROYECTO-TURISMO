import React, { useContext } from 'react';
import { BrowserRouter as Router, Routes, Route, Link, useNavigate } from 'react-router-dom';
import './App.css';

import Home from './components/Home';
import Catalogo from './components/Catalogo';
import Login from './components/Login';
import LugarDetalle from './components/LugarDetalle';
import Reservas from './components/Reservas';
import VerReservas from './components/VerReservas';  // ⬅️ Importa aquí VerReservas
import { AuthContext } from "./context/AuthContext";

function App() {
    const { username, logout } = useContext(AuthContext);
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate('/login');
    };

    return (
        <div style={{ minHeight: '100vh' }}>
            <nav style={{
                position: 'fixed',
                top: 0,
                left: 0,
                height: '100vh',
                width: '220px',
                background: '#343a40',
                color: 'white',
                padding: '20px',
                display: 'flex',
                flexDirection: 'column',
                justifyContent: 'space-between',
                boxSizing: 'border-box',
                zIndex: 1000
            }}>
                <div>
                    <h2>
                        <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>
                            Turismo Local
                        </Link>
                    </h2>
                    <hr style={{ width: '100%', borderColor: '#555' }} />
                    <Link to="/catalogo" style={{
                        marginTop: '10px',
                        backgroundColor: '#007bff',
                        color: 'white',
                        padding: '10px 15px',
                        textDecoration: 'none',
                        borderRadius: '5px',
                        display: 'inline-block'
                    }}>
                        Catálogo
                    </Link>

                    <Link to="/reservas" style={{
                        marginTop: '10px',
                        backgroundColor: '#17a2b8',
                        color: 'white',
                        padding: '10px 15px',
                        textDecoration: 'none',
                        borderRadius: '5px',
                        display: 'inline-block'
                    }}>
                        Reservas
                    </Link>

                    {/* Nuevo enlace para ver reservas */}
                    <Link to="/ver-reservas" style={{
                        marginTop: '10px',
                        backgroundColor: '#28a745',
                        color: 'white',
                        padding: '10px 15px',
                        textDecoration: 'none',
                        borderRadius: '5px',
                        display: 'inline-block'
                    }}>
                        Ver Reservas
                    </Link>
                </div>

                <div>
                    {username && (
                        <div style={{ fontSize: '14px', color: '#ccc', marginBottom: '10px' }}>
                            Usuario: {username}
                        </div>
                    )}

                    {username ? (
                        <button
                            onClick={handleLogout}
                            style={{
                                backgroundColor: '#dc3545',
                                color: 'white',
                                padding: '10px 15px',
                                border: 'none',
                                borderRadius: '5px',
                                cursor: 'pointer'
                            }}
                        >
                            Cerrar Sesión
                        </button>
                    ) : (
                        <Link to="/login" style={{
                            backgroundColor: '#28a745',
                            color: 'white',
                            padding: '10px 15px',
                            textDecoration: 'none',
                            borderRadius: '5px',
                            display: 'inline-block'
                        }}>
                            Iniciar Sesión
                        </Link>
                    )}
                </div>
            </nav>

            <main style={{ flex: 1, padding: '20px', marginLeft: '220px' }}>
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/catalogo" element={<Catalogo />} />
                    <Route path="/reservas" element={<Reservas />} />
                    <Route path="/ver-reservas" element={<VerReservas />} /> {/* ⬅️ Nueva ruta */}
                    <Route path="/login" element={<Login />} />
                    <Route path="/lugar/:id" element={<LugarDetalle />} />
                </Routes>
            </main>
        </div>
    );
}

export default function AppWrapper() {
    return (
        <Router>
            <App />
        </Router>
    );
}
