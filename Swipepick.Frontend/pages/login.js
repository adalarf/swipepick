import styles from "../styles/Login.module.css"
import Layout from "../components/layout";
import RegistrationInputs from "../components/login/registrationInputs";
import {useState} from "react";
import ButtonSwitch from "../util/login/buttonSwitch";
import AuthorizationInputs from "../components/login/authorizationInputs";
import LoginForm from "../components/login/loginForm";


const Login = () => {
  return (
    <Layout title="Вход и регистрация">
      <LoginForm/>
    </Layout>
  )
}

export default Login;
