import Head from "next/head";
import Img from "next/image";
import Link from"next/link";
//import Heading from "../components/Heading";
import styles from "../styles/Home.module.css";
import {useState} from "react";



// const Home = () => (
//   <div>
//     <script>
//       function alerted() {
//         document.querySelector('#test').innerHTML = 'test'
//       }
//     </script>
//     <Head>
//       <title>Home</title>
//     </Head>
//     <div>
//       <div className= {styles.name}>
//         Создать
//       </div>
//       <div className = {styles.types} onClick = 'alerted();'>
//         <Img src = "/test.png" width = {200} height = {200}/>
//         <div id = {styles.test}>Тест</div>
//       </div>
//       <div className = {styles.interv}>
//         <Img src = "/interv.png" width = {200} height = {200}/>
//         <div id = {styles.test}>Опрос</div>
//       </div>
//     </div>
//   </div>
// );

// export default Home;


function Home() {
  const [activeState, setActiveState] = useState(false);
  const [activeState1, setActiveState1] = useState(false);
  function handler(){
    // document.getElementById(`{styles.test}`)
    // return (<div className = {styles.ftypes}>
    //   <Img src = "/test.png" width = {200} height = {200}/>
    //   <div id = {styles.test}>Тест</div>
    // </div>)

    //document.getElementById('types').innerHTML = document.getElementById('ftypes').innerHTML
    setActiveState(prev => !prev); 
  }
  function handler1(){
    // document.getElementById(`{styles.test}`)
    // return (<div className = {styles.ftypes}>
    //   <Img src = "/test.png" width = {200} height = {200}/>
    //   <div id = {styles.test}>Тест</div>
    // </div>)

    //document.getElementById('types').innerHTML = document.getElementById('ftypes').innerHTML
    setActiveState1(prev => !prev); 
  }

  let toggleClass = activeState ? 'active' : ''

  return(
  <div>
    <Head>
      <title>Home</title>
    </Head>
    <div>
      <div className= {styles.name}>
        Создать
      </div>
      <div className = {`${activeState ? styles.types : styles.ftypes}`} onClick = {handler}>
        <Img src = "/test.png" width = {200} height = {200}/>
        <div id = {styles.test}>Тест</div>
      </div>
      <div className = {`${activeState1 ? styles.interv : styles.finterv}`} onClick = {handler1}>
        <Img src = "/interv.png" width = {200} height = {200}/>
        <div id = {styles.test}>Опрос</div>
      </div>
      <div class = {styles.next}>
        <Img src = "/next.png" width = {60} height = {60}/>
        <Link href = "/test" id = {styles.nexttext}>Далее</Link>
      </div>
    </div>
  </div>
  )
}

export default Home;