import { putData } from "../../Global/ApiServices.js";

export async function editarTipoCancha(tipoCancha) {

    const modal = document.createElement("div");
    modal.classList.add("modal-overlay");

    modal.innerHTML = `
      <div class="modal-card">

        <h2>Editar tipo de cancha</h2>

        <div class="form-group">
          <label>Nombre</label>
          <input 
            type="text" 
            id="nombre" 
            value="${tipoCancha.nombre || ""}" 
          />
        </div>

        <div class="form-group">
          <label>Superficie</label>
          <input 
            type="text" 
            id="superficie" 
            value="${tipoCancha.superficie || ""}" 
          />
        </div>

        <div class="form-group">
          <label>Capacidad</label>
          <input 
            type="number" 
            id="capacidad" 
            value="${tipoCancha.capacidad || 0}" 
          />
        </div>

        <div class="form-group">
          <label>Duración (horas)</label>
          <input 
            type="number" 
            id="duracion" 
            value="${tipoCancha.duracion || 1}" 
          />
        </div>

        <div class="form-group">
          <label>Precio</label>
          <input 
            type="number" 
            id="precio" 
            value="${tipoCancha.precio || 0}" 
          />
        </div>

        <div class="modal-actions">

          <button type="button" class="btn-cancelar">
            Cancelar
          </button>

          <button type="button" class="btn-guardar">
            Guardar
          </button>

        </div>

      </div>
    `;

    document.body.appendChild(modal);

    // cerrar modal
    modal.querySelector(".btn-cancelar")
        .addEventListener("click", () => {
            modal.remove();
        });

    modal.addEventListener("click", (e) => {
        if (e.target === modal) {
            modal.remove();
        }
    });

    // guardar cambios
    modal.querySelector(".btn-guardar")
        .addEventListener("click", async () => {

            const body = {
                nombre:
                    modal.querySelector("#nombre").value || null,

                superficie:
                    modal.querySelector("#superficie").value || null,

                capacidad:
                    Number(
                        modal.querySelector("#capacidad").value
                    ),

                duracion:
                    Number(
                        modal.querySelector("#duracion").value
                    ),

                precio:
                    Number(
                        modal.querySelector("#precio").value
                    )
            };

            try {

                await putData(
                    `TipoCancha/${tipoCancha.id}`,
                    body
                );

                Swal.fire({
                    toast: true,
                    position: "bottom-end",
                    icon: "success",
                    title: "Tipo de cancha actualizado con éxito",
                    showConfirmButton: false,
                    timer: 2500,
                    timerProgressBar: true,

                    customClass: {
                        popup: "toast-golahora toast-popup-success",
                        title: "toast-title"
                    }
                });

                setTimeout(() => {
                    location.reload();
                }, 2500);

            } catch (err) {

                Swal.fire({
                    toast: true,
                    position: "bottom-end",
                    icon: "error",
                    title: err.message ?? "Ocurrió un error al actualizar",
                    showConfirmButton: false,
                    timer: 2500,
                    timerProgressBar: true,

                    customClass: {
                        popup: "toast-golahora toast-popup-error",
                        title: "toast-title"
                    }
                });
            }
        });
}