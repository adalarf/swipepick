import axios from "axios";
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";
import {logout, setUser} from "../reducers/userReducer";

export const autoLogin =  () => {
  return async dispatch => {
    try {
      const response = await axios.get(`https://localhost:7286/api/swipepick/user/get-email`,
        {headers: {Authorization: `Bearer ${localStorage.getItem("token")}`}}
      )
      console.log(response)
      dispatch(setUser(response.data.email))
    } catch (err) {
      console.log(err)

    }
  }
}
