import { deleteData } from "../Global/ApiServices.js";

export async function eliminarProfesional(profesionalId)
{
    const endpointUrl = `Profesionales/${profesionalId}`;
    try
    {
        await deleteData(endpointUrl);
        Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Profesional eliminado con éxito",
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
                title: error.message ?? "Error al eliminar profesional",
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