import { deleteData } from "../Global/ApiServices.js";

export async function eliminarEntrenamiento(entrenamientoId)
{
    const endpointUrl = `Entrenamiento/${entrenamientoId}`;
    try
    {
        await deleteData(endpointUrl);
        Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Entrenamiento eliminado con exito",
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
                title: error.message ?? "Error al eliminar entrenamiento",
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