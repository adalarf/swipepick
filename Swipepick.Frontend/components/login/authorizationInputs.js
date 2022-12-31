import styles from "../../styles/Login.module.css";
import Input from "../../util/login/input";
import {useState} from "react";
import {login} from "../../api/login";
import {useDispatch, useSelector} from "react-redux";
import {logout} from "../../reducers/userReducer";

const AuthorizationInputs = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const dispatch = useDispatch()
  const isAuth = useSelector(state => state.user.isAuth);

  return (
    <div className={styles.registration_inputs}>
      <Input value={email} setValue={setEmail} type="text"
             placeholder="Введите email" id="email" labelText="Ваш E-mail" />
      <Input value={password} setValue={setPassword} type="password"
             placeholder="Введите пароль" id="password" labelText="Ваш пароль" />
      <button onClick={() => dispatch(login(email, password))}>ВОЙТИ</button>
      <button onClick={() => dispatch(logout())}>ВЫЙТИ</button>
      {isAuth && <p>Чел, ты реально крут, потому что вошел в аккаунт</p>}
      {!isAuth && <p>Чел, ты не вошел в аккаунт</p>}
    </div>
  )
}

export default AuthorizationInputs;
