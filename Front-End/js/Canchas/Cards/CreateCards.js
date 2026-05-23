import { getCanchas } from "../GetCanchas.js";
import { RenderCards } from "./RenderCards.js";
import { abrirModal } from "./Utils/HorarioModal.js";

export async function CreateCards(containerId = "canchas-container") {

  const container = document.getElementById(containerId);

  if (!container) return;

  container.innerHTML = `
    <p style="color: rgba(255,255,255,0.4)">
      Cargando canchas...
    </p>
  `;
  try {

    const canchas = await getCanchas();

    if (!canchas?.length) {

      container.innerHTML = `
        <p style="color: rgba(255,255,255,0.4)">
          No se encontraron canchas.
        </p>
      `;

      return;
    }

    container.innerHTML = RenderCards(canchas);

    document.addEventListener("click", e => {
      const btn = e.target.closest(".btn-reservar");
      if(!btn) return;
      const id = Number(btn.dataset.id);
      const cancha = canchas.find(c => c.idCancha === id);
      if(!cancha) return;
      abrirModal(cancha);
    });
    document.addEventListener("click", e => {
    if(e.target.matches(".cerrar-modal") ||e.target.matches("#modal")) 
    {
    document.querySelector("#modal").classList.remove("active");
    }
    });

  } catch (err) {

    console.error("Error al cargar canchas:", err);

    container.innerHTML = `
      <p style="color: rgba(255,255,255,0.4)">
        Error al cargar las canchas.
      </p>
    `;
  }
}