import { InsertarCancha } from "../../Canchas/PostCancha.js";


export function crearCancha()
{
  const modalExistente = document.querySelector(".modal-overlay");

  if(modalExistente) return;

  const modal = document.createElement("div");

  modal.classList.add("modal-overlay");

  modal.innerHTML = `

    <div class="modal-content">

      <div class="modal-header">

        <h2>
          Crear cancha
        </h2>

        <button class="modal-close">
          ✕
        </button>

      </div>

      <form id="form-crear-cancha" class="modal-form">

        <!-- NOMBRE -->

        <div class="form-group">

          <label>
            Nombre
          </label>

          <input
            type="text"
            id="nombreCancha"
            placeholder="Cancha Central"
          >

        </div>

        <!-- TIPO -->

        <div class="form-group">

          <label>
            Tipo de cancha
          </label>

          <select id="tipoCancha">

            <option value="1">
              Fútbol 5
            </option>

            <option value="2">
              Fútbol 7
            </option>

            <option value="3">
              Fútbol 11
            </option>

          </select>

        </div>

        <!-- HORARIOS -->

        <div class="form-group">

          <label>
            Horarios
          </label>

          <div id="horarios-container">

          </div>

          <button
            type="button"
            class="btn-primary"
            id="agregar-horario"
          >
            + Agregar horario
          </button>

        </div>


        <button
          type="submit"
          class="btn-primary modal-btn"
        >
          Crear cancha
        </button>

      </form>

    </div>

  `;

  document.body.appendChild(modal);

  document.body.classList.add("modal-open");


  function cerrarModal()
  {
    modal.remove();

    document.body.classList.remove("modal-open");
  }

  modal
    .querySelector(".modal-close")
    .addEventListener("click", cerrarModal);

  modal.addEventListener("click", (e) => {

    if(e.target === modal)
    {
      cerrarModal();
    }

  });

  // AGREGAR HORARIO

  const horariosContainer =modal.querySelector("#horarios-container");

  const agregarHorario =modal.querySelector("#agregar-horario");

  agregarHorario.addEventListener("click", () => {

    const horario = document.createElement("div");

    horario.classList.add("horario-item");

    horario.innerHTML = `
      <select class="dia">

        <option value="1">Lunes</option>
        <option value="2">Martes</option>
        <option value="3">Miércoles</option>
        <option value="4">Jueves</option>
        <option value="5">Viernes</option>
        <option value="6">Sábado</option>
        <option value="0">Domingo</option>

      </select>
      <input type="time" class="horaInicio">
      <input type="time" class="horaFin">
      <button type="button" class="btn-delete-horario">
        ✕
      </button>
    `;

    horariosContainer.appendChild(horario);

    horario.querySelector(".btn-delete-horario").addEventListener("click", () => {
        horario.remove();
    });

  });


  modal.querySelector("#form-crear-cancha").addEventListener("submit", async (e) => {
      e.preventDefault();
      const horarios = [];
     modal.querySelectorAll(".horario-item").forEach(h => {
        const dia = Number(h.querySelector(".dia").value);
        const horaInicio = h.querySelector(".horaInicio").value;
        const horaFin = h.querySelector(".horaFin").value;

        if (!horaInicio || !horaFin) return;

        horarios.push({
            dia,
            horaInicio: horaInicio + ":00",
            horaFin: horaFin + ":00"
        });
    });
       if (horarios.length === 0) {
          
        Swal.fire({
          toast: true,
          position: "bottom-end",
          icon: "error",
          title: "Ingrese al menos un horario",
          showConfirmButton: false,
          timer: 2500,
          timerProgressBar: true,

          customClass: {
              popup: "toast-golahora toast-popup-error",
              title: "toast-title"
          }
          });
        return;
    }

      try
      {
        const idTipoCancha=Number(modal.querySelector("#tipoCancha").value)
     
        const nombre = modal.querySelector("#nombreCancha").value;
        
        await InsertarCancha(idTipoCancha,nombre,horarios);

             Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Cancha creada correctamente",
                showConfirmButton: false,
                timer: 2500,
                timerProgressBar: true,

                customClass: {
                    popup: "toast-golahora toast-popup-success",
                    title: "toast-title"
                }
                
            });
            setTimeout(() => {
                location.reload();
                }, 2500);
      }
      catch(error)
      {
          Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "error",
                title: error.message ?? "Error al crear la cancha",
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