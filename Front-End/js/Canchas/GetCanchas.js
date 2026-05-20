import { getData } from "../Global/ApiServices.js";

export async function getCanchas()
{
    const endpointUrl = 'Cancha'; /*localhost:5279/api/v1/Cancha*/ 
    const canchas = await getData(endpointUrl);
    return canchas;
}