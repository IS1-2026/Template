// login.js - lógica de validación del formulario de inicio de sesión

function handleLogin() {
  const email = document.getElementById('email');
  const password = document.getElementById('password');
  const emailError = document.getElementById('emailError');
  const passwordError = document.getElementById('passwordError');
  const successAlert = document.getElementById('successAlert');
  let valid = true;

  // Reset
  email.classList.remove('error-input');
  password.classList.remove('error-input');
  emailError.classList.remove('visible');
  passwordError.classList.remove('visible');
  successAlert.classList.remove('visible');

  // Validar email
  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(email.value)) {
    email.classList.add('error-input');
    emailError.classList.add('visible');
    valid = false;
  }

  // Validar password
  if (password.value.length < 6) {
    password.classList.add('error-input');
    passwordError.classList.add('visible');
    valid = false;
  }

  if (valid) {
    successAlert.classList.add('visible');
    setTimeout(() => {
      window.location.href = 'reportes.html';
    }, 1500);
  }
}

// Enter key
document.addEventListener('keydown', e => {
  if (e.key === 'Enter') handleLogin();
});