const Input = ({value, setValue, type, placeholder, id, labelText}) => {
  return (
    <>
      <label htmlFor={id}>{labelText}</label>
      <input id={id} onChange={(event)=> setValue(event.target.value)}
             value={value}
             type={type}
             placeholder={placeholder}/>
    </>
  );
};

export default Input;
