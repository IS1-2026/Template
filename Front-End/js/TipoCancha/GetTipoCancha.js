import { getData } from "../Global/ApiServices.js";
export function getTipoCanchas()
{
    const endpointUrl = "TipoCancha";
    return getData(endpointUrl);
}