import axios from "axios";


export const getTest = async (query) => {
  try {
    const queryId = query.id
    if (queryId != undefined) {
      const response = await axios.get(`https://localhost:7286/api/swipepick/test/${queryId}`)
      const test = response.data
      if (typeof test !== 'undefined') {
        return test
      }
    }
  } catch (err) {
    console.log(err)
  }
}
