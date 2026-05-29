import {postData} from "../../Global/ApiServices.js"
export async function ProfeLogin() {
    const correo = document.getElementById("email").value;
    const psw = document.getElementById("password").value;
    const endpointUrl = "Profesionales/login/profesor"; // Endpoint específico para Profesor

    const body = { 
        correo: correo,
        password: psw
    };

    try {
        const response = await postData(endpointUrl, body);

        // Limpieza de sesiones previas
        const keysToRemove = ["dni", "nombre", "logged", "Adminlogged", "Profesorlogged", "Entrenadorlogged"];
        keysToRemove.forEach(key => localStorage.removeItem(key));

        // Persistencia de datos según el modelo UML (Profesor)
        localStorage.setItem("dni", response.dni);
        localStorage.setItem("nombre", response.nombre);
        localStorage.setItem("Profesorlogged", "true"); 
        localStorage.setItem("logged", "true"); 

        Swal.fire({
            toast: true,
            position: "bottom-end",
            icon: "success",
            title: "Sesión de Profesor iniciada",
            showConfirmButton: false,
            timer: 2500,
            timerProgressBar: true,
            customClass: {
                popup: "toast-golahora toast-popup-success",
                title: "toast-title"
            }
        });

        setTimeout(() => {
            window.location.href = 'profesor.html'; // Redirección a su propio panel
        }, 2500);

    } catch (error) {
        showLoginError(error);
    }
}
// Vinculación global para el HTML
window.ProfeLogin=ProfeLogin;