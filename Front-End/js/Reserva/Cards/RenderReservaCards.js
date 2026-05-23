export function render(reserva)
{
    const r = reserva.reservaHorarioCanchaResponse;

    const estado = reserva.esValida
        ? { text: "Pagada", class: "estado-pagada" }
        : { text: "Pendiente", class: "estado-pendiente" };

    const card = document.createElement("div");
    card.classList.add("reserva-card");

    card.innerHTML = `
      <div class="reserva-header">

        <div class="reserva-info">

          <span class="reserva-badge">Reserva</span>

          <h3 class="reserva-title">
            Número de reserva - ${reserva.reservaId}
          </h3>

          <span class="reserva-sub">
            DNI ${reserva.dniCliente}
          </span>

          <span class="estado-badge ${estado.class}">
            ${estado.text}
          </span>

        </div>

        <div class="reserva-price">
          $${reserva.total.toLocaleString("es-AR")}
        </div>

      </div>

      <div class="reserva-body">

        <div class="reserva-meta">

          <span class="meta-pill">${r.fecha}</span>
          <span class="meta-pill">${r.horaInicio} - ${r.horaFin}</span>
          <span class="meta-pill">Cancha: ${reserva.nombreCancha}</span>

        </div>

      </div>
    `;

    card.addEventListener("click", () => {
        card.classList.toggle("open");
    });

    return card;
}