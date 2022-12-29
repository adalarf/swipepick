const InputAuthorization = ({value, setValue, type, placeholder}) => {
  return (
    <input onChange={(event)=> setValue(event.target.value)}
           value={value}
           type={type}
           placeholder={placeholder}/>
  );
};

export default InputAuthorization;
