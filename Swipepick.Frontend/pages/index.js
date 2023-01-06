import StandardLayout from "../components/standardLayout";
import HomeMain from "../components/homeMain";
import {useDispatch} from "react-redux";
import {useEffect} from "react";
import {autoLogin} from "../api/autoLogin";


const Index =  () => {
  const dispatch = useDispatch()
  useEffect(() => {dispatch(autoLogin())})

  return (
    <StandardLayout>
      <HomeMain/>
    </StandardLayout>
  )
}

export default Index;

