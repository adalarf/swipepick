import styles from "../../styles/Login.module.css";
import Input from "../../util/login/input";
import {useState} from "react";
import {login} from "../../api/login";

const AuthorizationInputs = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")

  return (
    <div className={styles.registration_inputs}>
      <Input value={email} setValue={setEmail} type="text"
             placeholder="Введите email" id="email" labelText="Ваш E-mail" />
      <Input value={password} setValue={setPassword} type="password"
             placeholder="Введите пароль" id="password" labelText="Ваш пароль" />
      <button onClick={() => login(email, password)}>ВОЙТИ</button>
    </div>
  )
}

export default AuthorizationInputs;
