import { postData } from "../Global/ApiServices.js"

export async function crearCobro(idReserva,dni,monto,metodo,motivo) {
    const body =
    {
        id_Reserva:idReserva,
        montoTotal:monto,
        metodoPago:metodo,
        dniCliente:dni,
        motivo:motivo
    }

    return await postData("Cobro",body);
}