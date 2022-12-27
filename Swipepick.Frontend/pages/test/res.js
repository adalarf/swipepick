import styles from '../../styles/Home.module.css';



const Res = () => {
    return(
        <div>
            <div className = {styles.res}>Результаты</div>
            <div className={styles.right}>Правильных ответов: 2</div>
            <div className={styles.wrong}>Неправильных ответов: 0</div>
        </div>
    )
}

export default Res;