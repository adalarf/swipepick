import styles from "../styles/Authorization.module.css"
import Layout from "../components/layout";
import {useState} from "react";
import InputAuthorization from "../util/inpupAuthorization";
import {registration} from "./api/registration";

const Authorization = ( ) => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const [name, setName] = useState("")
  const [lastname, setLastname] = useState("")

  return (
    <Layout title="Вход и регистрация">
      <div className={styles.background}>
        <div className={styles.authorization_form}>
          <div className={styles.button_wrapper}>

          </div>
          <div className={styles.registration_inputs}>
            <InputAuthorization value={email} setValue={setEmail} type="text" placeholder="Введите email"/>
            <InputAuthorization value={password} setValue={setPassword} type="password" placeholder="Введите пароль"/>
            <InputAuthorization value={name} setValue={setName} type="text" placeholder="Введите имя"/>
            <InputAuthorization value={lastname} setValue={setLastname} type="text" placeholder="Введите фамилию"/>
            <button onClick={() => registration(email, password, name, lastname)}>зарегистрироваться</button>
          </div>
        </div>
      </div>
    </Layout>
  )
}

export default Authorization;
