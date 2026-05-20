import { getCanchas } from "./GetCanchas.js";
import { RenderCards } from "./RenderCards.js";

const selectedHorarios = {};

export async function CreateCards(containerId = "canchas-container") {
  const container = document.getElementById(containerId);
  if (!container) return;

  container.innerHTML = `<p style="color: rgba(255,255,255,0.4)">Cargando canchas...</p>`;

  try {
    const canchas = await getCanchas();

    if (!canchas?.length) {
      container.innerHTML = `<p style="color: rgba(255,255,255,0.4)">No se encontraron canchas.</p>`;
      return;
    }

    container.innerHTML = RenderCards(canchas);

    container.querySelectorAll(".reservar-btn").forEach(btn => {
      btn.addEventListener("click", () => {
        const id = btn.dataset.id;
        const horario = selectedHorarios[id] ?? null;
        reservar(id, horario);
      });
    });

  } catch (err) {
    console.error("Error al cargar canchas:", err);
    container.innerHTML = `<p style="color: rgba(255,255,255,0.4)">Error al cargar las canchas.</p>`;
  }
}

window.toggleHorario = function(chip) {
  const horario = chip.dataset.horario;
  const id = chip.dataset.cancha;

  document.querySelectorAll(`.horario-chip[data-cancha="${id}"]`).forEach(c => {
    c.classList.remove("selected");
  });

  if (selectedHorarios[id] === horario) {
    selectedHorarios[id] = null;
  } else {
    selectedHorarios[id] = horario;
    chip.classList.add("selected");
  }
};

function reservar(id, horario) {
  console.log(`Reservando cancha ${id} para las ${horario ?? "horario no seleccionado"}`);
  // Tu lógica de reserva acá
}