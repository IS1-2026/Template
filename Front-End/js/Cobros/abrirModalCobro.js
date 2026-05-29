import { CrearModalRegistrarCobro } from "./cobroModal.js";

export function abrirModalCobro(onConfirm, titulo) {

  const dni = Number(localStorage.getItem("dni"));

  const modalExistente = document.querySelector("#registrarCobroModal");
  if (modalExistente) modalExistente.remove();

  const modalHTML = CrearModalRegistrarCobro(
    titulo,
    0, 
    dni
  );

  document.body.insertAdjacentHTML("beforeend", modalHTML);

  const modal = document.querySelector("#registrarCobroModal");

  modal.classList.add("active");
  document.body.classList.add("modal-open");

  // cerrar
  modal.querySelector(".cerrar-modal-cobro").onclick = () => {
    modal.remove();
    document.body.classList.remove("modal-open");
  };

  // submit
  modal.querySelector("#formRegistrarCobro").addEventListener("submit", async (e) => {
    e.preventDefault();

    const metodoPago = modal.querySelector("#metodoPagoCobro").value;

    try {
      await onConfirm(metodoPago);

      modal.remove();
      document.body.classList.remove("modal-open");

      Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "success",
        title: "Operación realizada correctamente",
        timer: 2500,
        showConfirmButton: false
      });

    } catch (err) {
      Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "error",
        title: err.message ?? "Error",
        timer: 2500,
        showConfirmButton: false
      });
    }
  });
}