import Head from "next/head";
import Img from "next/image";
import Link from"next/link";
import styles from "../styles/Home.module.css";

function Params() {

    return(
        <div>
            <Head>
                <title>Params</title>
            </Head>
            <div className= {styles.name}>
                Опции
            </div>
            <div class = {styles.prev}>
                <Img src = "/prev.png" width = {60} height = {60}/>
                <Link href = "/test" id = {styles.nexttext}>Назад</Link>
            </div>
            <div>
                Таймер
            </div>
            <div class = {styles.next}>
                <Img src = "/next.png" width = {60} height = {60}/>
                <Link href = "/params" id = {styles.nexttext}>Создать тест</Link>
            </div>
        </div>
    );
};

export default Params;