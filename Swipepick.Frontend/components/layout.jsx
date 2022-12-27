import Head from "next/head";
import HomeHeader from "./header";
import Footer from "./footer";

const Layout = ({ children, title = 'Swipepick' }) => {
  return (
    <>
      <Head>
        <title>{title}</title>
      </Head>
      <HomeHeader />
      {children}
      <Footer />
    </>
  )
}

export default Layout;
