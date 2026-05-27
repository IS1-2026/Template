import { postData } from "../Global/ApiServices.js";


export async function RealizarInscripcion(dniCliente, idAct, nroAct) {

    const endpointUrl = "Inscripcion";

    const body = {
        dniCliente,
        idAct,
        nroAct
    };

    try {
        const response = await postData(endpointUrl, body);

        Swal.fire({
            toast: true,
            position: "bottom-end",
            icon: "success",
            title: "Inscripción realizada correctamente",
            showConfirmButton: false,
            timer: 2500,
            timerProgressBar: true,
            customClass: {
                popup: "toast-golahora toast-popup-success",
                title: "toast-title"
            }
        });

        return response;

    } catch (error) {

        Swal.fire({
            toast: true,
            position: "bottom-end",
            icon: "error",
            title: error.message || "Error al inscribirse",
            showConfirmButton: false,
            timer: 2500,
            timerProgressBar: true,
            customClass: {
                popup: "toast-golahora toast-popup-error",
                title: "toast-title"
            }
        });

        throw error; 
    }
}