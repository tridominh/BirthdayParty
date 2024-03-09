import { Link, Outlet, useNavigate } from "react-router-dom";
import { Fragment, useEffect, useState } from "react";
import "../assets/css/layout.css";
import parseJwt from "../Services/parseJwt";

function Layout({ token, removeToken }) {
  let navigate = useNavigate();  
  const handleLogout = (e) => {
    e.preventDefault();
    removeToken();
    navigate("/");
  };
  
  return (
    <Fragment>
      
      <div className="navbar navbar-expand-lg bg-light navbar-light">
            <div className="container-fluid">
                <a href="index.html" className="navbar-brand">Booking <span>Party</span></a>
                <button type="button" className="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                    <div className="navbar-nav ml-auto">
                        <Link to="/" className="nav-item nav-link active">Home</Link>
                        <Link to="/About" className="nav-item nav-link">About</Link>
                        <Link to="/Booking" className="nav-item nav-link">Booking</Link>
                        <Link to="/Package">
                        <div className="nav-item dropdown">
                            <Link to="/Package" className="nav-link dropdown-toggle" data-toggle="dropdown">Package</Link>
                            <div className="dropdown-menu">
                                <Link to="/Package" className="dropdown-item">Package</Link>
                                <Link to="/VegetarianMenu" className="dropdown-item">Vegetarian Menu</Link>
                                <Link to="/NormalMenu" className="dropdown-item">Normal Menu</Link>
                                <Link to="/KidsMenu" className="dropdown-item">Kids Menu</Link>
                            </div>
                        </div>
                        </Link>
                        
                        {token ? (
                            <div className="nav-item dropdown">
                                <Link to="/" className="nav-link dropdown-toggle" data-toggle="dropdown">{parseJwt(token).given_name}</Link>
                                <div className="dropdown-menu">
                                    <button onClick={handleLogout} className="dropdown-item">Logout</button>
                                </div>
                            </div>
                        ):(
                            <Link to="/login" className="nav-item nav-link">Login</Link>
                        )}
                    </div>
                </div>
            </div>
        </div>


      <Outlet/>
    </Fragment>
  );
}


export default Layout;

