import React, { useState } from "react";
import { Navbar, Nav, Button, Container } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css';
import {BrowserRouter as Router,Routes,Route,Link} from "react-router-dom"
import Styled from 'styled-components';


const Styles = Styled.div `
.navbar {
    height: 80px;
}
.navbar-brand{
    margin-left: 1px;
    font-size: 25px;
    text-decoration-line:none;
}
a, .navbar-brand, .navbar-nav, .nav-link, .link{
    color: #b0b7c6;
    text-decoration:none;
    &:hover {
        text-decoration: none;
        color: white;
    }
}
`
export default function Navibar ()  {

    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    return (
        <>
         <Styles>
            <Navbar className='me-auto mb-2 mb-lg-0' collapse0nSelect expand="md" bg="dark" variant="dark" >
                <Container>
                    <Navbar.Brand><Link to="/"> Nexia</Link></Navbar.Brand>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        <Nav className="mr-auto">
                            <Nav.Link href="/" > Главная </Nav.Link>
                            <Nav.Link href="/products" > Товары </Nav.Link>
                        </Nav>
                        
        

                    </Navbar.Collapse>
                </Container>
            </Navbar>
            </Styles>

            
        </>
    )
}
