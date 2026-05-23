import { postData } from "../Global/ApiServices.js";

export function CrearCliente(dni,nombre,apellido,correo,contraseña,localidad,pais,nacimiento)
{
    const endpointUrl = 'Clientes/Registrar';

    const body =
    {
        dni:dni,
        nombre:nombre,
        apellido:apellido,
        correo:correo,
        password:contraseña,
        localidad:localidad,
        pais:pais,
        fechaNac:nacimiento
    }

    return postData(endpointUrl,body);
}

export function Login(correo,contraseña)
{
    const endpointUrl = 'Clientes/Login';

    const body =
    {
        correo:correo,
        password:contraseña,
    }

    return postData(endpointUrl,body);
}