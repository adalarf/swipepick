import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";

export const register = async (email, password, name, lastname) => {
  try {
    const user = { "email": email, "password": password, "name": name, "lastname": lastname }
    const response = await axios.post('https://localhost:7286/api/auth/register', {
      user
    });
  } catch (err) {
    alert(err)
  }

}
