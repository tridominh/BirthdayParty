import React, { useEffect, useState } from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Layout from "./Pages/Layout";
import Home from "./Pages/Home";
import Booking from "./Pages/Booking";
import NotFound from "./Pages/NotFound";
import Login from './Pages/Login';
//import 'bootstrap/dist/css/bootstrap.min.css';
import "@fortawesome/fontawesome-free/css/all.min.css";
import useToken from './Services/useToken';
import useUserName from './Services/useUserName';
import About from './Pages/About';
import Package from './Pages/Package';
import KidsMenu from './Pages/KidsMenu';
import NormalMenu from './Pages/NormalMenu';
import VegetarianMenu from './Pages/VegetarianMenu';

export default function App() {
  const { token, setToken, removeToken } = useToken();
  
  useEffect(() => {
      
  }
  , [])

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout token={token} 
            removeToken={removeToken}
            />}>
          <Route index element={<Home />} />
          <Route path="about" element={<About/>} />
          <Route path="package" element={<Package/>} />
          <Route path="booking" element={<Booking />} />
          <Route path="*" element={<NotFound />} />
          <Route path='kidsMenu' element={<KidsMenu />} />
          <Route path='normalMenu' element={<NormalMenu />} />
          <Route path='vegetarianMenu' element={<VegetarianMenu />} />
        </Route>
        <Route path='login' element={<Login setToken={setToken} 
              />}/>
      </Routes>
    </BrowserRouter>
  );
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<App />);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
