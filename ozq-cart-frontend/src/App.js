import React from "react";
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import './index.css'
import MyNavbar from "./components/navbar";
import { BrowserRouter as Router, Routes, Route}
    from 'react-router-dom';
import Home from "./pages";
import About from "./pages/about";
import Contact from "./pages/contact";
import Register from "./pages/register";
import Login from "./pages/login";
import Profile from "./pages/profile";

const App = () => {
    return (
        <Router>
        <MyNavbar />
        <Routes>
            <Route exact path='/' element={<Home />} />
            <Route path='/about' element={<About/>} />
            <Route path='/contact' element={<Contact/>} />
            <Route path='/login' element={<Login/>} />
            <Route path='/register' element={<Register />} />
            <Route path='/profile' element={<Profile />} />
        </Routes>
        </Router>
    );
}

export default App;