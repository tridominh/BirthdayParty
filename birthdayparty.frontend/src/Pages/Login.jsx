import { Fragment, useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useNavigate } from 'react-router-dom';
import getEndpoint from '../Services/getEndpoint';

async function loginUser(credentials) {
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

function Login({ setToken, setUsername }) {
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
        setUsername(user.name);
        navigate("/");
    }
  return (<Fragment>
    <form className='container mt-5 card p-2' onSubmit={handleSubmit}>
      <h2 className='card-header'>Login Form</h2>
      <div className='card-body'>
      <div className="mb-3 form-floating" >
        <input id='email' className='form-control' type="text" placeholder="Enter email" 
            onChange={(e) => setEmail(e.target.value)}/>
        <label htmlFor='email'>Email address</label>
      </div>

      <div className="mb-3 form-floating">
        <input id='password' className='form-control' type="password" placeholder="Password" 
            onChange={(e) => setPassword(e.target.value)}/>
        <label htmlFor='password'>Password</label>
      </div>
      <div className="mb-3" controlId="formBasicCheckbox">
        <input type="checkbox" content="Check me out" />
      </div>
      <button className="btn btn-primary" type="submit">
        Submit
      </button>
      </div>
    </form>

    </Fragment>
  );
}

Login.propTypes = {
  setToken: PropTypes.func.isRequired
}

export default Login;
