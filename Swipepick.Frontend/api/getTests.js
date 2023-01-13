import axios from 'axios'
import {console} from "next/dist/compiled/@edge-runtime/primitives/console";
import {setUser} from "../reducers/userReducer";

export const getTests = async (a) => {
  console.log(a)
    try {
      const response = await axios.get(`https://localhost:7286/swipepick/test/${a}`
      );
      console.log(response)
    } catch (err) {
      console.log(err)

    }
}
