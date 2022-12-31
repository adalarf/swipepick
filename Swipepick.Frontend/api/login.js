import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";
import {setUser} from "../reducers/userReducer";

export const login = (email, password) => {
  return async dispatch => {
    const response = await axios.post(`https://localhost:7286/api/user/auth/login`, {
      email,
      password
    })
      .then((response) => {
        console.log(response);
        dispatch(setUser(response.data.userEmail));
        localStorage.setItem('token', response.data.token);
      })
      .catch((err) => console.log("такого пользлвателя нет"))
  }
}
