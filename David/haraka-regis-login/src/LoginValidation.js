
function  Validation(values){
   
    let error={}
    const emailAddress_pattern =/^[^\s@]+@[^\s@]+\.[^\s@]+$/
    const password_pattern =/^(?=.*\d)(?=.*[a-z])(?=.*[A_Z])[a-zA-Z0-9]{8,}$/
   
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
}
export default Validation;