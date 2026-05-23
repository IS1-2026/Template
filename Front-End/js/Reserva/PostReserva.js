import { postData } from "../Global/ApiServices.js";
export async function CrearReserva(dni,idCancha,canchaHorarioId,fechaReserva) {

    const endpointUrl ='Reserva';
    const body =
    {
    dniCliente:dni,
    idCancha:idCancha,
    idCanchaHorario:canchaHorarioId,
    fechaReserva:fechaReserva,
    };
    return await postData(endpointUrl,body);
}