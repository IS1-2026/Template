export function RenderCardsClases(clases) {
  return clases.map(c => {

    const nombre = c.nombre ?? "Clase sin nombre";
    const cupo = c.cupo ?? "-";
    const precio = c.precio ?? 0;
    const fecha = c.fecha ?? "Sin fecha";
    const hora = c.hora ?? "Sin hora";

    const prof = c.profesional;
    const profesor = prof
      ? `${prof.nombre} ${prof.apellido}`
      : "Sin profesor";

    const id = c.idClase;

    return `
      <div class="clase-card" id="clase-${id}">
        
        <div class="clase-card-top">

          <div class="clase-header">
            <div>
              <span class="clase-badge">Clase</span>
              <h3 class="clase-nombre">${nombre}</h3>
              <span class="clase-profesor">${profesor}</span>
            </div>
          </div>

          <div class="clase-meta">

            <span class="meta-pill">Cupo: ${cupo}</span>
            <span class="meta-pill">Fecha: ${fecha}</span>
            <span class="meta-pill">Hora: ${hora}</span>

          </div>

        </div>

        <div class="clase-footer">

          <div class="precio-wrap">
            <p class="precio-label">Precio</p>
            <span class="precio-valor">
              $${precio.toLocaleString("es-AR")}
            </span>
          </div>

          <button
            class="btn-inscribirse"
            data-id="${id}"
          >
            Inscribirse
          </button>

        </div>

      </div>
    `;
  }).join("");
}