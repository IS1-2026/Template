import { deleteData } from "../Global/ApiServices.js";

export async function eliminarClase(claseId)
{
    const endpointUrl = `Clase/${claseId}`;
    try
    {
        await deleteData(endpointUrl);
        Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Clase eliminada con éxito",
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
                title: error.message ?? "Error al eliminar la clase",
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