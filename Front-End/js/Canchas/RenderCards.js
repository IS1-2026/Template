export function RenderCards(canchas) {
  return canchas.map(c => {
    const tipo = c.tipoCancha?.nombre ?? "Sin tipo";
    const superficie = c.tipoCancha?.superficie ?? "-";
    const precio = c.tipoCancha?.precio ?? 0;
    const capacidad = c.tipoCancha?.capacidad ?? "-";
    const duracion = c.tipoCancha?.duracion ?? 1;
    const disponibilidad = c.disponibilidad ?? [];
    const id = c.idCancha;
    const disponible = disponibilidad.length > 0;

    const horarios = disponibilidad.map(h => `
      <span class="horario-chip" data-horario="${h}" data-cancha="${id}" onclick="toggleHorario(this)">
        ${h.slice(0, 5)}
      </span>
    `).join("");

    return `
      <div class="cancha-card" id="card-${id}">
        <div class="cancha-card-top">
          <div class="cancha-header">
            <div>
              <span class="cancha-badge">${tipo}</span>
              <h3 class="cancha-numero">${tipo}</h3>
            </div>
            <div class="field-icon">
              <svg width="22" height="22" viewBox="0 0 24 24" fill="none" stroke="#4ade80" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round">
                <rect x="2" y="4" width="20" height="16" rx="2"/>
                <line x1="12" y1="4" x2="12" y2="20"/>
                <circle cx="12" cy="12" r="3"/>
              </svg>
            </div>
          </div>

          <div class="cancha-meta">
            <span class="meta-pill">
              <svg width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="3" width="18" height="18" rx="2"/></svg>
              ${superficie} m²
            </span>
            <span class="meta-pill">
              <svg width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="8" r="4"/><path d="M4 20c0-4 3.6-7 8-7s8 3 8 7"/></svg>
              ${capacidad} jugadores
            </span>
            <span class="meta-pill">
              <svg width="12" height="12" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><circle cx="12" cy="12" r="9"/><path d="M12 7v5l3 3"/></svg>
              ${duracion}h por turno
            </span>
            ${disponible
              ? `<span class="status-disponible"><span class="dot"></span>Disponible</span>`
              : `<span class="status-nodisponible">✖ No disponible</span>`
            }
          </div>
        </div>

        ${disponible ? `
        <div class="horarios-section">
          <p class="horarios-label">Horarios disponibles</p>
          <div class="horarios-grid">${horarios}</div>
        </div>` : ""}

        <div class="cancha-footer">
          <div class="precio-wrap">
            <p class="precio-label">Precio por hora</p>
            <span class="precio-valor">$${precio.toLocaleString("es-AR")}</span>
            
          </div>
          ${disponible ? `
            <button class="btn-reservar reservar-btn" data-id="${id}">
              <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5" stroke-linecap="round">
                <path d="M8 2v4M16 2v4M3 10h18M5 4h14a2 2 0 0 1 2 2v14a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V6a2 2 0 0 1 2-2z"/>
              </svg>
              Reservar
            </button>` : ""
          }
        </div>
      </div>
    `;
  }).join("");
}