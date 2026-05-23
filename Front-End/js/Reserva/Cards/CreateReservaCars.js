import { getReservas } from "../GetReservas.js";
import {render} from "./RenderReservaCards.js";
export async function createReservaCard() {
    const dni = localStorage.getItem("dni");
    const reservas = await getReservas(Number(dni));

    if (!reservas || reservas.length === 0) {
    container.innerHTML = "<p>No tenés reservas</p>";
    return;
    }    

    const container = document.getElementById("reservasContainer");
    container.innerHTML = "";

    reservas.forEach(r => {
        const card = render(r);
        container.appendChild(card);
    });
   
}