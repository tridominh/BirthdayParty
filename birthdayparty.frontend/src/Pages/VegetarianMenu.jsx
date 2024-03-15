/** @format */

import React, { Fragment } from "react";
import PageHeader from "../Components/PageHeader";
import "../assets/css/kidsMenu.css";
import { Link } from "react-router-dom";
import { FoodDisplay } from "../Components/FoodDisplay";

// Tự thêm dữ liệu theo mẫu có sẵn
const foodArr = [
    {
        name: "Hamburger",
        img: "./img/menu-burger-img.jpg",
        description: [
            '2 nước ngọt',
            '1 Hamburger bò',
            '1 khoai tây chiên',
        ]
    },
    {
        name: "Pizza",
        img: "./img/menu-burger-img.jpg",
        description: [
            '1 Coca',
            '1 Pizza hải sản',
        ]
    },
    {
        name: "Snacks",
        img: "./img/menu-burger-img.jpg",
        description: []
    },
    {
        name: "Soft Drinks",
        img: "./img/menu-burger-img.jpg",
        description: []
    },
    {
        name: "Fruit Drinks",
        img: "./img/menu-burger-img.jpg",
        description: []
    },
];

export default function KidsMenu() {
    return (
        <>
            <PageHeader title="KidsMenu" />
            <h1 className="kidMenu">KidsMenu</h1>
            <ul className="foodMenu">
                {/* Food Item */}
                {foodArr.map((food, i) => (
                    <FoodDisplay
                        key={i}
                        name={food.name}
                        img={food.img}
                        description={food.description}
                    />
                ))}
            </ul>
            <Link
                to="/booking"
                className="booking-btn"
            >
                Booking Now
            </Link>
        </>
    );
}
