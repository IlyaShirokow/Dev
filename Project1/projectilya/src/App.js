import React from "react";
import "./App.css";
import 'bootstrap/dist/css/bootstrap.min.css';
import NaviBar from './Navibar';
import { BrowserRouter } from 'react-router-dom';
import { Routes, Route, Link } from 'react-router-dom';
import Footer from './Footer'

import { Home } from './Pages/Home';
import { Products } from './Pages/Products';
import { Form1 } from './Form1';


function App() {
  return (
    <BrowserRouter>
    <NaviBar/>
      <Routes>

        <Route path="/" element={<Home />} />
        <Route path="/Products" element={<Products />} />
        <Route path="/Form" element={<Form1 />} />
      </Routes>
      <Footer/>

      

    </BrowserRouter>




  );
}

export default App;
