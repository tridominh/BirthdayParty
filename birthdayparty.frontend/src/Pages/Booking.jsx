import React, { Fragment, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import PageHeader from '../Components/PageHeader';
import useToken from '../Services/useToken';
import "../assets/css/customer-booking.css"

function Booking(){
    let navigate = useNavigate();

    const CheckLogin = () =>{
        if(useToken().token != null){
        
        }else{
            navigate("/login");
        }
    };

    const handleBookingSubmit = () => {
        
    };

    return( 
    <Fragment>
    <PageHeader title={"Booking"}/>
    <div className="booking">
        <div className="container">
            <div className="row align-items-center">
                <div className="col-lg-6">
                    <div className="booking-content">
                        <div className="section-header">
                            <p>Book A Table</p>
                            <h2>Book Table For Your Kids</h2>
                        </div>
                        <div className="about-text">
                            <p>
                            Create an unforgettable birthday party experience for children, full of joy and cherished memories. Our Birthday Party Booking service for kids aims to provide a magical celebration customized to the interests and desires of the child. We aim to make your child's special day even more special.
                            </p>
                            <p>
                            Let us take care of the planning and organization, while you enjoy seeing the happy faces of your child shining with joy amidst the fun with friends and family.                                </p>
                        </div>
                    </div>
                </div>
                <div className="col-lg-6">
                    <div className="booking-form">
                        <form onSubmit={handleBookingSubmit}>
                            
                            <div className="control-group">
                                <div className="input-group">
                                    <select className="form-control" aria-label="Default select example">
                                        <option selected>Room 1</option>
                                        <option value="1">Room 2</option>
                                        <option value="2">Room 3</option>
                                        <option value="3">Room 4</option>
                                    </select>
        {/*<div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-envelope"></i></div>
                                    </div>*/}
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group date" id="date" data-target-input="nearest">
                                    <input type="datetime-local" className="form-control" placeholder="Date"/>
        {/*<div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-calendar-alt"></i></div>
                                    </div>*/}
                                </div>
                            </div>
                            <h5 className='text-white'>Package</h5>
                            <div className="control-group row">
                                <label className='col-3 booking-label'>Menu</label>
                                <div className="col-9 input-group">
                                    <select className="form-control" aria-label="Default select example">
                                        <option selected>Room 1</option>
                                        <option value="1">Room 2</option>
                                        <option value="2">Room 3</option>
                                        <option value="3">Room 4</option>
                                    </select>
        {/*<div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-envelope"></i></div>
                                    </div>*/}
                                </div>
                            </div>
                            <div className="control-group row">
                                <label className='col-3 booking-label'>Entertainment</label>
                                <div className="col-9 input-group">
                                    <select className="form-control" aria-label="Default select example">
                                        <option selected>Room 1</option>
                                        <option value="1">Room 2</option>
                                        <option value="2">Room 3</option>
                                        <option value="3">Room 4</option>
                                    </select>
        {/*<div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-envelope"></i></div>
                                    </div>*/}
                                </div>
                            </div>
                            <div>
                                <button className="btn custom-btn" type="submit" onClick={CheckLogin}>Book Now</button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </Fragment>
    );{/*  Booking End */}
    
}



export default Booking;
