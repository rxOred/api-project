import React, { useState } from "react";
import { api } from "../api/api";
import { Container, Form, Button, Alert } from "react-bootstrap";
import { useNavigate } from "react-router-dom";

const Register = () => {
    const [username, setUsername] = useState('');
    const [contact, setContact] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const [is_submitted, setSubmitted] = useState(false);
    const [is_error, setError] = useState(false);

    var navigate = useNavigate();

    const handleUsername = (e) => {
        console.debug('username changed ' + e.target.value);
        setUsername(e.target.value);
        setSubmitted(false);
    }

    const handleContact = (e) => {
        console.debug('contact changed ' + e.target.value);
        setContact(e.target.value);
        setSubmitted(false);
    }

    const handleEmail = (e) => {
        console.debug('email changed ' + e.target.value);
        setEmail(e.target.value);
        setSubmitted(false);
    }

    const handlePassword = (e) => {
        console.debug('password changed ' + e.target.value);
        setPassword(e.target.value);
        setSubmitted(false);
    }

    const handleSubmit = (e) => {
        console.debug('submit clicked');
        e.preventDefault();
        if (username === '' || contact === '' || email === '' || password === '') {
            setError(true);
        } else {
            api.post('/register', {
                Username: username,
                Contact: contact,
                Email: email, 
                Password: password
            })
            .then(res => {
                if (res.status === 200) {
                    setSubmitted(true);
                    navigate('/login');
                }
            })
            setError(false);
        }
    }

    // Showing success message
    const successMessage = () => {
        return (
        <div
            className="success"
            style={{
            display: is_submitted ? '' : 'none',
            }}>
            <Alert key="success" variant="success">User {username} successfully registered!!</Alert>
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
            <Alert key="danger" variant="danger">Please enter all the fields</Alert>
        </div>
        );
    };

    return (
        <Container style={{width:'30%'}}>  
            <Form className="text-left">
                <h3 className="fs-4 mt-4 mb-4 text-center">User Registration</h3>
                <Form.Group className="mb-3">
                    <Form.Label>Username</Form.Label>
                    <Form.Control onChange={handleUsername} type="text" size="md" placeholder=" Your username" className="position-relative"/>
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Contact</Form.Label>
                    <Form.Control onChange={handleContact} type="text" size="md" placeholder="Contact number" className="position-relative" />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Email Address</Form.Label>
                    <Form.Control onChange={handleEmail} type="email" size="md" placeholder="Email address" autoComplete="username" className="position-relative" />
                </Form.Group>
                <Form.Group className="mb-3">
                    <Form.Label>Password</Form.Label>
                    <Form.Control onChange={handlePassword} type="password" size="md" placeholder="Password" autoComplete="Current-password" className="position-relative" />
                </Form.Group>
                <div className="mb-3">
                    {errorMessage()}
                    {successMessage()}
                </div>
                <div className="d-grid gap-2">
                    <Button onClick={handleSubmit} variant="outline-dark" size="md">Register</Button>
                </div>
            </Form>                    
        </Container>
    );
}

export default Register;