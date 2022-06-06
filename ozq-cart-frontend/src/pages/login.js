import axios from "axios";
import React, {useEffect, useState} from "react";
import { Container, Form, Button, Alert } from "react-bootstrap";
import { api } from "../api/api";
import {  useNavigate } from 'react-router-dom';

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [is_logged, setLoggeed] = useState(false);
    const [is_error, setError] = useState(false);

    var navigate = useNavigate();

    const handleUsername = (e) => {
        setUsername(e.target.value);
        setLoggeed(false);
    }

    const handlePassword = (e) => {
        setPassword(e.target.value);
        setLoggeed(false);
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        if (username === '' || password === '') {
            setError(true);
        } else {
            api.post('/login', {
                Username: username, 
                Password: password
            })
            .then(res => {
                if (res.status === 200) {
                    const token = res.data;
                    localStorage.setItem('token', token);
                    setLoggeed(true);
                    setError(false);
                    navigate('/profile')
                } else {
                    setLoggeed(false);
                    setError(true);
                }
            })
        }
    }

    // Showing success message
    const successMessage = () => {
        return (
        <div
            className="success"
            style={{
            display: is_logged ? '' : 'none',
            }}>
            <Alert key="success" variant="success">Login successful</Alert>
        </div>
        );
    };

    // Showing error message if error is true
    const errorMessage = () => {
        return (
        <div
            className="error"
            style={{
            display: is_error ? '' : 'none',
            }}>
            <Alert key="danger" variant="danger">Login failed </Alert>
        </div>
        );
    };

    return (
        <Container style={{width: '30%'}}>
            <Form className="text-left">
                <h3 className="fs-4 mt-4 mb-4 text-center">User Login</h3>
                <Form.Group className="mb-3">
                    <Form.Label>Username</Form.Label>
                    <Form.Control onChange={handleUsername} type="text" size="md" placeholder=" Your username" className="position-relative" autoComplete="username"/>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Password</Form.Label>
                    <Form.Control onChange={handlePassword} type="password" size="md" placeholder="Your password" className="position-relative" autoComplete="current-password"/>
                </Form.Group>
                <div className="mb-3">
                    {errorMessage()}
                    {successMessage()}
                    <Form.Label>New to OZQ? <a href="./register">register here</a></Form.Label> 
                </div> 
                <div className="d-grid gap-2">
                    <Button onClick={handleSubmit} variant="outline-dark" size="md">
                        Login
                    </Button>
                </div>
            </Form>
        </Container>
    );
}

export default Login;