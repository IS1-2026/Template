import { getData } from "../Global/ApiServices.js";

export async function getCompeticiones() {
    const endpointUrl = 'Competencia';
    const competencias = await getData(endpointUrl);
    return competencias;
}