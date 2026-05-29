import {postData} from "../../Global/ApiServices.js"


export async function EntreLogin() {
    const correo = document.getElementById("email").value;
    const psw = document.getElementById("password").value;
    const endpointUrl = "Profesionales/login/entrenador";

    const body = { correo, password: psw };

    try {
        const response = await postData(endpointUrl, body);

         if(localStorage.getItem("dni"))
        {
            localStorage.removeItem("dni")    
        }
        if(localStorage.getItem("nombre"))
        {
            localStorage.removeItem("nombre")    
        }
        if(localStorage.getItem("logged"))
        {
            localStorage.removeItem("logged")    
        }

        localStorage.setItem("dni", response.dni);
        localStorage.setItem("nombre", response.nombre);
        localStorage.setItem("Entrenadorlogged", "true"); 
        

        Swal.fire({
            toast: true,
            position: "bottom-end",
            icon: "success",
            title: "Sesión de Entrenador iniciada",
            showConfirmButton: false,
            timer: 2500,
            timerProgressBar: true,
            customClass: {
                popup: "toast-golahora toast-popup-success",
                title: "toast-title"
            }
        });

        setTimeout(() => {
            window.location.href = 'entrenador.html';
        }, 2500);

    } catch (error) {
        showLoginError(error);
    }
}

function showLoginError(error) {
    Swal.fire({
        toast: true,
        position: "bottom-end",
        icon: "error",
        title: error.message ?? "Credenciales inválidas",
        showConfirmButton: false,
        timer: 2500,
        timerProgressBar: true,
        customClass: {
            popup: "toast-golahora toast-popup-error",
            title: "toast-title"
        }
    });
}

// Vinculación global idéntica al onclick del HTML
window.EntreLogin=EntreLogin;