namespace Application.DTOs.Response.Competencias
{

    public class TablaLigaResponse
    {
        public int IdEquipo { get; set; }

        public string Equipo { get; set; }

        public int PJ { get; set; }

        public int PG { get; set; }

        public int PE { get; set; }

        public int PP { get; set; }

        public int GF { get; set; }

        public int GC { get; set; }

        public int DG => GF - GC;

        public int Puntos { get; set; }
    }
}