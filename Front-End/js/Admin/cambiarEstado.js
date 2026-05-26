import { patchData } from "../Global/ApiServices.js";
export async function cambiarEstado(canchaId)
{
    const endpointUrl = `Cancha/${canchaId}/estado`;

    try
    {
        await patchData(endpointUrl);
        Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Estado actualizado con éxito",
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
                icon: "success",
                title: error.message ?? "Error al cambiar estado",
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