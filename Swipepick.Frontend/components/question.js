import axios from "axios";
import {submitAnswers} from "../api/submitAnsvers";


const Question = ({ data, testId, numberOfQuestions, number, setNumber, setIsEnd, responses, setResult }) => {
  const questionId = data.queId
  const question = data.question
  const options = data.options
  const indicativeNumber = number + 1
  const saveUserResponse = (option) => {
    setNumber(prev => prev + 1)
    responses.push({
      queId: questionId,
      answ: options.indexOf(option) + 1,
    })
    console.log(responses)
  }

  const saveEndUserResponse = (option) => {
    setIsEnd(true)
    responses.push({
      queId: questionId,
      answ: options.indexOf(option) + 1,
    })
    submitAnswers(testId, responses, setResult)
    console.log(responses)
  }
  return (
    <div>
      <p>{indicativeNumber}/{numberOfQuestions}</p>
      <div>{question}</div>
      <div>
        {options.map((option) => <button onClick={() => indicativeNumber === numberOfQuestions ? saveEndUserResponse(option) : saveUserResponse(option)}>{option}</button>)}
      </div>
    </div>
  )
}

export default Question;
