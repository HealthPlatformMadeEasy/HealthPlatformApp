import { Parallax } from "../components/Tables/Parallax.tsx";
import { Logo } from "../components";

export function TestPage() {
  return (
    <div>
      <div className="h-96" />
      <Logo />
      <Parallax />
      <div className="h-96" />
    </div>
  );
}
