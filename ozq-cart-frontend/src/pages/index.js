import { React, useEffect, useState } from 'react';
import { ListGroup, Button, CardGroup, Container, Card, Row, Col, Form, FormControl } from 'react-bootstrap';
import { api } from '../api/api';
import card from '../assets/img/homecard.png'
import cart from '../assets/img/favicon-32x32.png';
import { Link } from 'react-router-dom';

const Home = () => {
    const [items, setItems] = useState([]);
    useEffect(() => {
        api.get(
            '/items'
        )
        .then(res => {
            if (res.status === 200) {
                setItems(res.data);
                console.log(items);
            } else {
                console.log('error');
            }
        })
    }, [])

    const handleAddtoCart = (itemName, itemId, itemPrice ) => {
        var itemArray = [];
        var cartItem = {
            name: itemName,
            id: itemId,
            price: itemPrice
        }
        var cartItemJson = JSON.stringify(cartItem);
        console.log(cartItemJson);
        if (localStorage.getItem('cart')) {
            itemArray = JSON.parse(localStorage.getItem('cart'));
        }
        itemArray.push(cartItemJson);
        localStorage.setItem('cart', JSON.stringify(itemArray));

        console.debug(JSON.stringify(localStorage.getItem('cart')));
    }

    const handleSearch = (e) => {
        for (var i = 0; i < items.length; i++) {
            if (items[i].name === e.target.value || items[i].description === e.target.value) {
                console.log('match');
            }
            else {
                console.log('no match found');
            }
        }
    }

    return (
        <Container>
            <Container className="mb-4" >
                <Link to="/cart">
                    <img
                        src={cart}
                        alt="Your cart"
                    />
                </Link>
                <div style={{'float': 'right', 'width': '30%'}}>
                    <Form className="d-flex">
                        <FormControl
                        onChange={handleSearch}
                        type="search"
                        placeholder="Search"
                        className="me-2"
                        aria-label="Search"
                        />
                        <Button onClick={handleSearch} variant="outline-dark">Search</Button>
                    </Form>
                </div>
            </Container>
            <Container className='mb-4'>
                <CardGroup>
                <Card className="bg-dark text-white">
                    <Card.Img width="100%" height='250px' src={card} alt="Card image" />
                    <Card.ImgOverlay>
                        <Card.Title>OZQ Deals</Card.Title>
                        <Card.Text>
                            In this Christmas season, we offer,<br/><br/>
                            25% off for all children clothes <br/>
                            25% off for all accessories <br/>
                            50% off for decoration items <br/>
                        </Card.Text>
                        <Card.Text>Last updated 3 mins ago</Card.Text>
                    </Card.ImgOverlay>
                </Card>
                </CardGroup>
            </Container>
            <Container>
                <Row xs={1} md={3} className="g-4 mb-5">
                    {items.map((item) => (
                        <Col>
                            <Card>
                                <Card.Img  width="50%" height='250px' variant="top" src={item.image}/>
                                <Card.Body>
                                    <Card.Title>{item.name}</Card.Title>
                                    <ListGroup variant="flush" className="mb-2">
                                        <ListGroup.Item>{item.category}</ListGroup.Item>
                                        <ListGroup.Item>USD {item.price}</ListGroup.Item>
                                        <ListGroup.Item>{item.count} items available</ListGroup.Item>
                                        <ListGroup.Item>{item.description}</ListGroup.Item>
                                    </ListGroup>
                                    <Button onClick={(e) => handleAddtoCart(item.name, item.id, item.price)} variant="outline-dark" size="md">
                                        Add to cart
                                    </Button>
                                </Card.Body>
                            </Card>
                        </Col>
                    ))}
                </Row>
            </Container>
        </Container>
    );
};

export default Home;