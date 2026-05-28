export function RenderAdminClasesCards(clases) {
  return `
    <div class="admin-clases-grid">

      ${clases.map(c => `

        <div class="admin-card" data-id="${c.idClase}">

          <div class="admin-card-header">

            <div>
              <h3 class="admin-card-title">${c.nombre}</h3>

              <p class="admin-card-subtitle">
              Profesor: ${c.profesional.nombre} ${c.profesional.apellido}
              </p>
            </div>

            <span class="admin-badge">
              Activa
            </span>

          </div>

          <div class="admin-card-info">

            <div class="admin-info-item">
              <span class="admin-info-label">Cupo</span>
              <span class="admin-info-value">${c.cupo}</span>
            </div>

            <div class="admin-info-item">
              <span class="admin-info-label">Precio</span>
              <span class="admin-info-value">$${c.precio}</span>
            </div>

          </div>

          <div class="admin-card-extra">

            <div class="admin-professional-box">
              <span>${c.profesional.correo} | </span>
              <span>${c.profesional.localidad} - ${c.profesional.pais}</span>
            </div>

          </div>

          <div class="admin-card-actions">

            <button class="admin-btn admin-btn-detalles">
              Ver Detalles
            </button>

            <button class="admin-btn admin-btn-delete" data-id="${c.idClase}">
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}