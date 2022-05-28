import React, {useState} from "react";
import { Container, Form, Button, Alert } from "react-bootstrap";
import { Link } from "react-router-dom";

const Login = () => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [is_submitted, setSubmitted] = useState(false);
    const [is_error, setError] = useState(false);

    const handleUsername = (e) => {
        setUsername(e.target.value);
        setSubmitted(false);
    }

    const handlePassword = (e) => {
        setPassword(e.target.value);
        setSubmitted(false);
    }

    
    const handleSubmit = (e) => {
        e.preventDefault();
        if (username === '' || password === '') {
            setError(true);
        } else {
            setSubmitted(true);
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