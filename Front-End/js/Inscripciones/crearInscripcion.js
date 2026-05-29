import { postData } from "../Global/ApiServices.js";


export async function RealizarInscripcion(dniCliente, idAct, nroAct) {
    const endpointUrl = "Inscripcion";
    const body = {
        dniCliente,
        idAct,
        nroAct
    };
   return await postData(endpointUrl, body);
        
}