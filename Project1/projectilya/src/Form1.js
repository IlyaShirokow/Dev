import React, {Component} from 'react';
import { UseFrom } from 'react-hook-form';
import { Button,Form } from 'react-bootstrap';


export class Form1 extends Component {
    
static displayName = Form1.name;

    constructor(props){

        super(props);
        this.state = {
            phone : '',
            address:'',
            email :''
        }

       
        this.onInputChange = this.onInputChange.bind(this);
        this.sendOrderData = this.sendOrderData.bind(this);

    }

    onInputChange(event) {
        this.setState({
            [event.target.name]: event.target.value
        });
    }
    
    render() {

        return (
 
        <><h1 style ={{padding:'10px'}}>Форма для заполнения</h1>
     
        <Form style ={{padding:'10px'}}>
            

            <div class="form-row">
                
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Телефон</label>
                    <input name="phone" class="form-control" id="phone" value={this.state.phone} onChange={this.onInputChange}/>
                </div>
            </div>
            <div class="form-group col-md-6">
                <label for="inputAddress">Адрес</label>
                <input type="text" name="address" class="form-control" id="address"  value={this.state.address} onChange={this.onInputChange}/>
            </div>
            <div class="form-group col-md-6">
                    <label for="inputName">Почта</label>
                    <input type="Text" name="email" class="form-control" id="email" placeholder="" value={this.state.email} onChange={this.onInputChange}/>
                    
                </div>
            <div class="form-row">
                <div class="form-group col-md-4">
                    <label for="inputProduct">Продукт</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Сухарики 3 корочки </option>
                        <option>Пиво старый мельник</option>
                        <option>Чипсы Lays</option>
                        <option> Кока кола </option>
                        <option> Фанта </option>
                        <option> Тушеная говядина </option>
                        
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputProduct">авто</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Газель </option>
                        <option>Хёндай</option>
                        
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputProduct">Водитель</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Саватеев А.В </option>
                        <option>Захаров Д.А.</option>
                        
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputProduct">Организация</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Пятёрочка </option>
                        <option>Магнит</option>
                        
                    </select>
                </div>
                <div class="form-group col-md-4">
                    <label for="inputProduct">Накладная</label>
                    <select id="inputState" class="form-control">
                        <option selected>Выбрать</option>
                        <option>Большая </option>
                        <option>Маленькая</option>
                        
                    </select>
                </div>
            </div>
            

            <button  type="submit" class="f-button f-button - warning" onClick={this.sendOrderData}>Продолжить</button>

        </Form>
        </>

        );
    }  
    
    async sendOrderData() {
        let Order = {
            "Address": this.state.address,
            "Email": this.state.email,
            "PhoneNumber": this.state.phone
            
        };
        console.log(Order);

        const reponse = await fetch('https://localhost:7024/api/Domain/Order', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                
            },
            body: JSON.stringify(Order)
        });

        const data = await reponse.json();

        
 }  

}

