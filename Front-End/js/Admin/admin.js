import { getCanchas } from "../Canchas/GetCanchas.js";
import { getTipoCanchas } from "../TipoCancha/GetTipoCancha.js";
import { RenderAdminCards } from "./renderAdminCards.js";
import { RenderTcCards } from "./renderTcCards.js";
import { crearCancha } from "./Modals/crearCancha.js";
import { editarCancha } from "./Modals/editarCancha.js";
import { getProfesionales } from "../Profesionales/getProfesionales.js";
import { RenderProfesionalCards } from "../Profesionales/Cards/renderProfesionalCards.js";
import { abrirModalCrearProfesional } from "./Modals/crearProfesional.js  ";
import { crearTipoCancha } from "./Modals/crearTipoCancha.js";
export function adminPanel(){
const botones = document.querySelectorAll(".sidebar-btn");
const secciones = document.querySelectorAll(".content-section");

botones.forEach((boton, index) => {

  boton.addEventListener("click", async() => {


    botones.forEach(btn => {
      btn.classList.remove("active");
    });

    secciones.forEach(section => {
      section.classList.add("hidden");
    });

    
    boton.classList.add("active");   
    secciones[index].classList.remove("hidden");
    const seccionAct = boton.textContent.trim();;


  if (seccionAct == "Canchas")
  {
  const canchas = await getCanchas();

  const container = document.querySelector("#canchas");

  const contenido = `<div class="section-header">
      <button class="btn-primary" id="btn-crear-cancha">
        + Crear cancha
      </button>
  </div>
    ${RenderAdminCards(canchas)}
  `;

  container.innerHTML = contenido;
  container.querySelector("#btn-crear-cancha")
    .addEventListener("click", crearCancha);

  container.querySelectorAll(".admin-btn-edit")
    .forEach(btn => {
      btn.addEventListener("click", () => {
        const id = Number(btn.dataset.id);
        const cancha = canchas.find(c => c.idCancha === id);
        if (cancha) {
          editarCancha(cancha);
        }
      });

    });
}

    if(seccionAct == "Tipo de canchas")
{
    const tipos = await getTipoCanchas();

    const container = document.querySelector("#tipoCanchas");

    container.innerHTML = `

      <div class="section-header">

        <button 
          class="btn-primary" 
          id="btn-crear-tipo-cancha"
        >
          + Crear tipo de cancha
        </button>

      </div>

      ${RenderTcCards(tipos)}

    `;

    container
      .querySelector("#btn-crear-tipo-cancha")
      .addEventListener("click", () => {
     
        crearTipoCancha();

      });
}
   
   if (seccionAct == "Profesionales") {

  const container = document.querySelector("#profesionales");

  container.innerHTML = `
    
    <div class="section-header">

      <button class="btn-primary" id="btn-crear-profesional">
        + Crear profesional
      </button>

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

  const select = document.querySelector("#tipoProfesional");
  const list = document.querySelector("#profesionales-list");

  async function cargarProfesionales(tipo) {

    try {

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

  await cargarProfesionales(select.value);

  select.addEventListener("change", async () => {

    await cargarProfesionales(select.value);

  });

  container.querySelector("#btn-crear-profesional")
  .addEventListener("click", () => {

    const tipoSeleccionado = select.value;

    abrirModalCrearProfesional(tipoSeleccionado);

  });
}


    if(seccionAct=="Dashboard")
      {
        console.log("AAAA")
      }



  });

});

}

