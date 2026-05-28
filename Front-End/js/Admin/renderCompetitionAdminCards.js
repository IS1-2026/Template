export function RenderCompetitionAdminCards(competiciones)
{
  if (!competiciones?.length) {

    return `
      <p style="color: rgba(255,255,255,0.4)">
        No se encontraron competencias.
      </p>
    `;
  }

  return `

    <div class="admin-clases-grid">

      ${competiciones.map(c => `

        <div 
          class="admin-card"
          data-id="${c.competenciaId}"
        >

          <div class="admin-card-header">

            <div>

              <h3 class="admin-card-title">
                ${c.nombre}
              </h3>

              <p class="admin-card-subtitle">
                ${c.tipo ?? "Competencia"}
              </p>

            </div>

            <span class="admin-badge">
              ${c.estado ? "Activa" : "Inactiva"}
            </span>

          </div>

          <div class="admin-card-info">

            <div class="admin-info-item">

              <span class="admin-info-label">
                Cupos
              </span>

              <span class="admin-info-value">
                ${c.cupos ?? 0}
              </span>

            </div>

            <div class="admin-info-item">

              <span class="admin-info-label">
                Precio
              </span>

              <span class="admin-info-value">
                $${c.precio ?? 0}
              </span>

            </div>

          </div>

          <div class="admin-card-extra">

            <div class="admin-professional-box">

              <span>
                ${c.descripcion ?? "Sin descripción"}
              </span>

            </div>

          </div>

          <div class="admin-card-actions">

            <button 
              class="admin-btn admin-btn-edit"
              data-id="${c.competenciaId}"
            >
              Editar
            </button>

            <button 
              class="admin-btn admin-btn-delete"
              data-id="${c.competenciaId}"
            >
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}