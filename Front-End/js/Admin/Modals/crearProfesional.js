import { postData } from "../../Global/ApiServices.js";

export function abrirModalCrearProfesional(tipo) {

  const modalExistente = document.querySelector(".modal-overlay");

  if (modalExistente) return;

  const modal = document.createElement("div");

  modal.classList.add("modal-overlay");

  modal.innerHTML = `
  
    <div class="modal-content">

      <div class="modal-header">

        <h2 class="modal-title">
          Crear ${tipo}
        </h2>

        <button class="modal-close">
          ✕
        </button>

      </div>

      <form class="modal-form" id="form-profesional">

        <input 
          type="number"
          min=0
          class="modal-input"
          id="dni"
          placeholder="DNI"
          required
        >

        <input 
          type="text"
          class="modal-input"
          id="nombre"
          placeholder="Nombre"
          required
        >

        <input 
          type="text"
          class="modal-input"
          id="apellido"
          placeholder="Apellido"
          required
        >

        <input 
          type="email"
          class="modal-input"
          id="correo"
          placeholder="Correo"
          required
        >

        <input 
          type="password"
          class="modal-input"
          id="password"
          placeholder="Contraseña"
          required
        >

        <input 
          type="text"
          class="modal-input"
          id="localidad"
          placeholder="Localidad"
          required
        >

        <input 
          type="text"
          class="modal-input"
          id="pais"
          placeholder="País"
          required
        >

        <input 
          type="date"
          class="modal-input"
          id="fechaNac"
          required
        >

        <input 
          type="text"
          class="modal-input"
          id="certificado"
          placeholder="Certificado"
        >

        <div class="modal-actions">

          <button 
            type="button"
            class="btn-cancel"
          >
            Cancelar
          </button>

          <button 
            type="submit"
            class="btn-save"
          >
            Guardar
          </button>

        </div>

      </form>

    </div>
  `;

  document.body.appendChild(modal);

  modal.querySelector(".modal-close")
    .addEventListener("click", () => {
      modal.remove();
    });

  modal.querySelector(".btn-cancel")
    .addEventListener("click", () => {
      modal.remove();
    });

  const form = modal.querySelector("#form-profesional");

  form.addEventListener("submit", async (e) => {

    e.preventDefault();

    try {

      const fecha = document.querySelector("#fechaNac").value;

      const body = {

        dni: Number(document.querySelector("#dni").value),

        nombre: document.querySelector("#nombre").value,

        apellido: document.querySelector("#apellido").value,

        correo: document.querySelector("#correo").value,

        password: document.querySelector("#password").value,

        localidad: document.querySelector("#localidad").value,

        pais: document.querySelector("#pais").value,

        fechaNac: fecha,

        certificado: document.querySelector("#certificado").value
      };

      const endpoint =
        tipo === "Profesor"
          ? "Profesionales/profesores"
          : "Profesionales/entrenadores";

      const profesionalCreado = await postData(endpoint, body);

const grid = document.querySelector(".profesionales-grid");

    if (grid) {

  const nuevaCard = `
  
    <div class="profesional-card">

      <div class="profesional-card-top">

        <div class="profesional-header">

          <div>

            <span class="profesional-badge">
              ${tipo}
            </span>

            <h3 class="profesional-nombre">
              ${profesionalCreado.nombre}
            </h3>

            <p class="profesional-apellido">
              ${profesionalCreado.apellido ?? ""}
            </p>

          </div>

        </div>

        <div class="profesional-meta">

          <span class="meta-pill">
            ${profesionalCreado.localidad ?? "-"}
          </span>

          <span class="meta-pill">
            ${profesionalCreado.pais ?? "-"}
          </span>

          <span class="meta-pill">
            ${profesionalCreado.correo ?? "-"}
          </span>

        </div>

      </div>

      <div class="profesional-footer">

        <span class="estado-activo">
          Activo
        </span>

        <button class="btn-contactar">
          Ver perfil
        </button>

      </div>

    </div>
  `;

  grid.insertAdjacentHTML("afterbegin", nuevaCard);
}

        Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "success",
        title: "Profesional creado con éxito",
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,
        customClass: {
            popup: "toast-golahora toast-popup-success",
            title: "toast-title"
        }
        });

        modal.remove();

    } catch (error) {

      console.error(error);

      Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "error",
                title: "Error al crear profesional",
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