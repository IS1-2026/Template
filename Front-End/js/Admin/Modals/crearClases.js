import { postData } from "../../Global/ApiServices.js";
import { getProfesionales } from "../../Profesionales/getProfesionales.js";

export async function crearClase() {

  const modalExistente = document.querySelector(".modal-overlay");
  if (modalExistente) return;

  const profesores = await getProfesionales("Profesor");

  const modal = document.createElement("div");
  modal.classList.add("modal-overlay");

  modal.innerHTML = `
    <div class="modal-content">

      <div class="modal-header">
        <h2>Crear clase</h2>
        <button class="btn-cancel" id="close-modal">X</button>
      </div>

      <div class="modal-body">

        <div class="form-group">
          <label>Nombre</label>
          <input 
            type="text" 
            id="nombre" 
            placeholder="Ej: Clase de funcional"
          >
        </div>

        <div class="form-group">
          <label>Profesor</label>

          <select id="dni">

            <option value="">
              Seleccionar profesor
            </option>

            ${profesores.map(p => `
              <option value="${p.dni}">
                ${p.nombre}
              </option>
            `).join("")}

          </select>

        </div>

        <div class="form-group">
          <label>Cupo</label>
          <input 
            type="number" 
            id="cupo" 
            placeholder="Ej: 15"
          >
        </div>

        <div class="form-group">
          <label>Precio</label>
          <input 
            type="number" 
            id="precio" 
            placeholder="Ej: 3500"
          >
        </div>

        <button class="btn-save" id="btn-guardar">
          Guardar
        </button>

      </div>

    </div>
  `;

  document.body.appendChild(modal);

  modal.querySelector("#close-modal")
    .addEventListener("click", () => {
      modal.remove();
    });

  modal.querySelector("#btn-guardar")
    .addEventListener("click", async () => {

      console.log(profesores)
      const payload = {
            nombre: modal.querySelector("#nombre").value,
            dniProfesor: Number(modal.querySelector("#dni").value),
            cupo: Number(modal.querySelector("#cupo").value),
            precio: Number(modal.querySelector("#precio").value)
            };

      try {

        await postData("Clase", payload);

        modal.remove();

        Swal.fire({
          toast: true,
          position: "bottom-end",
          icon: "success",
          title: "Clase creada correctamente",
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
          title: error.message ?? "Error al crear clase",
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