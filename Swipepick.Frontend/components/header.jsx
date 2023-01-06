import Image from "next/image";
import logo from "../public/logo.svg"
import Link from "next/link";
import {useSelector} from "react-redux";
import Logo from "../util/logo";

const Header = () => {
  const isAuth = useSelector(state => state.user.isAuth);

  return (
    <header className="main-header">
      <div className="wrapper">
        <nav className="main-nav">
          <Logo src={logo}/>
          <ul className="site-navigation">
            <li className="site-navigation-item">
              <a href="#">СОЗДАТЬ</a>
            </li>
            <li className="site-navigation-item">
              <a href="#">ПРОЙТИ</a>
            </li>
            <li className="site-navigation-item">
              <a href="#">О НАС</a>
            </li>
            <li className="site-navigation-item">
              {isAuth ? <Link className="authorization" href="profile">ПРОФИЛЬ</Link> :
                <Link className="authorization" href="login">ВОЙТИ</Link>}
            </li>
          </ul>
        </nav>
      </div>
    </header>
  )

}

export default Header;
