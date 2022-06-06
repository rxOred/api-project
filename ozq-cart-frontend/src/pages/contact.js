import { React, useState } from "react";
import { InputGroup, Container, Form, FormControl, Button } from "react-bootstrap";
import Feedback from "react-bootstrap/esm/Feedback";
import { api } from "../api/api";

const Contact = () => {
    const [email, setEmail] = useState('');
    const [feedback, setFeedback] = useState('');

    const handleEmail = (e) => {
        setEmail(e.target.value)
    }

    const handleFeedback = (e) => {
        setFeedback(e.target.value);
    }

    const handleSubmit = (e) => {
        if (email !== '' && feedback !== '') {
            api.post('/feedbacks', {
                Email:email,
                Feedback: feedback
            })
        }
    }

    return (
        <Container>
            <Container>
                <h3>Contact</h3>
                <p>
                    Feel free to reach us via <br></br><br></br>
                    Telephone 0112200232 <br></br>
                    Whatsapp 0701201201 <br></br>
                    Email ozqshopping@gmail.com <br></br>
                    Twitter @ozqshopping
                </p>
            </Container>
            <Form className="text-left">
                <h3 className="fs-4 mt-4 mb-4 text-left">Feedbacks</h3>
                <Form.Group className="mb-3">
                    <Form.Label>Email</Form.Label>
                    <Form.Control onChange={handleEmail} type="text" size="md" placeholder=" Your email" className="position-relative" autoComplete="username"/>
                </Form.Group>
                <InputGroup className="mb-3">
                    <InputGroup.Text>message</InputGroup.Text>
                    <FormControl onChange={handleFeedback} as="textarea" aria-label="With textarea" />
                </InputGroup>
                <div className="d-grid gap-2">
                    <Button onClick={handleSubmit} variant="outline-dark" size="md">
                        Submit
                    </Button>
                </div>
            </Form>
        </Container>
    );
}

export default Contact;