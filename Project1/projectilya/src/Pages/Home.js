import React  from "react";
import CarouselBox from '../Components/Footer';
import { Link } from 'react-router-dom';
import { Container,Nav,Row,Col, Card, Button } from "react-bootstrap";
import Footer from "../Components/Footer";



export const Home = () => {


    return (
    <>
   <Nav>
     <Footer/>

        <Container style={{ paddingTop: '5rem', paddingBottom: '5rem' }}  >
            <Row>
                <Col>
                    <Card style={{ width: '30rem' }}>
                        <Card.Img variant="top" src='https://ariflowers.com/images/15340780251.jpg' alt="Ps5" />
                        <Card.Body>
                            <Card.Title> Бесплатная доставка </Card.Title>
                            <Card.Text>
                               Подробности уточняйте у менеджера!
                            </Card.Text>
                            <Link to="https://vk.com/public219879108">
                            <Button variant="primary">
                                
                                Обратиться к менеджеру
                               
                            </Button>
                            </Link>
                        </Card.Body>
                    </Card>
                </Col>
                <Col>
                    <Card style={{ width: '28rem' }}>
                        <Card.Img  variant="top" src='https://pbs.twimg.com/media/FVRsaicX0AAg3BB?format=jpg&name=large' />
                        <Card.Body>
                            <Card.Title> Новинки и Акции </Card.Title>
                            <Card.Text>
                                При заказе доставки с оплатой грузчика предоставляем скидку!!!
                                Подробности уточняйте у менеджера!
                            </Card.Text>
                            <Link to="https://vk.com/public219879108">
                            <Button variant="primary">
                            Обратиться к менеджеру
                            </Button>
                            </Link>
                        </Card.Body>
                    </Card>
                </Col>
            </Row>
        </Container>
        <Container style={{ marginBottom: '100px' }}>

            <Row>
                <Col mr={7}>
                    <img src='https://перевозки36.рус/wp-content/uploads/2019/01/52.jpg' height={400} />
                </Col>
                <Col mr={7}>

                    <div>
                    Наша компания по грузоперевозкам оказывает услуги не только в Рязани и Рязанской области. Мы выполняем доставку различных в том числе и длинномерных грузов по всей стране, при этом гарантируем высокое качество и ответственность.Мы не останавливаемся на достигнутом, постоянно предлагая своим клиентам новые услуги, что делает нашу компанию еще более востребованной. При этом совершенствование наблюдается и в сфере общения с клиентами.

Теперь, заказывая наши услуги на длительные переезды, вы получаете хорошего собеседника, с которым вы сможете в деталях обсудить любые нюансы и договориться на дополнительный объем работ, если в этом будет необходимость.

Благодаря постоянной динамике развития и совершенствования своих навыков, мы теперь можем смело выделить следующие преимущества:

Бережное отношение к любому грузу независимо от его вида. Это могут быть хрустальные предметы или высокоточные измерительные приборы с механическими компонентами.
Во время перевозки груза за ним организуется тщательная охрана.
Только мы в городе обеспечиваем такую быструю подачу транспорта. В течение 30 минут автомобиль уже находится на погрузке.
Предлагаем самые низкие расценки на услуги, которые зависят от потраченного времени, габаритов груза и дальности его доставки.


                    </div>

                </Col>
            </Row>
        </Container>
   </Nav>

     
           
    </>

    )

}
       
   



