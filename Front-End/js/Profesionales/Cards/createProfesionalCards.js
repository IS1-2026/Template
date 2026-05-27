import { getProfesionales } from "../../Profesionales/getProfesionales.js";
import { RenderProfesionalCards } from "../Cards/renderProfesionalCards.js";

export async function createProfesionalCards(containerId = "profesionales") {

  const container = document.getElementById(containerId);

  if (!container) return;

  container.innerHTML = `
    <div class="section-header">

      <select id="tipoProfesional" class="select-profesional">
        <option value="Profesor">Profesor</option>
        <option value="Entrenador">Entrenador</option>
      </select>

    </div>

    <div id="profesionales-list">
      <p style="color: rgba(255,255,255,0.4)">
        Cargando profesionales...
      </p>
    </div>
  `;

  const select = document.getElementById("tipoProfesional");
  const list = document.getElementById("profesionales-list");

  async function loadProfesionales(tipo) {

    try {

      list.innerHTML = `
        <p style="color: rgba(255,255,255,0.4)">
          Cargando...
        </p>
      `;

      const profesionales = await getProfesionales(tipo);

      list.innerHTML = RenderProfesionalCards(profesionales);

    } catch (error) {

      console.error(error);

      list.innerHTML = `
        <p style="color:red;">
          Error al cargar profesionales
        </p>
      `;
    }
  }

  await loadProfesionales(select.value);

  select.addEventListener("change", async () => {

    await loadProfesionales(select.value);

  });
}