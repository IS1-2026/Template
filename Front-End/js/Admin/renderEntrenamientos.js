export function RenderAdminEntrenamientoCards(entrenamientos) {

  if (!Array.isArray(entrenamientos) || entrenamientos.length === 0) {
    return `
      <p style="color: rgba(255,255,255,0.4)">
        No hay entrenamientos disponibles.
      </p>
    `;
  }

  return `
    <div class="admin-entrenamientos-grid">

      ${entrenamientos.map(e => `

        <div class="admin-card"data-id="${e.id_Entrenamiento}">

          <div class="admin-card-header">

            <div>
              <h3 class="admin-card-title">
                ${e.nombre}
              </h3>

              <p class="admin-card-subtitle">
                Profesor: ${e.profesional?.nombre ?? ""} ${e.profesional?.apellido ?? ""}
              </p>
            </div>

            <span class="admin-badge">
              Activo
            </span>

          </div>

          <div class="admin-card-info">

            <div class="admin-info-item">
              <span class="admin-info-label">Cupo</span>
              <span class="admin-info-value">${e.cupo}</span>
            </div>

            <div class="admin-info-item">
              <span class="admin-info-label">Precio</span>
              <span class="admin-info-value">$${e.precio}</span>
            </div>

          </div>

          <div class="admin-card-extra">

            <div class="admin-professional-box">
              <span>${e.profesional?.correo ?? ""}</span>
              <span>
                ${e.profesional?.localidad ?? ""} - ${e.profesional?.pais ?? ""}
              </span>
            </div>

          </div>

          <div class="admin-card-actions">

            <button class="admin-btn admin-btn-detalles">
              Ver Detalles
            </button>

           <button 
            class="admin-btn admin-btn-delete"
            data-id="${e.id_Entrenamiento}"
          >
            Eliminar
          </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}