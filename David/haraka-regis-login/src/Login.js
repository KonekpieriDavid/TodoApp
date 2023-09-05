import React, { useState } from 'react'
import './LoginValidation';
import Validation from './LoginValidation';

import { Link } from 'react-router-dom'
function Login(){
    const [values ,setValues] =useState({
     
        emailAddress:'',
        password:''
    })
    const [errors,setErrors] = useState({})
    const handleInput=(event) =>{
        setValues(prev =>({...prev,[event.target.name]:[event.target.value]}))
    }
    const handleSubmit =(event)=>{
        event.preventDefault();
        console.log(values)
        setErrors(Validation(values));
    }

    return(
        
        <div className="container d-flex justify-content-center col-xs-4 col-xs-offset-4 item col-lg-4 col-centered  text-center bg-primary vh-100 m-4  ">
            <div className='bg-white p-3 mr-3 ml-3 rounded w-25'>
              <form action = "" onSubmit={handleSubmit}>
              
           ``
                <div className='mb-4'>
                    <h1>ARAKA LOGIN</h1>

                    <label htmlFor="emailAddress"><strong> EmailAddress</strong></label>
                    <input type ="emailAddress" placeholder="asd@gmail.com" name='emailAddress'
                    onChange ={handleInput} className='form-control rounded-0' />
                    {errors?.emailAddress &&<span className='text-danger'>{errors?.emailAddress}</span>}
                    &nbsp;&nbsp;
                </div>
                <div className='mb-3'>
                    <label htmlFor="password"> <strong>Password</strong></label>
                    <input type ="password" placeholder="Enter password" name='Password'
                       onChange ={handleInput}  className='form-control rounded-0' />
                       {errors?.password &&<span className='text-danger'>{errors?.password}</span>}
                    &nbsp;&nbsp;&nbsp;
                </div>
                <button type="submit" className='mt-3 btn btn-success  btn-lg btn-block bg-light rounded-0'><strong> Login</strong></button>&nbsp;&nbsp;
                <p> You have agree to the teams and policies </p>&nbsp;
                <Link to ="/SignUp" className='btn btn-default border rounded-0 text-decoration-none'> Create Account</Link>

              </form>

            </div>
        </div>
    )
}
export default Login 