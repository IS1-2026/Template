import { CrearCliente } from "../PostCliente.js";

function validate(id, condition, errorId) {

  const el = document.getElementById(id);
  const err = document.getElementById(errorId);

  if (!condition(el.value)) {

    el.classList.add('error-input');
    err.classList.add('visible');

    return false;
  }

  el.classList.remove('error-input');
  err.classList.remove('visible');

  return true;
}

export async function handleRegistro() {

  // Reset errores
  ['nombre','apellido','dni','email','pais','direccion','password','confirmPassword']
    .forEach(id => {
      document.getElementById(id).classList.remove('error-input');
    });

  ['nombreError','apellidoError','dniError','emailError','direccionError','passwordError','confirmError']
    .forEach(id => {
      document.getElementById(id).classList.remove('visible');
    });

  const successAlert = document.getElementById('successAlert');

  successAlert.classList.remove('visible');

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const dniRegex = /^\d{7,8}$/;

  const pass = document.getElementById('password').value;
  const confirm = document.getElementById('confirmPassword').value;

  let valid = true;

  valid = validate('nombre',    v => v.trim().length > 0,       'nombreError')    && valid;
  valid = validate('apellido',  v => v.trim().length > 0,       'apellidoError')  && valid;
  valid = validate('dni',       v => dniRegex.test(v.trim()),   'dniError')       && valid;
  valid = validate('email',     v => emailRegex.test(v),        'emailError')     && valid;
  valid = validate('direccion', v => v.trim().length > 0,       'direccionError') && valid;
  valid = validate('password',  v => v.length >= 6,             'passwordError')  && valid;

  // Confirmar contraseña
  if (pass !== confirm || confirm.length < 6) {

    document.getElementById('confirmPassword').classList.add('error-input');
    document.getElementById('confirmError').classList.add('visible');

    valid = false;
  }

  if (!valid) return;

  try {

    await CrearCliente(
      parseInt(document.getElementById('dni').value),
      document.getElementById('nombre').value,
      document.getElementById('apellido').value,
      document.getElementById('email').value,
      pass,
      document.getElementById('direccion').value,
      document.getElementById('pais').value,
      document.getElementById('fechaNac').value
    );

    Swal.fire({
      toast: true,
      position: "bottom-end",
      icon: "success",
      title: "Registro realizado correctamente",
      showConfirmButton: false,
      timer: 2500,
      timerProgressBar: true,

      customClass: {
        popup: "toast-golahora toast-popup-success",
        title: "toast-title"
      }
    });

    setTimeout(() => {

      window.location.href = 'login.html';

    }, 2500);

  } catch(error) {

    console.error(error);

    Swal.fire({
      toast: true,
      position: "bottom-end",
      icon: "error",
      title: error.message ?? "Error al registrar usuario",
      showConfirmButton: false,
      timer: 2500,
      timerProgressBar: true,

      customClass: {
        popup: "toast-golahora toast-popup-error",
        title: "toast-title"
      }
    });
  }
}

window.handleRegistro = handleRegistro;