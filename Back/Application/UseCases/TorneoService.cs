using Application.Interfaces.Competencias;
using Domain.Entities;
using Application.DTOs.Request.Competencias;
using Application.DTOs.Response.Competencias;
using Application.Interfaces.Partidos;


namespace Application.UseCases
{

    public class TorneoService:CompetenciaService,ITorneoService
    {
        private readonly IPartidoCommand _partidoCommand;
        private readonly IPartidoQuery _partidoQuery;
        public TorneoService(ICompetenciaCommand competenciaCommand, ICompetenciaQuery competenciaQuery, IPartidoCommand partidoCommand,IPartidoQuery partidoQuery) : base(competenciaCommand, competenciaQuery)
        {
            _partidoCommand = partidoCommand;
            _partidoQuery = partidoQuery;
        }

        public async Task GenerarFixture(int idTorneo, CancellationToken ct = default)
        {
            var competencia = await _competenciaQuery.ObtenerCompetenciaPorId(idTorneo, ct);
            
            if (competencia is null) throw new KeyNotFoundException($"No se encontro competencias con id: {idTorneo}");
            if(competencia is not Torneo torneo)
            { throw new InvalidOperationException($"La competencia con id: {idTorneo} no es un torneo."); }
            if (competencia.Partidos.Any())
            {
                throw new InvalidOperationException($"La competencia {competencia.Nombre} ya tiene partidos generados.");
            }
            if (competencia.Equipos.Count() < 2)
            {
                throw new InvalidOperationException($"La competencia {competencia.Nombre} no tiene suficientes equipos para generar un fixture.");
            }

            var equipos = competencia.Equipos
                .OrderBy(e => Guid.NewGuid()) 
                .ToList();

            int rondasTotales = (int)Math.Log2(equipos.Count);

            var partidosRondas = new List<List<Partido>>();

            int partidosPorRonda = equipos.Count / 2;

            int partidoNumero = 1;

            for (int ronda = 0; ronda < rondasTotales; ronda++)
            {
                var rondaActual = new List<Partido>();
                for (int i=0; i<partidosPorRonda; i++)
                {
                    var partido = new Partido
                    {
                        IdCompetencia = idTorneo,
                        HoraInicio = DateTime.Now.AddDays(partidoNumero++),
                        HoraFin = DateTime.Now.AddDays(partidoNumero++).AddHours(2),
                        Estado = "Programado"
                    };
                    rondaActual.Add(partido);
                    partidoNumero++;
                }
                partidosRondas.Add(rondaActual);
                partidosPorRonda /= 2;
            }
            int indiceEquipo = 0;
            foreach (var partido in partidosRondas[0])
            {
                partido.IdEquipoLocal = equipos[indiceEquipo].IdEquipo;
                partido.IdEquipoVis = equipos[indiceEquipo+1].IdEquipo;
                indiceEquipo+=2;
            }
           for(int ronda=0; ronda<partidosRondas.Count-1; ronda++)
            {
                var rondaActual = partidosRondas[ronda];
                var rondaSiguiente = partidosRondas[ronda + 1];

                for(int i=0; i<rondaActual.Count; i++)
                {
                    int indiceSiguiente = i / 2;
                    rondaActual[i].SigPartido = rondaSiguiente[indiceSiguiente];
                }
            }

            var partidosAGuardar = partidosRondas.SelectMany(r => r).ToList();

            await AgregarPartidos(partidosAGuardar, ct);
        }

        public async Task AgregarPartidos(List<Partido> fixture, CancellationToken ct = default)
        {
            await _competenciaCommand.AgregarPartidos(fixture, ct);
        }

        public async Task CargarResultado(int IdPartido, int GolesLocal, int GolesVis, CancellationToken ct = default)
        {
            var partido = await _partidoQuery.ObtenerPartidoPorId(IdPartido, ct);
            if (partido is null) throw new KeyNotFoundException($"No se encontro partido con id: {IdPartido}");

            partido.GolesLocal = GolesLocal;
            partido.GolesVis = GolesVis;
            partido.Estado = "Finalizado";

            await _partidoCommand.ModificarPartido(partido, ct);
        }
    }
}