import styles from "../../styles/Login.module.css";
import Input from "../../util/login/input";
import {register} from "../../api/register";
import {useState} from "react";

const RegistrationInputs = () => {
  const [email, setEmail] = useState("")
  const [password, setPassword] = useState("")
  const [name, setName] = useState("")
  const [lastname, setLastname] = useState("")

  return (
    <div className={styles.registration_inputs}>
      <Input value={email} setValue={setEmail} type="text"
             placeholder="Введите email" id="email" labelText="Ваш E-mail" />
      <Input value={password} setValue={setPassword} type="password"
             placeholder="Введите пароль" id="password" labelText="Придумайте пароль" />
      <Input value={name} setValue={setName} type="text"
             placeholder="Введите имя" id="name" labelText="Ваше имя" />
      <Input value={lastname} setValue={setLastname} type="text"
             placeholder="Придумайте пароль" id="lastname" labelText="Ваша фамилия" />
      <button onClick={() => register(email, password, name, lastname)}>ЗАРЕГИСТРИРОВАТЬСЯ</button>
    </div>
  )
}

export default RegistrationInputs;
