import { CreateCards } from "./js/Canchas/Cards/CreateCards.js";
import { crearCancha } from "./js/Canchas/CrearCancha/crearCancha.js";
import { crearTipoCancha } from "./js/TipoCancha/CrearTipoCancha.js/crearTipoCancha.js";
import { actualizarNavbar } from "./js/Global/NavBar/ActNavbar.js";
document.addEventListener("DOMContentLoaded", () => {
    actualizarNavbar();
  const page = window.location.pathname.split("/").pop();

  if (page === "canchas.html") {
    CreateCards();
  }
   if (page === "admin.html") {
    CreateCards();
    crearCancha();
    crearTipoCancha();
  }
});