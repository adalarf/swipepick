import Image from "next/image";
import phoneVersion from "../public/phone-version.png"
import video from "../public/video.png"

const HomeMain = () => {
  return (
    <main className="main-main">
      <div className="wrapper">
        <section className="hero">
          <Image className="img-phone-version" src={phoneVersion} alt="мобильная версия картинка"/>
          <div className="main-heading-description">
            <h1 className="main-heading">Веб платформа swipepick</h1>
            <p className="main-description">Веб-сервис для создания тесов  или опросов,
              прохождение котрых реализовано удобными и быстрыми свайпами.
              Хотите создать или пройти опрос или тест прямо сечас?</p>
          </div>
          <ul className="little-navigation">
            <li className="little-navigation-item">
              <a href="#" className="little-navigation-item-link">СОЗДАТЬ</a>
            </li>
            <li className="little-navigation-item">
              <a href="#" className="little-navigation-item-link">ПРОЙТИ</a>
            </li>
          </ul>
        </section>
        <section className="pluses">
          <h2 className="about-heading">swipepick это:</h2>
          <ul className="advantages">
            <li className="advantages-item img-swipe">
              <p>Прохождение тестов с помощью свайпов</p>
            </li>
            <li className="advantages-item img-statistics">
              <p>Подробная статистика теста или опроса</p>
            </li>
            <li className="advantages-item img-qr-code">
              <p>Автоматическое создание qr-кодов</p>
            </li>
            <li className="advantages-item img-interface">
              <p>Удобный и понятный интерфейс</p>
            </li>
            <li className="advantages-item img-comfort">
              <p>Комфортное прохождение на любом устройстве</p>
            </li>
            <li className="advantages-item img-topic">
              <p>Создание тестов или опросов на любую тему</p>
            </li>
          </ul>
        </section>
        <section className="manual">
          <h2 className="manual-heading">Создать тест или опрос? - Легко!</h2>
          <div className="manual-flex-box">
            <Image className="img-video" src={video} />
            <ol className="manual-list">
              <li className="manual-list-item">
                <p>Зарегистрируйтесь на плаформе</p>
              </li>
              <li className="manual-list-item">
                <p>Перейдите в личный кабинет </p>
              </li>
              <li className="manual-list-item">
                <p>Нажмите создать</p>
              </li>
              <li className="manual-list-item">
                <p>Составте тест или опрос</p>
              </li>
              <li className="manual-list-item">
                <p>Получие qr-код и ссылку на прохождение теста</p>
              </li>
            </ol>
          </div>
        </section>
      </div>
    </main>
  )
}

export default HomeMain;
