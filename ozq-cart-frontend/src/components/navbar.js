import React from "react";
import { NavLink } from "react-router-dom";
import { Container, Nav, Navbar } from "react-bootstrap";
import logo from './favicon.ico';
import './navbar.css'

const MyNavbar = () => {
    return (
        <div className="navigation">
            <Navbar bg="myBg" variant="dark" expand="lg">
                <Container fluid>
                    <Navbar.Brand>
                        OZQ
                    </Navbar.Brand>

                    <Navbar.Toggle />
                    <Navbar.Collapse>    
                        <Nav className="me-auto">
                            <Nav.Link href="/">Home</Nav.Link>
                            <Nav.Link href="/contact">Contact</Nav.Link>
                            <Nav.Link href="/about">About</Nav.Link>
                        </Nav>
                        <Nav>
                            <Nav.Link href="/login">Login</Nav.Link>
                        </Nav>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
        </div> 
    );
}

export default MyNavbar;