import { postData } from "../Global/ApiServices.js";
export async function CrearReserva(dni,idCancha,canchaHorarioId,fechaReserva) {

    const endpointUrl ='Reserva';
    console.log(fechaReserva) ;
    const body =
    {
    dniCliente:dni,
    idCancha:idCancha,
    idCanchaHorario:canchaHorarioId,
    fecha:fechaReserva,
    };
    return await postData(endpointUrl,body);
}