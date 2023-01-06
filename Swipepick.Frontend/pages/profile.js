import {logout} from "../reducers/userReducer";
import {useDispatch} from "react-redux";
import logo2 from "../public/logo2.svg";
import Logo from "../util/logo";
import Layout from "../components/layout";

const Profile = () => {
  const dispatch = useDispatch()

  return (
    <Layout title="Личный кабинет">
      <Logo href="/" src={logo2}/>
      <button onClick={() => dispatch(logout())}>ВЫЙТИ</button>
    </Layout>
  )

}

export default Profile
