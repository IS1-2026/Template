import { getData } from "../../../Global/ApiServices.js";

export async function getHorarios(canchaId,fecha) {

    const endpointUrl =`Cancha/${canchaId}/Horarios/${fecha}`;

    const data = await getData(endpointUrl);

    return data;
    
}