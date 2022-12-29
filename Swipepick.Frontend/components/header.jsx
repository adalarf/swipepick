import Image from "next/image";
import logo from "../public/logo.svg"
import entrance from "../public/entrance.svg"
import Link from "next/link";

const Header = () => {
  return (
    <header className="main-header">
      <div className="wrapper">
        <nav className="main-nav">
          <a className="img-logo-nav" href="#">
            <Image className="img-logo" src={logo} Width="241px" Height="48px" />
          </a>
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
              <Link className="authorization" href="login">ВОЙТИ</Link>
            </li>
          </ul>
        </nav>
      </div>
    </header>
  )

}

export default Header;
