import { postData } from "../Global/ApiServices.js"

export async function crearCobro(idReserva,idInscripcion,dni,monto,metodo,motivo) {
    const body =
    {
        idReserva:idReserva,
        idInscripcion:idInscripcion,
        montoTotal:monto,
        metodoPago:metodo,
        dniCliente:dni,
        motivo:motivo
    }

    return await postData("Cobro",body);
}