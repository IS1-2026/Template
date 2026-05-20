// registro.js - lógica de validación del formulario de registro

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

function handleRegistro() {
  // Reset todos los errores
  ['nombre','apellido','dni','email','telefono','direccion','password','confirmPassword']
    .forEach(id => {
      document.getElementById(id).classList.remove('error-input');
    });
  ['nombreError','apellidoError','dniError','emailError','telefonoError','direccionError','passwordError','confirmError']
    .forEach(id => document.getElementById(id).classList.remove('visible'));
  document.getElementById('successAlert').classList.remove('visible');

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  const dniRegex = /^\d{7,8}$/;
  const pass = document.getElementById('password').value;
  const confirm = document.getElementById('confirmPassword').value;

  let valid = true;
  valid = validate('nombre',    v => v.trim().length > 0,       'nombreError')    && valid;
  valid = validate('apellido',  v => v.trim().length > 0,       'apellidoError')  && valid;
  valid = validate('dni',       v => dniRegex.test(v.trim()),   'dniError')       && valid;
  valid = validate('email',     v => emailRegex.test(v),        'emailError')     && valid;
  valid = validate('telefono',  v => v.trim().length >= 8,      'telefonoError')  && valid;
  valid = validate('direccion', v => v.trim().length > 0,       'direccionError') && valid;
  valid = validate('password',  v => v.length >= 6,             'passwordError')  && valid;

  // Confirmar contraseña
  if (pass !== confirm || confirm.length < 6) {
    document.getElementById('confirmPassword').classList.add('error-input');
    document.getElementById('confirmError').classList.add('visible');
    valid = false;
  }

  if (valid) {
    document.getElementById('successAlert').classList.add('visible');
    setTimeout(() => { window.location.href = 'login.html'; }, 2000);
  }
}