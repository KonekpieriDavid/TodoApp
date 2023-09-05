function  Validation(values){
   
    let error={}
    const emailAddress_pattern =/^[^\s@]+@[^\s@]+\.[^\s@]+$/
    const password_pattern =/^(?=.*\d)(?=.*[a-z])(?=.*[A_Z])[a-zA-Z0-9]{8,}$/
    const comfirmpassword_pattern =/^(?=.*\d)(?=.*[a-z])(?=.*[A_Z])[a-zA-Z0-9]{8,}$/
    const userName_pattern  =/^(?=.*\d)(?=.*[a-z])(?=.*[A_Z])[a-zA-Z0-9]{8,}$/
    const phoneNumber_pattern =/^[+]?[(]?[0-9]{3}[)]?[-s.]?[0-9]{3}[-s.]?[0-9]{4,6}$/
    if(values.userName ===""){
        error.userName ="username should not be empty"
    }
    else if (!userName_pattern.test(values.userName)){
        error.userName="userName  didn't match"
    }
    else{
        error.userName=""
    }
    if(values.phoneNumber_pattern ===""){
        error.phoneNumber ="phoneNumber should not be empty"
    }
    else if (!phoneNumber_pattern.test(values.phoneNumber)){
        error.phoneNumber="phoneNumber  didn't match"
    }
    else{
        error.phoneNumber=""
    }
    if(values.emailAddress ===""){
        error.emailAddress ="email should not be empty"
    }
    else if (!emailAddress_pattern.test(values.emailAddress)){
        error.emailAddress="email  didn't match"
    }
    else{
        error.emailAddress=""
    }
    if (values.password ===""){
        error.password ="pasword should not be empty"
    }
    else if (!password_pattern.test(values.password)){
        error.password="password didn't match"
    }
    else{
        error.password=""
        return error;
    }
    if (values.comfirmpassword ===""){
        error.comfirmpassword ="pasword should not be empty"
    }
    else if (!comfirmpassword_pattern.test(values.comfirmpassword)){
        error.comfirmpassword="password didn't match"
    }
    else{
        error.comfirmpassword=""
        return error;
    }
}
export default Validation;