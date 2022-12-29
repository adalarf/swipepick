import Head from "next/head";

const Layout = ({ children, title = 'Swipepick' }) => {
  return (
    <>
      <Head>
        <title>{title}</title>
      </Head>
      {children}
    </>
  )
}

export default Layout;
