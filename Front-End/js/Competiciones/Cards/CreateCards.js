import { getCompeticiones } from "../GetCompeticiones.js";
import { RenderCompetitionCards } from "./RenderCards.js";
import { RealizarInscripcion } from "../../Inscripciones/crearInscripcion.js";

let competicionesData = []; 

export async function CreateCompetitionCards(containerId = "competitions-container") {

  const container = document.getElementById(containerId);
  if (!container) return;

  container.innerHTML = `
    <p style="color: rgba(255,255,255,0.4)">
      Cargando competiciones...
    </p>
  `;

  try {

    competicionesData = await getCompeticiones();

    if (!competicionesData?.length) {
      container.innerHTML = `
        <p style="color: rgba(255,255,255,0.4)">
          No se encontraron competiciones.
        </p>
      `;
      return;
    }

    container.innerHTML = RenderCompetitionCards(competicionesData);

    container.onclick = async (e) => {

      const btn = e.target.closest(".btn-inscribirse");
      if (!btn) return;

      const idAct = Number(btn.dataset.id);
      const nroAct = Number(btn.dataset.tipo);
      const dni = Number(localStorage.getItem("dni"));

      try {

        await RealizarInscripcion(dni, idAct, nroAct);

        const comp = competicionesData.find(
          c => c.competenciaId === idAct
        );

        if (comp) {
          comp.cupos -= 1;

          if (comp.cupos < 0) comp.cupos = 0;

          container.innerHTML = RenderCompetitionCards(competicionesData);
        }

      } catch (err) {
        console.error(err);
      }
    };

  } catch (err) {
    console.error(err);

    container.innerHTML = `
      <p style="color: rgba(255,255,255,0.4)">
        Error al cargar las competiciones.
      </p>
    `;
  }
}