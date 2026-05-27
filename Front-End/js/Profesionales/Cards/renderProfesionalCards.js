export function RenderProfesionalCards(profesionales) {

  if (!profesionales?.length) {
    return `
      <p style="color: rgba(255,255,255,0.4)">
        No se encontraron profesionales.
      </p>
    `;
  }

  return `
    <div class="profesionales-grid">

      ${profesionales.map(p => `

        <div class="profesional-card">

          <div class="profesional-card-top">

            <div class="profesional-header">

              <div>

                <span class="profesional-badge">
                  ${p.tipo ?? "Profesional"}
                </span>

                <h3 class="profesional-nombre">
                  ${p.nombre}
                </h3>

                <p class="profesional-apellido">
                  ${p.apellido ?? ""}
                </p>

              </div>

            </div>

            <div class="profesional-meta">

              <span class="meta-pill">
                ${p.localidad ?? "-"}
              </span>

              <span class="meta-pill">
                ${p.pais ?? "-"}
              </span>

              <span class="meta-pill">
                ${p.correo ?? "-"}
              </span>

            </div>

          </div>

          <div class="profesional-footer">

            <span class="${p.estado ? "estado-activo" : "estado-inactivo"}">

              ${p.estado ? "Activo" : "Inactivo"}

            </span>

            <button class="btn-contactar">
              Ver perfil
            </button>

          </div>

        </div>

      `).join("")}

    </div>
  `;
}