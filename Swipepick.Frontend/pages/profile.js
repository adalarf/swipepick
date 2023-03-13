import {logout} from "../reducers/userReducer";
import {useDispatch, useSelector} from "react-redux";
import logo2 from "../public/logo2.svg";
import Logo from "../util/logo";
import Layout from "../components/layout";
import {useEffect} from "react";
import {autoLogin} from "../api/autoLogin";
import styles from "../styles/Profile.module.css";
import user from "../public/user.webp";
import settings from "../public/settings.png";
import delete_img from "../public/delete.png";
import Image from "next/image";


const Profile = () => {
  const dispatch = useDispatch()
  const isAuth = useSelector(state => state.user.isAuth);
  useEffect(() => {dispatch(autoLogin())})

  return (
    <Layout title="Личный кабинет">
      <div className={styles.logo}><Logo href="/" src={logo2}/></div>
      {/* <button onClick={() => dispatch(logout())}>ВЫЙТИ</button>
      {isAuth ? <p>ok</p> : <p>not</p>} */}
      <div className={styles.menu}></div>
      <Image src = {user} className = {styles.user}></Image>
      <div className={styles.tests_and_polls}>
        <div className={styles.tests}>тесты</div>
        <div className={styles.polls}>опросы</div>
      </div>
      <div className={styles.plus}>+</div>
      <div className={styles.answer_types}>
        <div className={styles.answer_type}>верные</div>
        <div className={styles.answer_type}>ошибки</div>
        <div className={styles.answer_type} id = {styles.new}>новые</div>
        <div className={styles.answer_type}>старые</div>
      </div>
      <div className={styles.answers}>
        <div className={styles.answer}>
          <div className={styles.name}>Евгений Онегин</div>
          <div className={styles.code}>S8W5</div>
          <div className={styles.date}>10.03.2023</div>
          <Image src={settings} className={styles.settings}></Image>
          <Image src={delete_img} className={styles.delete}></Image>
          <div className={styles.columns}></div>
        </div>
        <div className={styles.answer}>
        <div className={styles.name}>Квадратные уравнения</div>
          <div className={styles.code}>3000</div>
          <div className={styles.date}>28.02.2023</div>
          <Image src={settings} className={styles.settings}></Image>
          <Image src={delete_img} className={styles.delete}></Image>
          <div className={styles.columns}></div>
        </div>
      </div>
    </Layout>
  )

}

export default Profile
