import { CreateCards } from "./js/Canchas/CreateCards.js";

document.addEventListener("DOMContentLoaded", () => {
  const page = window.location.pathname.split("/").pop();

  if (page === "canchas.html") {
    CreateCards();
  }
});