import { postData } from "../Global/ApiServices.js";

export async function InsertarTipoCancha(nombre,superficie,capacidad,duracion,precio)
{
    const endpointUrl = 'TipoCancha';

    const body =
    {
        nombre:nombre,
        superficie:superficie,
        capacidad:capacidad,
        duracion:duracion,
        precio:precio
    }

    return postData(endpointUrl,body);

}