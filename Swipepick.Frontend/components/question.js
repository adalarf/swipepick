import axios from "axios";
import {submitAnswers} from "../api/submitAnsvers";
import styles from "../styles/Test.module.css"

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
      <p className={styles.number}>{indicativeNumber}/{numberOfQuestions}</p>
      <div className={styles.wrapper}>
        <div className={styles.question}>{question}</div>
        <div className={styles.responses}>
          {options.map((option) => <button className={styles.response} onClick={() =>
            indicativeNumber === numberOfQuestions ? saveEndUserResponse(option) :
              saveUserResponse(option)}>{option}</button>)}
        </div>
      </div>
    </div>
  )
}

export default Question;
