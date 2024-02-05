import { Link, Outlet } from "react-router-dom";
import { Fragment } from "react";
import "../assets/css/layout.css";
import OwlCarousel from "react-owl-carousel";
import 'owl.carousel/dist/assets/owl.carousel.css';
import 'owl.carousel/dist/assets/owl.theme.default.css';

function Layout() {
  return (
    <Fragment>
      <div className="navbar navbar-expand-lg bg-dark navbar-light">
            <div className="container-fluid">
                <a href="index.html" className="navbar-brand">Burger <span>King</span></a>
                <button type="button" className="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                    <div className="navbar-nav ml-auto">
                        <Link className="nav-item nav-link" to="/">Home</Link>
                        <Link className="nav-item nav-link" to="/booking">Booking</Link>
                        <Link className="nav-item nav-link" to="/login">Login</Link>                        
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

