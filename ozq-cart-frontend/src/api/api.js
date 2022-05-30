import axios from "axios";
import React, {useState, useEffect} from "react";
import { useNavigate } from 'react-router-dom';

export const api = axios.create({
    baseURL: 'https://localhost:5001'
});
/*
const navigate = useNavigate();
const [should_redirect, setRedirect] = useState(false);

useEffect(() => {
    if (should_redirect === true) {
        navigate('/login');
    }
}, [should_redirect])

api.interceptors.response.use((response) => response, (error) => {
    if (error.response.status === 401) {
        setRedirect(true);
    }
});*/
