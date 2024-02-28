import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

function Booking(){
        let navigate = useNavigate();
    const CheckLogin = () =>{
        if(localStorage.getItem("token") != null){
        
        }else{
            navigate("/login");
        }
    }
    return(    <div className="booking">
        <div className="container">
            <div className="row align-items-center">
                <div className="col-lg-7">
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
                <div className="col-lg-5">
                    <div className="booking-form">
                        <form>
                            <div className="control-group">
                                <div className="input-group">
                                    <input type="text" className="form-control" placeholder="Name" required="required" />
                                    <div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-user"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group">
                                    <input type="email" className="form-control" placeholder="Email" required="required" />
                                    <div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-envelope"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group">
                                    <input type="text" className="form-control" placeholder="Mobile" required="required" />
                                    <div className="input-group-append">
                                        <div className="input-group-text"><i className="fa fa-mobile-alt"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group date" id="date" data-target-input="nearest">
                                    <input type="text" className="form-control datetimepicker-input" placeholder="Date" data-target="#date" data-toggle="datetimepicker"/>
                                    <div className="input-group-append" data-target="#date" data-toggle="datetimepicker">
                                        <div className="input-group-text"><i className="far fa-calendar-alt"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group time" id="time" data-target-input="nearest">
                                    <input type="text" className="form-control datetimepicker-input" placeholder="Time" data-target="#time" data-toggle="datetimepicker"/>
                                    <div className="input-group-append" data-target="#time" data-toggle="datetimepicker">
                                        <div className="input-group-text"><i className="far fa-clock"></i></div>
                                    </div>
                                </div>
                            </div>
                            <div className="control-group">
                                <div className="input-group">
                                    <input type="text" className="custom-select form-control"placeholder="Amount" required="required">
                                    </input>
                                    <div className="input-group-append">
                                        <div className="input-group-text"><i className="far fa-user"></i></div>
                                    </div>
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
    );{/*  Booking End */}
    
}



export default Booking;
