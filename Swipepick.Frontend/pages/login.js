import styles from "../styles/Login.module.css"
import Layout from "../components/layout";
import RegistrationInputs from "../components/login/registrationInputs";
import {useState} from "react";
import ButtonSwitch from "../util/login/buttonSwitch";
import AuthorizationInputs from "../components/login/authorizationInputs";


const Login = () => {
  const [formType, setFormType] = useState("registration")
  return (
    <Layout title="Вход и регистрация">
      <div className={styles.background}>
        <div className={styles.authorization_form}>
          <div className={styles.button_wrapper}>
            <ButtonSwitch formType="authorization" setterFormType={setFormType} text="ВХОД"/>
            <ButtonSwitch formType="registration" setterFormType={setFormType} text="РЕГИСТРАЦИЯ"/>
          </div>
          {formType === "registration" && <RegistrationInputs/>}
          {formType === "authorization" && <AuthorizationInputs/>}
        </div>
      </div>
    </Layout>
  )
}

export default Login;
