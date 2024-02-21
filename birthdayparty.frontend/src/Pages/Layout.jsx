import { Link, Outlet } from "react-router-dom";
import { Fragment } from "react";
import "../assets/css/layout.css";

function Layout() {
  return (
    <Fragment>
      
<div className="navbar navbar-expand-lg bg-light navbar-light">
            <div className="container-fluid">
                <a href="index.html" className="navbar-brand">Burger <span>King</span></a>
                <button type="button" className="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                    <div className="navbar-nav ml-auto">
                        <a href="index.html" className="nav-item nav-link active">Home</a>
                        <a href="about.html" className="nav-item nav-link">About</a>
                        <a href="feature.html" className="nav-item nav-link">Feature</a>
                        <a href="team.html" className="nav-item nav-link">Chef</a>
                        <a href="menu.html" className="nav-item nav-link">Menu</a>
                        <a href="booking.html" className="nav-item nav-link">Booking</a>
                        <div className="nav-item dropdown">
                            <a href="#" className="nav-link dropdown-toggle" data-toggle="dropdown">Pages</a>
                            <div className="dropdown-menu">
                                <a href="blog.html" className="dropdown-item">Blog Grid</a>
                                <a href="single.html" className="dropdown-item">Blog Detail</a>
                            </div>
                        </div>
                        <a href="contact.html" className="nav-item nav-link">Contact</a>
                    </div>
                </div>
            </div>
        </div>


      <Outlet/>
    </Fragment>
  );
}

export default Layout;

