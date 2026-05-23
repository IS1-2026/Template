import {getData} from "../Global/ApiServices.js"
export async function getReservas(dni)
{
    const endpointUrl =`Reserva/${dni}/reservas`;
    const reservas = await getData(endpointUrl);
    return reservas;
}