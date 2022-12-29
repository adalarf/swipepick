import styles from "../../styles/Login.module.css";

const ButtonSwitch = ({formType, setterFormType, text}) => {
  return (
    <button className={styles.button_switch} onClick={(event)=> setterFormType(formType)}>{text}</button>
  )
}

export default ButtonSwitch;
