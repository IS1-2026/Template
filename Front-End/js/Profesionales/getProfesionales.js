import { getDataQueryParams } from "../Global/ApiServices.js";

export async function getProfesionales(tipo)
{
    return await getDataQueryParams("Profesionales", { tipo });

}