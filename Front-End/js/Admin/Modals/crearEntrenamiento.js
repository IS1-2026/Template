import { postData } from "../../Global/ApiServices.js";
import { getProfesionales } from "../../Profesionales/getProfesionales.js";

export async function crearEntrenamiento() {

  const modalExistente = document.querySelector(".modal-overlay");
  if (modalExistente) return;

  const entrenadores = await getProfesionales("Entrenador");

  const modal = document.createElement("div");
  modal.classList.add("modal-overlay");

  modal.innerHTML = `
    <div class="modal-content">

      <div class="modal-header">
        <h2>Crear entrenamiento</h2>
        <button class="btn-cancel" id="close-modal">X</button>
      </div>

      <div class="modal-body">

        <div class="form-group">
          <label>Nombre</label>
          <input type="text" id="nombre" placeholder="Ej: Entrenamiento fútbol">
        </div>

        <div class="form-group">
          <label>Entrenador</label>
          <select id="dni">
            <option value="">Seleccionar entrenador</option>
            ${entrenadores.map(e => `
              <option value="${e.dni}">
                ${e.nombre}
              </option>
            `).join("")}
          </select>
        </div>

        <div class="form-group">
          <label>Cupo</label>
          <input type="number" id="cupo" placeholder="Ej: 20">
        </div>

        <div class="form-group">
          <label>Precio</label>
          <input type="number" id="precio" placeholder="Ej: 5000">
        </div>

        <button class="btn-save " id="btn-guardar">
          Guardar
        </button>

      </div>

    </div>
  `;

  document.body.appendChild(modal);

  modal.querySelector("#close-modal").addEventListener("click", () => {
    modal.remove();
  });

  modal.querySelector("#btn-guardar").addEventListener("click", async () => {

    const dniSeleccionado = modal.querySelector("#dni").value;

    const payload = {
      nombre: modal.querySelector("#nombre").value,
      dni_Entrenador: Number(dniSeleccionado),
      cupo: Number(modal.querySelector("#cupo").value),
      precio: Number(modal.querySelector("#precio").value)
    };

    try {

      await postData("Entrenamiento",payload);

      modal.remove();

      Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "success",
        title: "Entrenamiento creado correctamente",
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,
        customClass: {
          popup: "toast-golahora toast-popup-success",
          title: "toast-title"
        }
      });
      setTimeout(() => {
          window.location.reload();
        }, 2500);

    } catch (error) {

      Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "error",
        title: "Error al crear entrenamiento",
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,
        customClass: {
         popup: "toast-golahora toast-popup-error",
         title: "toast-title"
        }
      });

    }

  });

}