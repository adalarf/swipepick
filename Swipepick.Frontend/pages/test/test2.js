import styles from '../../styles/Home.module.css';
import {useState, useEffect} from "react";
import  ReactDOM from 'react-dom';



const Test1 = () => {
    const [activeState, setActiveState] = useState(false);
  function handler1(){
    // document.getElementById(`{styles.test}`)
    // return (<div className = {styles.ftypes}>
    //   <Img src = "/test.png" width = {200} height = {200}/>
    //   <div id = {styles.test}>Тест</div>
    // </div>)

    //document.getElementById('types').innerHTML = document.getElementById('ftypes').innerHTML
    setActiveState(prev => !prev); 
  }

  let toggleClass = activeState ? 'active' : ''
    

    return (
        <div>

                <div>
                <div className = {styles.test1}>Кто написал роман "Евгений Онегин"</div>
                <div className = {styles.answerfield1}>
                    <div className = {styles.answer1}>Гоголь Николай Васильевич</div>
                    <div className = {styles.answer1}>Толстой Лев Николаевич</div>
                    <div className = {`${activeState ? styles.fanswer1 : styles.answer1}`} onClick = {handler1}>Александр Сергеевич Пушкин</div>
                    <div className = {styles.answer1}>Антон Павлович Чехов</div>
                </div>
                </div>
            <a href = "../test/res"><button className = {styles.next}>Далее</button></a>
            <a href = "../test/test1"><button className={styles.prev}>Назад</button></a>
        </div>
    )
}
export default Test1;