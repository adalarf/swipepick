import axios from "axios";

export const submitAnswers = async (testUri, selectedAnsws, setResult) => {
  try {
    console.log({
      testUri,
      selectedAnsws,
    })
    const response = await axios.post(`https://localhost:7286/api/swipepick/test/submit-answers`, {
      testUri,
      selectedAnsws,
    });
    console.log(response)
    setResult(response.data)
  } catch (err) {
    alert(err)
  }

}
