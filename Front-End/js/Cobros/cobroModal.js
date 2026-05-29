export function CrearModalRegistrarCobro(nombre, total, dni) {

  return `
    
    <div class="cobro-modal-overlay active" id="registrarCobroModal">

      <div class="cobro-modal-content">

        <!-- CERRAR -->
        <button class="cerrar-modal-cobro">
          X
        </button>

        <!-- HEADER -->
        <div class="modal-header-custom">

          <h2>
            <i class="fa-solid fa-money-bill-wave"></i>
            Registrar Cobro
          </h2>

          <p>
            Registrando:
            <strong>${nombre}</strong>
          </p>

        </div>

        <!-- FORM -->
        <form id="formRegistrarCobro">

      

          <!-- DNI -->
          <div class="input-group-custom">

            <label>
              DNI Cliente
            </label>

            <div class="monto-total-display">

              ${dni}

            </div>

            <input
              type="hidden"
              id="dniClienteCobro"
              value="${dni}"
            >

          </div>

          <!-- MONTO -->
          <div class="input-group-custom">

            <label>
              Monto Total
            </label>

            <div class="monto-total-display">

              $${Number(total).toLocaleString("es-AR", {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
              })}

            </div>

            <input
              type="hidden"
              id="montoTotalCobro"
              value="${total}"
            >

          </div>

          <!-- METODO -->
          <div class="input-group-custom">

            <label>
              Método de Pago
            </label>

            <select
              id="metodoPagoCobro"
              required
            >

              <option value="">
                Seleccione un método
              </option>

              <option value="Transferencia">
                Transferencia
              </option>

              <option value="Tarjeta">
                Tarjeta
              </option>

              <option value="MercadoPago">
                Mercado Pago
              </option>

            </select>

          </div>

          <!-- FOOTER -->
          <div class="footer-modal-custom">

            <button
              type="button"
              class="cancelar-btn"
            >
              Cancelar
            </button>

            <button
              type="submit"
              class="confirmar-btn"
            >

              <i class="fa-solid fa-check"></i>

              Registrar Cobro

            </button>

          </div>

        </form>

      </div>

    </div>

  `;
}