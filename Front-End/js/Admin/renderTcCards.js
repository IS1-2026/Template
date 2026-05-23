export function RenderTcCards(tipos)
{
  return `
  
    <div class="admin-tipos-grid">

      ${tipos.map(tipo => `

        <div class="tipo-card">

          <div class="tipo-card-header">

            <h3 class="tipo-card-title">
              ${tipo.nombre}
            </h3>

            <span class="tipo-badge">
              ID ${tipo.id}
            </span>

          </div>

          <div class="tipo-card-info">

            <div class="tipo-info-item">

              <span class="tipo-info-label">
                Superficie
              </span>

              <span class="tipo-info-value">
                ${tipo.superficie}
              </span>

            </div>

            <div class="tipo-info-item">

              <span class="tipo-info-label">
                Capacidad
              </span>

              <span class="tipo-info-value">
                ${tipo.capacidad} jugadores
              </span>

            </div>

            <div class="tipo-info-item">

              <span class="tipo-info-label">
                Duración
              </span>

              <span class="tipo-info-value">
                ${tipo.duracion}h
              </span>

            </div>

            <div class="tipo-info-item">

              <span class="tipo-info-label">
                Precio
              </span>

              <span class="tipo-info-value">
                $${tipo.precio}
              </span>

            </div>

          </div>

          <div class="tipo-card-footer">

            <button class="tipo-btn tipo-btn-edit">
              Editar
            </button>

            <button class="tipo-btn tipo-btn-delete">
              Eliminar
            </button>

          </div>

        </div>

      `).join("")}

    </div>

  `;
}