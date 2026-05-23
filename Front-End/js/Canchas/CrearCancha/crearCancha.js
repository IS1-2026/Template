import { InsertarCancha } from "../PostCancha.js";

export async function crearCancha()
{
 const form = document.getElementById('form-cancha');
 form.addEventListener("submit", async (e)=>
    {
        e.preventDefault();

        const nombre = document.getElementById("nombre").value;
        const tipo = document.getElementById("tipos").value;
        const inicio = document.getElementById("horaInicio").value;
        const fin = document.getElementById("horaFin").value;
        
        try
        {
          await InsertarCancha(nombre,tipo,inicio,fin);
          Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Cancha creada correctamente",
                showConfirmButton: false,
                timer: 2500,
                timerProgressBar: true,

                customClass: {
                    popup: "toast-golahora toast-popup-success",
                    title: "toast-title"
                }
                
            });
            setTimeout(() => {
                form.reset();
                }, 2500);
        }
         catch(error)
        {
            console.error(error);
          Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "error",
                title: error.message ?? "Error al crear cancha",
                showConfirmButton: false,
                timer: 2500,
                timerProgressBar: true,

                customClass: {
                    popup: "toast-golahora toast-popup-error",
                    title: "toast-title"
                }
            });
        }
        
        
    });

}