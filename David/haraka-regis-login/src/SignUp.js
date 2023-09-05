import React, { useState } from 'react'
import 'react-phone-number-input/style.css'
import PhoneInput from 'react-phone-number-input'


import { Link } from 'react-router-dom'
import Validation from './SignUpValidation'

function SignUp() {
    const [values ,setValues] =useState({
       userName:"",
       phoneNumber:"",
       emailAddress:"",
       password:"",
       comfirmPassword:""
        
    })
    const [errors,setErrors] = useState({})
    const handleInput=(event) =>{
        setValues(prev =>({...prev,[event.target.name]:[event.target.values]}))
    }
    const handleSubmit =(event)=>{
      
        event.preventDefault();
        console.log(values)
        setErrors(Validation(values));
    }
    render(){
      const {userName,phoneNumber,emailAddress, password,comfirmPassword}=setValues
    }
  return (
    <div className="container d-flex justify-content-center col-xs-4 col-xs-offset-4 item col-lg-4 col-centered  text-center bg-primary vh-100 m-4  ">
    <div className='bg-white p-3 mr-3 ml-3 rounded w-25'>
      <form action = "" onSubmit={handleSubmit}>
   ``<div className='mb-4'>
            <h1>ARAKA SignUp</h1>
            <label htmlFor="userName"></label>
            <input type ="userName" placeholder="Your full name or mechant name..."  values={values} name='userName'
                  onChange ={handleInput}className='form-control rounded-0 bg-info' />
                  {errors?.userName &&<span className='text-danger'>{errors?.userName}</span>}
         
            </div>
            ``<div className='mb-4'>
            

            <PhoneInput type ="text"
          placeholder="Enter phone number"
          values={values}
          name="phoneNumber"
           onChange={setValues}/>
           
            </div>
            &nbsp;
        
        <div className='mb-4'>
            
            <label htmlFor="emailAddress"><strong> </strong></label>
            <input type ="emailAddress" placeholder="Your EmailAddress..." autoComplete='off'name="emailAddress"
                    onChange ={handleInput}className='form-control rounded-0' />
                  {errors?.emailAddress &&<span className='text-danger'>{errors?.emailAddress}</span>}
            &nbsp;&nbsp;
        </div>
        <div className='mb-3'>
            <label htmlFor="password"> <strong></strong></label>
            <input type ="password" placeholder="Your Password" name="password"
               onChange ={handleInput}className='form-control rounded-0' />
             {errors?.password &&<span className='text-danger'>{errors?.password}</span>}
            &nbsp;&nbsp;&nbsp;
        </div>
        <div className='mb-3'>
            <label htmlFor="confirmpassword"> <strong></strong></label>
            <input type ="password" placeholder="Retype Password"autoComplete='off'
            name='comfirmpassword'
            onChange ={handleInput} className='form-control rounded-0' />
            {errors?.comfirmPassword &&<span className='text-danger'>{errors?.comfirmPassword}</span>}
            &nbsp;&nbsp;&nbsp;
        </div>
        <button type="submit" className='mt-3 btn btn-success  btn-lg btn-block bg-light rounded-0'><strong> SignUp</strong></button>&nbsp;&nbsp;
        <p> You have agree to the teams and policies </p>&nbsp;
        <Link to ="/" className='btn btn-default border rounded-0 text-decoration-none'> Login</Link>
      </form>
    
    
    </div>
</div>
   
  )
}

export default SignUp;