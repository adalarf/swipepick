import styles from "../../styles/Login.module.css";
import ButtonSwitch from "../../util/login/buttonSwitch";
import {useState} from "react";
import RegistrationInputs from "./registrationInputs";
import AuthorizationInputs from "./authorizationInputs";
import Link from "next/link";
import logo from "../../public/logo.svg";
import Image from "next/image";

const LoginForm = () => {
  const [formType, setFormType] = useState("registration")

  return (
    <div className={styles.background}>
      <Link className="" href="/">
        <Image className="img-logo" src={logo} alt="логотип"/>
      </Link>
      <div className={styles.login_form}>
        <div className={styles.button_wrapper}>
          <ButtonSwitch formType="authorization" setterFormType={setFormType} text="ВХОД"/>
          <ButtonSwitch formType="registration" setterFormType={setFormType} text="РЕГИСТРАЦИЯ"/>
        </div>
        {formType === "registration" && <RegistrationInputs/>}
        {formType === "authorization" && <AuthorizationInputs/>}
      </div>
    </div>
  )
}

export default LoginForm;
