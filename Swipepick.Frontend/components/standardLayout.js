import Header from "./header";
import Footer from "./footer";
import Layout from "./layout";

const StandardLayout = ({children}) => {
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
