import Image from "next/image";
import Link from "next/link";

const Logo = ({className, src}) => {
  return (
    <Link className={className} href="/">
      <Image src={src} alt="logo"/>
    </Link>
  )
}

export default Logo;
