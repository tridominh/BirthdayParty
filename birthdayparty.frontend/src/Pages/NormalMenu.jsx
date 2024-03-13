import React, {Fragment} from 'react'
import PageHeader from "../Components/PageHeader";
import "../assets/css/kidsMenu.css";
import {Link} from "react-router-dom";
export default function NormalMenu() {

    return (
        <Fragment>
            <PageHeader title={"NormalMenu"}/>
            <div className="menu">
                <h1>NormalMenu</h1>
                <ul>
                    <li>Chicken Curry</li>
                    <li>Beef Hot Pot</li>
                    <li>King Crab</li>
                    <li>Smoked Pork Belly</li>
                    <li>Cola</li>
                </ul>
                <Link to="/booking" className="booking-btn">Booking Now</Link>
            </div>
        </Fragment>
    )
}
