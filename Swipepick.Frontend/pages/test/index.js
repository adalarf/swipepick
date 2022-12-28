import styles from '../../styles/Home.module.css';
import {useState, useEffect} from "react";
import  ReactDOM from 'react-dom';


const Test = () => {
    const [contacts, setContacts] = useState(null);


    const formData = new FormData();
    formData.append("grant_type", "password");
    formData.append("email", "user@example.com");
    formData.append("password", "string");

    useEffect(() => {
        const fetchData = async () => {
            const response = await fetch('https://localhost:7286/api/user/auth/login', {
                method: 'POST',
                headers: {"Accept": "application/json"},
                body: formData
            });
            const data = await response.json();
            setContacts(data);
        }
        fetchData();
    }, []);


    // useEffect(() => {
    //     document.addEventListener('keydown', detectKeyDown, true)
    // }, [])

    // const detectKeyDown = (e) => {
    //     console.log("Clicked key: ", e.key)
    //     if(e.key === 'ArrowUp'){
    //         // console.log("Key Clicker: ArrowUp")
    //         return(<div>aaaaaaaaaaaaaaaaaa</div>)
    //     }
    // }


    // var tokenKey = "accessToken";


    // async function getTokenAsync() {

    //     // получаем данные формы и фомируем объект для отправки
    //     const formData = new FormData();
    //     //formData.append("grant_type", "password");
    //     formData.append("email", "user@example.com");
    //     formData.append("password", "string");

    //     // отправляет запрос и получаем ответ
    //     const response = await fetch("https://localhost:7286/api/user/auth/login", {
    //         method: "POST",
    //         headers: {"Accept": "application/json"},
    //         body: formData
    //     });
    //     // получаем данные
    //     const data = await response.json();

    //     // если запрос прошел нормально
    //     if (response.ok === true) {

    //         // изменяем содержимое и видимость блоков на странице
    //         document.getElementById("userName").innerText = data.username;
    //         document.getElementById("userInfo").style.display = "block";
    //         document.getElementById("loginForm").style.display = "none";
    //         // сохраняем в хранилище sessionStorage токен доступа
    //         sessionStorage.setItem(tokenKey, data.access_token);
    //         console.log(data.access_token);
    //         console.log('a')
    //      }
    //     else {
    //         // если произошла ошибка, из errorText получаем текст ошибки
    //         console.log("Error: ", response.status, data.errorText);
    //     }
    // };
    // // отправка запроса к контроллеру ValuesController
    // async function getData(url) {
    //     const token = sessionStorage.getItem(tokenKey);

    //     const response = await fetch(url, {
    //         method: "GET",
    //         headers: {
    //             "Accept": "application/json",
    //             "Authorization": "Bearer " + token  // передача токена в заголовке
    //         }
    //     });
    //     if (response.ok === true) {

    //         const data = await response.json();
    //         alert(data)
    //     }
    //     else
    //         console.log("Status: ", response.status);
    // };

    // getTokenAsync();



    return (
        <div>
            <div>
            <div className = {styles.test}>Вопрос</div>
            <div className = {styles.answerfield}>
                <div className = {styles.answer}>Ответ номер 1</div>
                <div className = {styles.answer}>Ответ номер 2</div>
                <div className = {styles.answer}>Ответ номер 3</div>
                <div className = {styles.answer}>Ответ номер 4</div>
            </div>
            </div>
            <button className = {styles.next}>Далее</button>
        </div>
    )

    // return (
    //     <div>
    //         {contacts && [contacts].map(({question, answer}) => (
    //             <div>
    //             <div className = {styles.test}>{question}</div>
    //             <div className = {styles.answerfield}>
    //                 <div className = {styles.answer}>{answer}</div>
    //                 <div className = {styles.answer}>Ответ номер 2</div>
    //                 <div className = {styles.answer}>Ответ номер 3</div>
    //                 <div className = {styles.answer}>Ответ номер 4</div>
    //             </div>
    //             </div>
    //         ))}
    //         <button className = {styles.next}>Далее</button>
    //     </div>
    // )
}
export default Test;
