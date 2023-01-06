import styles from "../../styles/Login.module.css";

const Input = ({value, setValue, type, placeholder, id, labelText}) => {
  return (
    <div className={styles.input_wrapper}>
      <label htmlFor={id}>{labelText}</label>
      <input  className={styles.input} id={id} onChange={(event)=> setValue(event.target.value)}
             value={value}
             type={type}/>
    </div>
  );
};

export default Input;
