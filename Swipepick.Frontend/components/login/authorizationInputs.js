import styles from "../../styles/Login.module.css";
import Input from "../../util/login/input";
import {useState} from "react";
import {login} from "../../api/login";
import {useDispatch, useSelector} from "react-redux";
import {logout} from "../../reducers/userReducer";
import {useRouter} from "next/router";

const AuthorizationInputs = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const dispatch = useDispatch()
  const router = useRouter()

  return (
    <div className={styles.registration_inputs}>
      <Input value={email} setValue={setEmail} type="text"
             id="email" labelText="Ваш E-mail" />
      <Input value={password} setValue={setPassword} type="password"
             id="password" labelText="Ваш пароль" />
      <button className={styles.send_button} onClick={() =>
        dispatch(login(email, password, router))}>ВОЙТИ</button>
    </div>
  )
}

export default AuthorizationInputs;
