import styles from '../../styles/Home.module.css';
import {useState, useEffect} from "react";
import  ReactDOM from 'react-dom';


// function eventhandler(){

//     const useKeyPress = (key) => {
//         const [isKeyPressed, setIsKeyPressed] = useState(false)
//     }

//     const downHandler = ({key}) => {
//         if(key === keyTarget) setIsKeyPressed(true)
//     }

//     const upHandler = ({key}) => {
//         if(key === keyTarget) setIsKeyPressed(false)
//     }

//     useEffect(() => {
//         window.addEventListener('keydown', downHandler)
//         window.addEventListener('keyup', downHandler)

//         return () => {
//             window.removeEventListener('keydown', downHandler)
//             window.removeEventListener('keyup', upHandler)
//         }
//     }, [])
//     return isKeyPressed
// }



// let requestUrl = 'https://localhost:7286/api/user/auth/test'
// function sendRequest(method, url, body = null){
//     return fetch(url).then(response => {
//         return response.json()
//         .then(data => this.setState({value: data}))
//     })
// }

// let value;
// sendRequest('GET', requestUrl)

// alert(value)

// document.addEventListener('keydown', function (event) {
//         alert(`Нажата клавиша ${event.code} (${event.key})`);
//     });

// if (typeof window !== 'undefined') {
//     ReactDOM.render(document.addEventListener('keydown', function (event) {
//             alert(`Нажата клавиша ${event.code} (${event.key})`);
//         }));
// }

//eventhandler('ArrowUp')


const Test = () => {
    const [contacts, setContacts] = useState(null);

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch('https://localhost:7286/api/user/auth/test');
            const data = await response.json();
            setContacts(data);
        }
        fetchData();
    }, []);

    // function onClickfunc(){
    //     alert('a')
    // }

    // document.addEventListener('keydown', function (event) {
    //     alert(`Нажата клавиша ${event.code} (${event.key})`);
    // });

    // if (typeof window !== 'undefined') {
    //     ReactDOM.render(alert(`Нажата клавиша ${event.code} (${event.key})`));
    // }
    useEffect(() => {
        document.addEventListener('keydown', detectKeyDown, true)
    }, [])

    const detectKeyDown = (e) => {
        console.log("Clicked key: ", e.key)
        if(e.key === 'ArrowUp'){
            // console.log("Key Clicker: ArrowUp")
            return(<div>aaaaaaaaaaaaaaaaaa</div>)
        }
    }

    return (
        <div>
            {contacts && [contacts].map(({question, answer}) => (
                <div>
                <div className = {styles.test}>{question}</div>
                <div className = {styles.answerfield}>
                    <div className = {styles.answer}>{answer}</div>
                    <div className = {styles.answer}>Ответ номер 2</div>
                    <div className = {styles.answer}>Ответ номер 3</div>
                    <div className = {styles.answer}>Ответ номер 4</div>
                </div>
                </div>
            ))}
            <button className = {styles.next}>Далее</button>
        </div>
    )
}
export default Test;