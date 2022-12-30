import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";

export const login = async (email, password) => {
  console.log({
    email,
    password
  })
  const response = await axios.post(`https://localhost:7286/api/user/auth/login`, {
    email,
    password
  })
    .then((response)  => console.log(response))
    .catch((err) => console.log("такого пользлвателя нет"))
}
