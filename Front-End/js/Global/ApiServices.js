const base_Url = "http://localhost:5279/api/v1/";

export async function getData(endpointUrl)
{
    try
    {
       const response = await fetch(`${base_Url}${endpointUrl}`, {
        method: "GET",
        headers: {
            "Accept": "application/json"
        }
        });
        const data = await response.json();
        return data;
    }
    catch(error)
    {
        throw new Error(error.message || "No se pudo conectar con el servidor");
    }
}

export async function postData(endpointUrl, body) {
    try
    {
        const response = await fetch(`${base_Url}${endpointUrl}`, {
        method: "POST",
        headers: { "Content-Type": "application/json"},
        body: JSON.stringify(body)
    });
    const data = await response.json();
    if (!response.ok) {
        throw new Error(data?.Message || "Error en la solicitud");
    }
    return data;
    }
     catch(error){
        throw new Error(error.message || "No se pudo conectar con el servidor");
    }
}

export async function putData(endpointUrl) {
    try {
        const response = await fetch(`${base_Url}${endpointUrl}`, {
            method: "PUT",
            headers: { "Content-Type": "application/json"},
        });
        const data = await response.json();
        if (!response.ok) {
            throw new Error(data?.Message || "Error en la solicitud");
        }
        return data;
    } catch(error){
        throw new Error(error.message || "No se pudo conectar con el servidor");
    }
}