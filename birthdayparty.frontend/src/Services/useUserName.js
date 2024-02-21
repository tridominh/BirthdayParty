import { useState } from 'react';

export default function useUserName() {
  const getUsername = () => {
    return localStorage.getItem("username");
  };

  const [username, setUsername] = useState(getUsername());

  const saveUsername = value => {
    localStorage.setItem("username", value);
    setUsername(value);
  };

  const removeUsername = () => {
    localStorage.removeItem("username");
    setUsername("");
  };

  return {
    setUsername: saveUsername,
    removeUsername: removeUsername,
    username
  }
}
