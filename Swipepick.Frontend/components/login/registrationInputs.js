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
             id="email" labelText="Ваш E-mail" />
      <Input value={password} setValue={setPassword} type="password"
             id="password" labelText="Придумайте пароль" />
      <Input value={name} setValue={setName} type="text"
             id="name" labelText="Ваше имя" />
      <Input value={lastname} setValue={setLastname} type="text"
             id="lastname" labelText="Ваша фамилия" />
      <button type="submit" className={styles.send_button} onClick={() =>
        register(email, password, name, lastname)}>ЗАРЕГИСТРИРОВАТЬСЯ</button>
    </div>
  )
}

export default RegistrationInputs;
