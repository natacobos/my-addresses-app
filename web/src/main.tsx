import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import AddressList from "./AddressList";
import "./index.css";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <AddressList />
  </StrictMode>
);
