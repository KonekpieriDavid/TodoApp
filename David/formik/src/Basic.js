import React from 'react';
 import { Formik } from 'formik';
 import './styles.css';
 
 const Basic = () => (
   <div>

     <Formik
       initialValues={{ email: '', password: '' }}
       validate={values => {
         const errors = {};
         if (!values.email) {
           errors.email = 'Required';
         } else if (
           !/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$/i.test(values.email)
         ) {
           errors.email = 'Invalid email address';
         }
         return errors;
       }}
       onSubmit={(values, { setSubmitting }) => {
         setTimeout(() => {
           alert(JSON.stringify(values, null, 2));
           setSubmitting(false);
         }, 400);
       }}
     >
       {({
         values,
         errors,
         touched,
         handleChange,
         handleBlur,
         handleSubmit,
         isSubmitting,
         /* and other goodies */
       }) => (
       
        <div className="w-full max-w-xs flex justify-center ">
         <form onSubmit={handleSubmit}>
       
         <h1>Anywhere in your app!</h1>
         <div className="mb-4">
           <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
             type="email"
             name="email"
             placeholder="Enter email"
             onChange={handleChange}
             onBlur={handleBlur}
             value={values.email}
           />
           {errors.email && touched.email && errors.email}
           </div>
           <div className="mb-4" >
           <input className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
             type="password"
             name="password"
             placeholder="Enter password"
             onChange={handleChange}
             onBlur={handleBlur}
             value={values.password}
           />
           {errors.password && touched.password && errors.password}
           </div>
           <button type="submit" disabled={isSubmitting}>
             Submit
           </button>
      
         </form>
         </div>
       
       )}
     </Formik>
   </div>
 );
 
 export default Basic;