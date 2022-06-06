import userEvent from "@testing-library/user-event";
import React, {useEffect, useState} from "react";
import { Container, Figure, ListGroup, Card, Table } from "react-bootstrap";
import { api } from "../api/api";
import {  useNavigate } from 'react-router-dom';
import jwt from "jwt-decode";
import profile from '../assets/img/pp.png';
import { Button } from "bootstrap";

function is_logged() { 
    if (localStorage.getItem('token')) {
        return true;
    }
    return false;
}

const Profile = () => {
    const navigate = useNavigate();
    var name = '';
    var email = '';
    var contact = '';
    const [orderData, setOrderData] = useState([]);
    
    if (!is_logged()) {
        console.log('user not logged');
        navigate("/login");
    }
    else {
        var token = localStorage.getItem('token')
        var userData = jwt(token);
        name = userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname'];
        email = userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
        contact = userData['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone'];
    }
    useEffect(() => {
        if (is_logged()) {
            console.log(token);
            api.get(
                '/orders/user',
                {headers: {"Authorization" : `Bearer ${token}`} }
            )
            .then(res => {
                if (res.status === 200) {
                    setOrderData(res.data);
                    console.log(orderData);
                } else {
                    console.log('errorrrr');
                }
            })
        }
    }, [])

    return (
        <Container responsiv="md">
            <Container>
                <div style={{'float': 'left', 'width': '50%'}}>
                    <Figure>
                        <Figure.Image
                            width={171}
                            height={180}
                            alt="171x180"
                            src={profile}
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
                <Table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>User Id</th>
                            <th>Total</th>
                            <th>Order Date</th>
                        </tr>
                    </thead>
                    <tbody>
                        {orderData.map((data) => (
                            <tr>
                                <td>{data.id}</td>
                                <td>{data.userId}</td>
                                <td>{data.total}</td>
                                <td>{data.orderDate}</td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Container>
        </Container>
    )
}

export default Profile;