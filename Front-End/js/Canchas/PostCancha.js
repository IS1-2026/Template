import { postData } from "../Global/ApiServices.js";
export function InsertarCancha(tipo,nombre,horarios)
{   
    const endpointUrl = 'Cancha';

    const body =
    {
        idTipoCancha:parseInt(tipo),
        nombre:nombre,
        horarios:horarios
    }

    return postData(endpointUrl,body);
}