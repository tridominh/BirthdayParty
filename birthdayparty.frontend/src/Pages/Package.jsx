import React, { Fragment, useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import PageHeader from '../Components/PageHeader';

function Package(){
    let navigate = useNavigate();
    const CheckLogin = () =>{
        if(localStorage.getItem("token") != null){
        
        }else{
            navigate("/login");
        }
    }
    return( 
        <Fragment>
            <PageHeader title={"Package"}/>
            <div>Package</div>
        </Fragment>
    );
}

export default Package;
