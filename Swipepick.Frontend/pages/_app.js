import "/styles/globals.css"
import {Provider, useDispatch} from "react-redux";
import {store} from "../reducers";
import {useEffect} from "react";
import {autoLogin} from "../api/autoLogin";


const MyApp = ({ Component, pageProps }) => {
  return (
    <Provider store={store}>
      <Component {...pageProps} />
    </Provider>
  )
}

export default MyApp
