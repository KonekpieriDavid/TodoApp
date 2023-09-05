import React from 'react';
import './App.css';


import Login from './Login';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter,Routes ,Route} from 'react-router-dom';
import SignUp from './SignUp';



function App() {
  return (
    < BrowserRouter >
    <Routes>
      <Route path='/' element={<Login/>}></Route>
      <Route path='/SignUp' element={<SignUp/>}></Route>
    </Routes>
 
        
    </ BrowserRouter>
  );
}

export default App;
