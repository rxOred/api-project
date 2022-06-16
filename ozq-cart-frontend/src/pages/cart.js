import { useEffect, useRef } from "react";
import { Container, FormLabel } from "react-bootstrap";
import { Table, Button } from "react-bootstrap";
import { Link } from "react-router-dom";

const Cart = () => {
    var itemArray = JSON.parse(localStorage.getItem('cart'));
    const checkoutButton = useRef(null);

    const handleClearCart = (e) => {
        var p = itemArray.pop();
        while(p) {
            p = itemArray.pop();
        }
        localStorage.setItem('cart', JSON.stringify(itemArray));
    }

    var total = 0;
    itemArray.map((item) => {
        total += JSON.parse(item).price;
    })

    const is_logged = () => {
        if (localStorage.getItem('token')) {
            return true;
        }
        return false;
    }

    useEffect(() => {
        if (is_logged()) {
            checkoutButton.current.disabled = false;
        } 
    })

    return (
        <Container>
            <h3 className="fs-4 mt-4 mb-4 text-left">Cart</h3>
            <Container responsive="md">
                <Table>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Id</th>
                            <th>Price</th>
                        </tr>
                    </thead>
                    <tbody>
                        {itemArray.map((item) => (
                            <tr>
                                <td>{JSON.parse(item).name}</td>
                                <td>{JSON.parse(item).id}</td>
                                <td>{JSON.parse(item).price}</td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
                <FormLabel>Total USD {total}</FormLabel>
            </Container>
            <Container>
                <div style={{'float': "left"}}>
                <Button ref={checkoutButton} variant="outline-dark" size="md" disabled>
                    <Link to="/checkout">Checkout</Link>
                </Button>{' '}
                <Button onClick={handleClearCart} variant="outline-dark" size="md">
                    Clear cart
                </Button>{' '}
                </div>
            </Container>
        </Container>
    )
}

export default Cart;