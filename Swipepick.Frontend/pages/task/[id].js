import {useRouter} from "next/router";
import Question from "../../components/question";
import {useState} from "react";
import Link from "next/link";
import styles from "../../styles/Test.module.css";

const responses = []

export default function User({test}) {
  const {query} = useRouter()
  const numberOfQuestions = test.length
  const [number, setNumber] = useState(0)
  const [isEnd, setIsEnd] = useState(false)
  const [result, setResult] = useState()
  return (
    <div className={styles.background}>

      {isEnd ?
        <div className={styles.result_wrapper}>
          <div className={styles.text}> Ваш результат <div className={styles.result}>{result}/{numberOfQuestions}</div></div> <Link className={styles.button_finish} href="/">ЗАВЕРШИТЬ</Link>
        </div> :
        <Question data={test[number]} testId={query.id}
                  numberOfQuestions={numberOfQuestions} number={number} setNumber={setNumber}
                  setIsEnd={setIsEnd} responses={responses} setResult={setResult}></Question>}

    </div>
  )
};

export async function getServerSideProps({params}) {
  const response = await fetch(`swipepick/test/${params.id}`)
  const test = await response.json()
  return {
    props: {test},
  }
}
