export function RenderCardsEntrenamientos(entrenamientos) {
  return entrenamientos.map(e => {

    const nombre = e.nombre ?? "Entrenamiento sin nombre";
    const cupo = e.cupo ?? "-";
    const precio = e.precio ?? 0;

    const prof = e.profesional;
    const profesor = prof
      ? `${prof.nombre} ${prof.apellido}`
      : "Sin profesor";

    const id = e.id_Entrenamiento;

    return `
      <div class="entrenamiento-card" id="entrenamiento-${id}">

        <div class="entrenamiento-card-top">

          <div class="entrenamiento-header">

            <div>
              <span class="entrenamiento-badge">Entrenamiento</span>
              <h3 class="entrenamiento-nombre">${nombre}</h3>
              <span class="entrenamiento-profesor">${profesor}</span>
            </div>

          </div>

          <div class="entrenamiento-meta">
            <span class="meta-pill">Cupo: ${cupo}</span>
          </div>

        </div>

        <div class="entrenamiento-footer">

          <div class="precio-wrap">
            <p class="precio-label">Precio</p>
            <span class="precio-valor">
              $${precio.toLocaleString("es-AR")}
            </span>
          </div>

          <button
            class="btn-inscribirse-entrenamiento"
            data-id="${id}"
          >
            Inscribirse
          </button>

        </div>

      </div>
    `;
  }).join("");
}