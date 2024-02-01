import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useEffect } from 'react';

function Login() {
  
useEffect(() => { 
    document.body.style.background = "url('https://media.istockphoto.com/id/1181871089/vector/garland-with-flags-1.jpg?s=612x612&w=0&k=20&c=j8cVYp9F4G-3pAlkkxoPjqg6Hkarr1cuzJL2QLgocHI=')";
    return function cleanup() {
      document.body.style.background = "";
    };
}
, [])
  return (
    <Form className='container mt-5 card p-2'>
      <h2 className='card-header'>Login Form</h2>
      <div className='card-body'>
      <Form.Group className="mb-3 form-floating" controlId="formBasicEmail">
        <Form.Control id='email' type="email" placeholder="Enter email" />
        <Form.Label htmlFor='email'>Email address</Form.Label>
      </Form.Group>

      <Form.Group className="mb-3 form-floating" controlId="formBasicPassword">
        <Form.Control id='password' type="password" placeholder="Password" />
        <Form.Label htmlFor='password'>Password</Form.Label>
      </Form.Group>
      <Form.Group className="mb-3" controlId="formBasicCheckbox">
        <Form.Check type="checkbox" label="Check me out" />
      </Form.Group>
      <Button variant="primary" type="submit">
        Submit
      </Button>
      </div>
    </Form>
  );
}

export default Login;
