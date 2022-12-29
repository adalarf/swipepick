import Header from "./header";
import Footer from "./footer";
import Layout from "./layout";

const StandardLayout = ({ children, title = 'Swipepick' }) => {
  return (
    <>
      <Layout>
        <Header />
          {children}
        <Footer />
      </Layout>
    </>
  )
}

export default StandardLayout;
