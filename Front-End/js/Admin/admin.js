import { getCanchas } from "../Canchas/GetCanchas.js";
import { getTipoCanchas } from "../TipoCancha/GetTipoCancha.js";
import { RenderAdminCards } from "./renderAdminCards.js";
import { RenderTcCards } from "./renderTcCards.js";
import { crearCancha } from "./Modals/crearCancha.js";

export  function adminPanel(){
const botones = document.querySelectorAll(".sidebar-btn");
const secciones = document.querySelectorAll(".content-section");

botones.forEach((boton, index) => {

  boton.addEventListener("click", async() => {


    botones.forEach(btn => {
      btn.classList.remove("active");
    });

    secciones.forEach(section => {
      section.classList.add("hidden");
    });

    
    boton.classList.add("active");   
    secciones[index].classList.remove("hidden");
    const seccionAct = boton.textContent.trim();;


    if(seccionAct=="Canchas")
      {
        const canchas = await getCanchas();
          const contenido = `<div class="section-header">
            <button class="btn-primary" id="btn-crear-cancha">
              + Crear cancha
            </button>
          </div>
          ${RenderAdminCards(canchas)}
        `;
        document.querySelector("#canchas").innerHTML = contenido;
        const btn = document.getElementById("btn-crear-cancha").addEventListener("click",()=>
          {
            crearCancha();
          });
          
      }
    if(seccionAct=="Tipo de canchas")
      {
        const tipos = await getTipoCanchas();
        const contenido = RenderTcCards(tipos);
        document.querySelector("#tipoCanchas").innerHTML=contenido;
      }
    if(seccionAct=="Dashboard")
      {
        console.log("AAAA")
      }



  });

});

}

