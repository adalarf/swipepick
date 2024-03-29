import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";
import {setUser} from "../reducers/userReducer";
import {autoLogin} from "./autoLogin";

export const login = (email, password, router) => {
  return async dispatch => {
    try {
      const userLoginDto = { "email": email, "password": password }
      const response = await axios.post(`https://localhost:7286/api/auth/login`, {
        userLoginDto
      })
      console.log(response);
      dispatch(setUser(response.data.userEmail));
      localStorage.setItem('token', response.data.token);
      router.push('/');
    } catch (err) {
      alert(err)
    }
  }
}


