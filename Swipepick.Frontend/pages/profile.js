import {logout} from "../reducers/userReducer";
import {useDispatch, useSelector} from "react-redux";
import logo2 from "../public/logo2.svg";
import Logo from "../util/logo";
import Layout from "../components/layout";
import {useEffect} from "react";
import {autoLogin} from "../api/autoLogin";

const Profile = () => {
  const dispatch = useDispatch()
  const isAuth = useSelector(state => state.user.isAuth);
  useEffect(() => {dispatch(autoLogin())})

  return (
    <Layout title="Личный кабинет">
      <Logo href="/" src={logo2}/>
      <button onClick={() => dispatch(logout())}>ВЫЙТИ</button>
      {isAuth ? <p>ok</p> : <p>not</p>}
    </Layout>
  )

}

export default Profile
