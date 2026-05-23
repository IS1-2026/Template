import { getHorarios } from "./getHorarios.js";
import { CrearReserva } from "../../../Reserva/PostReserva.js";

const diasSemana = {
  1: "Lunes",
  2: "Martes",
  3: "Miércoles",
  4: "Jueves",
  5: "Viernes",
  6: "Sábado",
  0: "Domingo"
};

function obtenerFechaDeDia(diaSemana) {
  const hoy = new Date();

  const actual = hoy.getDay();

  let diff = diaSemana - actual;

  if (diff < 0) {
    diff += 7;
  }

  const fecha = new Date(hoy);
  fecha.setDate(hoy.getDate() + diff);

  return fecha.toISOString().split("T")[0];
}

export function abrirModal(cancha) {
  const modal = document.querySelector("#modal");

  const diasDisponibles = [
    ...new Set(cancha.disponibilidad.map(d => d.dia))
  ];

  modal.innerHTML = `
    <div class="modal-content">

      <button class="cerrar-modal">X</button>

      <h2>${cancha.nombre}</h2>
      <p>${cancha.tipoCancha.nombre}</p>

      <div class="dias-container">
        ${diasDisponibles.map(dia => `
          <button class="dia-btn" data-dia="${dia}">
            ${diasSemana[dia]}
          </button>
        `).join("")}
      </div>

      <div class="horarios-container">
        <p>Seleccione un día</p>
      </div>

    </div>
  `;

  modal.classList.add("active");
  document.body.classList.add("modal-open");

  const horariosContainer = modal.querySelector(".horarios-container");
  const botonesDias = modal.querySelectorAll(".dia-btn");

  let diaSeleccionadoGlobal = null;
  let fechaSeleccionadaGlobal = null;

  botonesDias.forEach(btn => {
    btn.addEventListener("click", async () => {

      botonesDias.forEach(b => b.classList.remove("active"));
      btn.classList.add("active");

      const dia = Number(btn.dataset.dia);
      diaSeleccionadoGlobal = dia;

      const fecha = obtenerFechaDeDia(dia);
      fechaSeleccionadaGlobal = fecha;
      console.log(fecha)

      horariosContainer.innerHTML = "<p>Cargando horarios...</p>";

      try {
        
        const horarios = await getHorarios(cancha.idCancha, fecha);

        if (!horarios || horarios.length === 0) {
          horariosContainer.innerHTML = "<p>No hay horarios disponibles</p>";
          return;
        }

        horariosContainer.innerHTML = horarios.map(h => `
          <button class="horario-btn" data-id=${h.horarioCanchaId}>
            ${h.horaInicio.slice(0,5)} - ${h.horaFin.slice(0,5)}
          </button>
        `).join("");

        const horariosBtn = horariosContainer.querySelectorAll(".horario-btn");

      
        horariosBtn.forEach(btnHorario => {
          btnHorario.addEventListener("click", () => {
           
            horariosBtn.forEach(b => b.classList.remove("active"));
            btnHorario.classList.add("active");

            const anterior = horariosContainer.querySelector(".reservar-btn");
            if (anterior) anterior.remove();

            const reservarBtn = document.createElement("button");
            reservarBtn.classList.add("reservar-btn");
            reservarBtn.textContent = "Realizar reserva";

            horariosContainer.appendChild(reservarBtn);

            reservarBtn.addEventListener("click", async () => {
              try {
                const dni = Number(localStorage.getItem("dni"));
                const horarioCanchaId = Number(btnHorario.dataset.id);
                console.log(fechaSeleccionadaGlobal);
                await CrearReserva(dni,cancha.idCancha,horarioCanchaId,fechaSeleccionadaGlobal);

                Swal.fire({
                  toast: true,
                  position: "bottom-end",
                  icon: "success",
                  title: "Reserva creada correctamente",
                  timer: 2500,
                  showConfirmButton: false
                });

                setTimeout(() => {
                  window.location.href = "canchas.html";
                }, 2500);

              } catch (error) {
                Swal.fire({
                  toast: true,
                  position: "bottom-end",
                  icon: "error",
                  title: error.message ?? "Error al crear la reserva",
                  timer: 2500,
                  showConfirmButton: false
                });
              }
            });
          });
        });

      } catch (error) {
        horariosContainer.innerHTML = "<p>Error al cargar horarios</p>";
      }
    });
  });

  // cerrar modal
  modal.querySelector(".cerrar-modal").addEventListener("click", () => {
    modal.classList.remove("active");
    document.body.classList.remove("modal-open");
  });
}