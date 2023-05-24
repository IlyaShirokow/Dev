import React from "react";
import Styled from 'styled-components';

const Styles = Styled.div`
.col-md-6{
    width: 40%;
}
`

const Footer = () => (
    <div className="footer">
        <Styles>
            <footer fluid style={{ backgroundColor: '#282828', color: '#b0b7c6', marginTop: '50px' }}>
                <div className="container-fluid text-center text-md-left">
                    <div className="row">
                        <div className="col-md-6 mt-md-0 mt-3">
                            <h5 className="text">Nexia</h5>
                            <p>Мы можем все!</p>
                        </div>

                        <hr className="clearfix w-50 d-md-none pb-0" />

                        <div className="col-md-3 mb-md-0 mb-3">
                            <h5 className="text-uppercase">Помощь</h5>
                            <ul className="list-unstyled">
                                <li><a href="https://vk.com/ilya_shirokow">Возникли трудности?</a></li>
                            </ul>
                        </div>

                        <div className="col-md-3 mb-md-0 mb-3">
                            <h5 className="text-uppercase">Написать владельцу</h5>
                            <ul className="list-unstyled">
                                <li><a href="https://vk.com/ilya_shirokow">Вконтакте</a></li>
                            </ul>
                        </div>

                    </div>
                </div>

                <div className="footer-copyright text-center py-3">© 2023 Nexia

                </div>

            </footer>
        </Styles>
    </div>

)
export default Footer;
