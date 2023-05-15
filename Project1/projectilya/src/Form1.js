import React, {Component} from 'react';
import { UseFrom } from 'react-hook-form';
import { Button,Form } from 'react-bootstrap';


export class Form1 extends Component {
    
static displayName = Form1.name;

    constructor(props){

        super(props);
        this.state = {
            email :'',
            phone : '',
            nameorg:'',
            Id :''
        }

       
        this.onInputChange = this.onInputChange.bind(this);
        this.sendOrganizationsData = this.sendOrganizationsData.bind(this);

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
                    <label for="inputName">Почта</label>
                    <input type="Text" name="email" class="form-control" id="inputFIO" placeholder="" />
                    
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">ID</label>
                    <input name="Id" class="form-control" id="inputPhone" />
                </div>
                <div class="form-group col-md-6">
                    <label for="inputPassword4">Телефон</label>
                    <input name="phone" class="form-control" id="inputPhone" />
                </div>
            </div>
            <div class="form-group col-md-6">
                <label for="inputAddress">Название организации</label>
                <input type="text" name="nameorg" class="form-control" id="inputAddress"  />
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

            </div>
            

            <button  type="submit" class="f-button f-button - warning" >Продолжить</button>

        </Form>
        </>

        );
    }  
    
    async sendOrganizationsData() {
        let Organizations = {
            "Guid Id": this.state.Id,
            "NameOrganizations": this.state.nameorg,
            " Email ": this.state.email,
            "PhoneNumber": this.state.phone
            
        };
        console.log(Organizations);

        const reponse = await fetch('https://localhost:7166/Organizations/create', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                
            },
            body: JSON.stringify(Organizations)
        });

        const data = await reponse.json();
        console.log(data);
        
 }  

}

