export function RenderAdminCards(canchas)
{
  return `
    <div class="admin-canchas-grid">

      ${canchas.map(c => `
      
        <div class="admin-card">

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

            <div class="admin-info-item">
              <span class="admin-info-label">
                Precio
              </span>

              <span class="admin-info-value">
                $${c.tipoCancha.precio}
              </span>
            </div>

          </div>

          <div class="admin-card-actions">

            <button class="admin-btn admin-btn-edit">
              Editar
            </button>

            <button class="admin-btn admin-btn-delete">
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}