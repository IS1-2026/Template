export function actualizarNavbar() {

  const navBtns = document.getElementById("navBtns");

  if (!navBtns) return;

  const logueado = localStorage.getItem("logged");
  if (logueado) {

    const nombre = localStorage.getItem("nombre");

    navBtns.innerHTML = `
      <a href="perfil.html" class="btn btn-outline">
        ${nombre}
      </a>

      <button class="btn btn-solid" id="logoutBtn" href="index.html">
        Cerrar sesión
      </button>
    `;

    const logoutBtn = document.getElementById("logoutBtn");

    logoutBtn.addEventListener("click", () => {

      localStorage.removeItem("logged");
      localStorage.removeItem("nombre");
      localStorage.removeItem("dni");

      window.location.reload();

    });

  }
}