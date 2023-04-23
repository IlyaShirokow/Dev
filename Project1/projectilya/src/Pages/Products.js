import React from "react";
import { Link } from 'react-router-dom';
import { Container,Nav,Row,Col, Card, Button } from "react-bootstrap";

export const Products = () => {


        return (
                <>
                <h1>
                    Товары на доставку
                </h1>
               <Nav>
            
                    <Container style={{ paddingTop: '3rem', paddingBottom: '3rem' }}  >
                        <Row>
                            <Col>
                                <Card style={{ width: '18rem' }}>
                                    <Card.Img variant="top" src='https://i.ytimg.com/vi/I_SyG7LVYiQ/maxresdefault.jpg' alt="Xiaomi" />
                                    <Card.Body>
                                        <Card.Title> Сухарики 3 корочки </Card.Title>
                                        <Card.Text>
                                        50 грамм от 100 пачек
                                        </Card.Text>
                                        <Link to="/Form">
                                        <Button variant="primary">
                                            
                                            Добавить в заказ
                                           
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                            <Col>
                                <Card style={{ width: '15rem' }}>
                                    <Card.Img  variant="top" src='http://viewpoint.ru/wp-content/uploads/SMIB-2.jpg' />
                                    <Card.Body>
                                        <Card.Title> Пиво старый мельник </Card.Title>
                                        <Card.Text>
                                        0,5 от 50 банок
                                        </Card.Text>
                                        <Link to="/Form">
                                        <Button variant="primary">
                                        Добавить в заказ
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                            <Col>
                                <Card style={{ width: '10rem' }}>
                                    <Card.Img  variant="top" src='https://ae04.alicdn.com/kf/U7263d0cadf1b4082be026af94da45385i/LAY-S-150.jpeg' />
                                    <Card.Body>
                                        <Card.Title> Чипсы Lays </Card.Title>
                                        <Card.Text>
                                           150 грамм от 80 пачек
                                        </Card.Text>
                                        <Link to="/Form">
                                        <Button variant="primary">               
                                        Добавить в заказ
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                            <Col>
                                <Card style={{ width: '15rem' }}>
                                    <Card.Img  variant="top" src='https://i.artfile.ru/2560x1706_1396361_[www.ArtFile.ru].jpg' />
                                    <Card.Body>
                                        <Card.Title> Кока кола </Card.Title>   
                                        <Card.Text>
                                           0.33 мл от 100 банок
                                        </Card.Text>                                
                                        <Link to="/Form">
                                        <Button variant="primary">               
                                        Добавить в заказ
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                        
                        <Col>
                                <Card style={{ width: '15rem' }}>
                                    <Card.Img  variant="top" src='https://shashlikcentr.ru/wp-content/uploads/2021/04/11766409_1920.jpg' />
                                    <Card.Body>
                                        <Card.Title> Фанта </Card.Title>
                                        <Card.Text>
                                        0.33 мл от 100 банок
                                        </Card.Text>
                                        <Link to="/Form">
                                        <Button variant="primary">               
                                        Добавить в заказ
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                            <Col>
                                <Card style={{ width: '16rem' }}>
                                    <Card.Img  variant="top" src='https://www.ermolino-produkty.ru/picts/products/govyadina-komp.jpg' />
                                    <Card.Body>
                                        <Card.Title> Тушеная говядина </Card.Title>
                                        <Card.Text>
                                        0.5 грамм от 30 банок
                                        </Card.Text>
                                        <Link to="/Form">
                                        <Button variant="primary">               
                                        Добавить в заказ
                                        </Button>
                                        </Link>
                                    </Card.Body>
                                </Card>
                            </Col>
                            </Row>
                    </Container>
                    
               </Nav>

                </>
            
                )
            
            }


        


    

