import Head from "next/head";
import HomeHeader from "./homeHeader";
import HomeFooter from "./homeFooter";

const HomeLayout = ({ children, title = 'Swipepick' }) => {
  return (
    <>
      <Head>
        <title>{title}</title>
      </Head>
      <HomeHeader/>
      {children}
      <HomeFooter/>
    </>
  )
}

export default HomeLayout;
