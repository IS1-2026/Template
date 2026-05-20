// reportes.js - lógica del dashboard de reportes

let reportes = [];
let nextId = 1;

// Setear fecha de hoy por defecto
document.addEventListener('DOMContentLoaded', () => {
  const hoy = new Date().toISOString().split('T')[0];
  document.getElementById('fechaReporte').value = hoy;
});

function generarReporte() {
  const tipo = document.getElementById('tipoReporte').value;
  const fecha = document.getElementById('fechaReporte').value;

  if (!tipo) {
    document.getElementById('tipoReporte').classList.add('error-input');
    document.getElementById('tipoError').classList.add('visible');
    valid = false;
  }

  if (!fecha) {
    document.getElementById('fechaReporte').classList.add('error-input');
    document.getElementById('fechaError').classList.add('visible');
    valid = false;
  }

  const reporte = {
    id: nextId++,
    tipo,
    fecha: new Date(fecha + 'T00:00:00').toLocaleDateString('es-AR', {
      day: '2-digit', month: '2-digit', year: 'numeric'
    })
  };

  reportes.push(reporte);
  actualizarStats();
  renderTabla();

  // Reset selector
  document.getElementById('tipoReporte').value = '';
}

function eliminarReporte(id) {
  if (!confirm('¿Seguro que querés eliminar este reporte?')) return;
  reportes = reportes.filter(r => r.id !== id);
  actualizarStats();
  renderTabla();
}

function actualizarStats() {
  document.getElementById('totalIngresos').textContent  = reportes.filter(r => r.tipo === 'Ingresos').length;
  document.getElementById('totalAsistencia').textContent = reportes.filter(r => r.tipo === 'Asistencia').length;
  document.getElementById('totalReservas').textContent  = reportes.filter(r => r.tipo === 'Reservas').length;
  document.getElementById('totalReportes').textContent  = reportes.length;
}

function filtrarReportes() {
  renderTabla();
}

function renderTabla() {
  const filtro = document.getElementById('filtroTipo').value;
  const lista = filtro ? reportes.filter(r => r.tipo === filtro) : reportes;
  const tbody = document.getElementById('tablaReportes');

  if (lista.length === 0) {
    tbody.innerHTML = `<tr><td colspan="4" class="empty">No hay reportes${filtro ? ' de tipo ' + filtro : ''} aún.</td></tr>`;
    return;
  }

  tbody.innerHTML = lista.map(r => `
    <tr>
      <td style="color:var(--texto-suave);">#${r.id}</td>
      <td><span class="badge badge-${r.tipo.toLowerCase()}">${r.tipo}</span></td>
      <td>${r.fecha}</td>
      <td><button class="action-btn" onclick="eliminarReporte(${r.id})">Eliminar</button></td>
    </tr>
  `).join('');
}