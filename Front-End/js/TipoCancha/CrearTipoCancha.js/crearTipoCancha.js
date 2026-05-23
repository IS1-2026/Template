import { InsertarTipoCancha } from "../PostTipoCancha.js";

export function crearTipoCancha()
{
    const form = document.getElementById('form-tipo-cancha');
    form.addEventListener('submit',async (e)=>
        {
            e.preventDefault();
            const nombreTipoCancha = document.getElementById('nombreTipoCancha').value;
            const superficie = document.getElementById('superficie').value;
            const capacidad = document.getElementById('capacidad').value;
            const duracion = document.getElementById('duracion').value;
            const precio = document.getElementById('precio').value;
            try
               {
                await InsertarTipoCancha(nombreTipoCancha,superficie,capacidad,duracion,precio);
                Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "success",
                title: "Tipo de cancha creada correctamente",
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
                Swal.fire({
                toast: true,
                position: "bottom-end",
                icon: "error",
                title: error.message ?? "Error al crear tipo cancha",
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