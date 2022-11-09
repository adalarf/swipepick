import Head from "next/head";
import Img from "next/image";
import Link from"next/link";
//import Heading from "../components/Heading";
import styles from "../styles/Home.module.css";

function Test() {

    return(
        <div>
            <Head>
                <title>Test</title>
            </Head>
            <div className= {styles.name}>
                Создать
            </div>
            <div className = {styles.ques}>
                <input id = {styles.textque} placeholder="Введите свой вопрос"/>
                <input id = {styles.answ}placeholder="Введите ответ"/>
            </div>
            <div class = {styles.prev}>
                <Img src = "/prev.png" width = {60} height = {60}/>
                <Link href = "/" id = {styles.nexttext}>Назад</Link>
            </div>
            <div class = {styles.next}>
                <Img src = "/next.png" width = {60} height = {60}/>
                <Link href = "/params" id = {styles.nexttext}>Далее</Link>
            </div>
        </div>
    )
}

export default Test;