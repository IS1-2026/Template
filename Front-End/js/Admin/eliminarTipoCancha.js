import { deleteData } from "../Global/ApiServices.js";
export async function eliminarTipoCancha(tipoCanchaId)
{
      const endpointUrl = `TipoCancha/${tipoCanchaId}`;
    try
    {
        await deleteData(endpointUrl);
        Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Tipo cancha eliminada con exito",
                showConfirmButton: false,
                timer: 2500,
                timerProgressBar: true,
                customClass: {
                    popup: "toast-golahora toast-popup-success",
                    title: "toast-title"
                }
            });
    }
    catch(error)
    {
          Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "error",
                title: error.message ?? "Error al eliminar tipo cancha",
                showConfirmButton: false,
                timer: 2500,
                timerProgressBar: true,
                customClass: {
                    popup: "toast-golahora toast-popup-error",
                    title: "toast-title"
                }
            });

    }

}