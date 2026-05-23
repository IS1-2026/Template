import { postData } from "../Global/ApiServices.js";
export function InsertarCancha(nombre,tipo,inicio,fin)
{   
    const endpointUrl = 'Cancha';

    const body =
    {
        idTipoCancha:parseInt(tipo),
        nombre:nombre,
        horaInicio:inicio,
        horaFin:fin
    }

    return postData(endpointUrl,body);
}