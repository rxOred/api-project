import userEvent from "@testing-library/user-event";
import React, {useEffect} from "react";
import { Container, Figure, ListGroup, Card, Table } from "react-bootstrap";
import { api } from "../api/api";
import {  useNavigate } from 'react-router-dom';
import jwt from "jwt-decode";
import { Tab } from "bootstrap";

function is_logged() { 
    if (localStorage.getItem('token')) {
        return true;
    }
    return false;
}

const Profile = () => {
    const navigate = useNavigate();

    if (!is_logged()) {
        navigate("/login");
    }

    var token = localStorage.getItem('token')
    var userData = jwt(token);
    var name = userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'];
    var email = userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
    var contact =userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone'];
    console.log(name);
    console.log(email);
    console.log(contact);

    var orderData;
    api.get(
        '/orders/user',
        {headers: {"Authorization" : `Bearer ${token}`} }
    )
    .then(res => {
        if (res.status === 200) {
            orderData = res.data;
        }
    })

    return (
        <Container responsiv="md">
            <Container>
                <div style={{'width': '50%'}}>
                    <Figure>
                        <Figure.Image
                            width={171}
                            height={180}
                            alt="171x180"
                            src="/assets/img/pp.png"
                        />
                        </Figure>
                </div>
                <div style={{'float': 'right', 'width': '50%'}}>
                    <Card style={{ width: '18rem' }}>
                    <Card.Header>Profile</Card.Header>
                    <ListGroup variant="flush">
                        <ListGroup.Item>{name}</ListGroup.Item>
                        <ListGroup.Item>{email}</ListGroup.Item>
                        <ListGroup.Item>{contact}</ListGroup.Item>
                    </ListGroup>
                    </Card>
                </div>
            </Container>
            <Container responsive="md">
            <Table responsive="sm" className="mt-4 mb-4">
                <thead>
                <tr>
                    <th>#</th>
                    <th>Table heading</th>
                    <th>Table heading</th>
                    <th>Table heading</th>
                    <th>Table heading</th>
                    <th>Table heading</th>
                    <th>Table heading</th>
                </tr>
                </thead>
                <tbody>
                <tr>
                    <td>1</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                    <td>Table cell</td>
                </tr>
                </tbody>
            </Table>
            </Container>
        </Container>
    )
}

export default Profile;