import styles from '../../styles/Home.module.css';
import {useState, useEffect} from "react";
import  ReactDOM from 'react-dom';




const Test1 = () => {
    const [activeState, setActiveState] = useState(false);
    function handler(){
      // document.getElementById(`{styles.test}`)
      // return (<div className = {styles.ftypes}>
      //   <Img src = "/test.png" width = {200} height = {200}/>
      //   <div id = {styles.test}>Тест</div>
      // </div>)
  
      //document.getElementById('types').innerHTML = document.getElementById('ftypes').innerHTML
      setActiveState(prev => !prev);
    } 

    return (
        <div>
                <div>
                <div className = {styles.test}>Кто главный герой романа "Евгений Онегин"</div>
                <div className = {styles.answerfield}>
                    <div className = {`${activeState ? styles.fanswer : styles.answer}`} onClick = {handler}>Евгений Онегин</div>
                    <div className = {styles.answer}>Татьяна Ларина</div>
                    <div className = {styles.answer}>Владимир Ленский</div>
                    <div className = {styles.answer}>Ольга Ларина</div>
                </div>
                </div>
            <a href = "../test/test2"><button className = {styles.next} >Далее</button></a>
        </div>
    )
    
}

export default Test1;