/** @format */

import { useEffect } from "react";

export const FoodDisplay = ({ name, img, description }) => {
    useEffect(() => {
        if (!name | !img | !description) {
            throw new Error(
                "Xài component FoodDisplay phải truyền name, img & description "
            );
        }
    });
    return (
        <li className="foodMenuItem">
            <img
                className="foodMenuImg"
                src={img}
            />
            <div className="foodMenuName">{name}</div>
            <div className="foodMenuDescription">
                <ul>
                    {description.map((descript, i) => (
                        <li key={i}>{descript}</li>
                    ))}
                </ul>
            </div>
        </li>
    );
};
