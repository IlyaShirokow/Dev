import React  from "react";
import Carousel from 'react-bootstrap/Carousel';
import shop1Img from '../assets/gruz1.jpg';
import shop2Img from '../assets/gruz2.jpg';


export default function Footer () {

  return (
    <Carousel>
      <Carousel.Item style={{ 'height': '735px' }}>
        <img
          className="d-block w-180"
          src={shop1Img }
          alt="First slide"
        />
        <Carousel.Caption>
          <h3 style={{color: 'primary'}}> Магазин Nexia</h3>
          <p>
            Лучшая цена на рынке!
          </p>
        </Carousel.Caption>
      </Carousel.Item>
      <Carousel.Item style={{ 'height': '735px' }}>
        <img
          className="d-block w-100"
          src={shop2Img}
          alt="First slide"
        />
        <Carousel.Caption>
        <h3 style={{color: 'primary'}}> Магазин Nexia</h3>
          <p>
          Лучшая цена на рынке!
          </p>
        </Carousel.Caption>
      </Carousel.Item>
    </Carousel>
  )
}

