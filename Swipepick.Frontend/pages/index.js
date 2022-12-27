import Layout from "../components/layout";
import HomeMain from "../components/homeMain";
import {Provider} from "react-redux";
import {store} from "../reducers";


const Index =  () => {
  return (
    <Provider store={store}>
      <Layout>
        <HomeMain/>
      </Layout>
    </Provider>
  )
}

export default Index;
