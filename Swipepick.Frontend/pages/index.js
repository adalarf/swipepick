import Head from 'next/head'
import Image from 'next/image'
import styles from '../styles/Home.module.css'
import HomeLayout from "../components/homeLayout";
import HomeMain from "../components/homeMain";


const Index =  () => {
  return (
    <HomeLayout>
      <HomeMain/>
    </HomeLayout>
  )
}

export default Index;
