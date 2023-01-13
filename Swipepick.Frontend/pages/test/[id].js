import {useRouter} from "next/router";
import Question from "../../components/question";
import {useState} from "react";

const responses = []

export default function User({test}) {
  const {query} = useRouter()

  const numberOfQuestions = test.length
  const [number, setNumber] = useState(0)
  const [isEnd, setIsEnd] = useState(false)
  const [result, setResult] = useState()
  return (<>{isEnd ? <p>{result}</p> :
    <Question data={test[number]} testId={query.id} numberOfQuestions={numberOfQuestions} number={number}
              setNumber={setNumber} setIsEnd={setIsEnd} responses={responses} setResult={setResult}></Question>}
      </>
  )
};

export async function getServerSideProps({params}) {
  const response = await fetch(`https://localhost:7286/api/swipepick/test/${params.id}`)
  const test = await response.json()
  return {
    props: {test}, // will be passed to the page component as props
  }
}
