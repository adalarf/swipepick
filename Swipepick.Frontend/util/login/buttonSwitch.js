import styles from "../../styles/Login.module.css";

const ButtonSwitch = ({formTypeValue, setterFormType, text, formType}) => {
  return (
    <button className={formTypeValue === formType ?
      styles.button_switch_activated : styles.button_switch}
            onClick={() => setterFormType(formTypeValue)}>{text}</button>
  )
}

export default ButtonSwitch;
