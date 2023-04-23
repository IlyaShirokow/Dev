import React from 'react';
import { UseFrom } from 'react-hook-form';
import { Button, Modal, Form, input } from 'react-bootstrap';


export const Form1 = () => (
    
    
    <>
 
        <h1 style ={{padding:'10px'}}>Форма для заполнения</h1>
     
        <Form style ={{padding:'10px'}}>
            

            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputName">ФИО</label>
                    <input type="Name" class="form-control" id="inputFIO" placeholder="" />
                    
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Телефон</label>
                    <input class="form-control" id="inputPhone" />
                </div>
            </div>
            <div class="form-group col-md-6">
                <label for="inputAddress">Адрес</label>
                <input type="text" class="form-control" id="inputAddress"  />
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="inputCity">ИНН</label>
                    <input type="text" class="form-control" id="inputINN" />
                </div>
                <div class="form-group col-md-4">
                    <label for="inputProduct">Продукт</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Предзаказ Iphone 15 Pro</option>
                        <option>Телефон Xiaomi 13 lite</option>
                        <option>Телефон Xiaomi 10s</option>
                        <option>Телефон Redmi not 12 pro+</option>
                        <option>Телефон Xiaomi 12 Ultra</option>
                        <option>Ноутбук Asus Predator 300</option>
                        <option>Ноутбук HP-Spectre</option>
                        <option>Ноутбук HP Ultimate Edition+</option>
                        <option>Ноутбук MacBook Pro</option>
                        <option>Телевизор Econ EX-32HS019B</option>
                        <option>Телевизор Samsung Neo 2</option>
                        <option>Телевизор Novex NWX-75U011MSG</option>
                        <option>Телевизор Misura t9</option>
                        <option>Игровая приставка Playstation 5</option>
                        <option>Игровая приставка  Xbox one s</option>
                        <option>Игровая приставка  Nintendo Switch</option>
                        <option>Игровая приставка  Steam Deck</option>
                    </select>
                </div>

            </div>
            

            <button  type="submit" class="f-button f-button - warning" >Продолжить</button>

        </Form>

        

    </>
)
export default Form1;