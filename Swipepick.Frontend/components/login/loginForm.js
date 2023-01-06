import styles from "../../styles/Login.module.css";
import ButtonSwitch from "../../util/login/buttonSwitch";
import {useState} from "react";
import RegistrationInputs from "./registrationInputs";
import AuthorizationInputs from "./authorizationInputs";
import logo2 from "../../public/logo2.svg";
import Image from "next/image";
import Link from "next/link";
import Logo from "../../util/logo";
import {useRouter} from "next/router";

const LoginForm = () => {
  const [formType, setFormType] = useState("registration")

  return (
    <div className={styles.background}>
      <div className={styles.form_wrapper}>
        <Logo className={styles.logo} src={logo2}/>
        <div className={styles.login_form}>
          <div className={styles.button_wrapper}>
            <ButtonSwitch formTypeValue="authorization" setterFormType={setFormType} formType={formType} text="ВХОД"/>
            <ButtonSwitch formTypeValue="registration" setterFormType={setFormType} formType={formType} text="РЕГИСТРАЦИЯ"/>
          </div>
          {formType === "registration" && <RegistrationInputs/>}
          {formType === "authorization" && <AuthorizationInputs/>}
        </div>
      </div>
    </div>
  )
}

export default LoginForm;
