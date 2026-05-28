export function RenderAdminCards(canchas) {

  if (!Array.isArray(canchas) || canchas.length === 0) {

    return `
      <p style="color: rgba(255,255,255,0.4)">
        No hay canchas disponibles.
      </p>
    `;
  }

  return `
    <div class="admin-clases-grid">

      ${canchas.map(c => `

        <div 
          class="admin-card"
          data-id="${c.idCancha}"
        >

          <div class="admin-card-header">

            <div>

              <h3 class="admin-card-title">
                ${c.nombre}
              </h3>

              <p class="admin-card-subtitle">
                ${c.tipoCancha.nombre}
              </p>

            </div>

            <span class="admin-badge">
              Activa
            </span>

          </div>

          <div class="admin-card-info">

            <div class="admin-info-item">

              <span class="admin-info-label">
                Superficie
              </span>

              <span class="admin-info-value">
                ${c.tipoCancha.superficie}
              </span>

            </div>

            <div class="admin-info-item">

              <span class="admin-info-label">
                Capacidad
              </span>

              <span class="admin-info-value">
                ${c.tipoCancha.capacidad}
              </span>

            </div>

          </div>

          <div class="admin-card-extra">

            <div class="admin-professional-box">

              <span>
                Precio por turno
              </span>

              <span>
                $${c.tipoCancha.precio}
              </span>

            </div>

          </div>

          <div class="admin-card-actions">

            <button 
              class="admin-btn admin-btn-edit"
              data-id="${c.idCancha}"
            >
              Editar
            </button>

            <button 
              class="admin-btn admin-btn-delete"
              data-id="${c.idCancha}"
            >
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}