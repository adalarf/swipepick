import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";

export const register = async (email, password, name, lastname) => {
  const response = await axios.post(`https://localhost:7286/api/user/auth/register`, {
    email,
    password,
    name,
    lastname
  })
    .then((response)  => console.log(response))
    .catch((err) => alert(err))
}
