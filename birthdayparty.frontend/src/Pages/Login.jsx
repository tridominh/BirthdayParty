import { Fragment, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useNavigate } from 'react-router-dom';
import getEndpoint from '../Services/getEndpoint';

function Login({ setToken }){
    
}

export default Login;

/*async function loginUser(credentials) {
    console.log(JSON.stringify(credentials))
    return fetch(`${getEndpoint()}/user/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Access-Control-Allow-Headers': '*',
        },
        body: JSON.stringify(credentials)
    })
        .then(data => data.json())
}

function Login({ setToken }) {
    let navigate = useNavigate();
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");

    useEffect(() => { 
        document.body.style.background = "url('https://media.istockphoto.com/id/1181871089/vector/garland-with-flags-1.jpg?s=612x612&w=0&k=20&c=j8cVYp9F4G-3pAlkkxoPjqg6Hkarr1cuzJL2QLgocHI=')";
        return function cleanup() {
          document.body.style.background = "";
        };
    }, [])
    
    const handleSubmit = async e => {
        e.preventDefault();
        const user = await loginUser({
          email,
          password
        });
        setToken(user.token);
        navigate("/");
    }
  return (<Fragment>
    <Form className='container mt-5 card p-2' onSubmit={handleSubmit}>
      <h2 className='card-header'>Login Form</h2>
      <div className='card-body'>
      <Form.Group className="mb-3 form-floating" >
        <Form.Control id='email' type="text" placeholder="Enter email" 
            onChange={(e) => setEmail(e.target.value)}/>
        <Form.Label htmlFor='email'>Email address</Form.Label>
      </Form.Group>

      <Form.Group className="mb-3 form-floating">
        <Form.Control id='password' type="password" placeholder="Password" 
            onChange={(e) => setPassword(e.target.value)}/>
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

    </Fragment>
  );
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired
}

export default Login;*/
