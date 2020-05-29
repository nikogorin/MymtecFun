using System.Collections.Generic;

namespace MymtecFun.Classes
{
    public class Persona
    {
        public string Nombre { get; set; }
        public RangoHorario JornadaLaboral { get; set; }
        public List<RangoHorario> Actividades { get; set; }

        public Persona()
        {
            Actividades = new List<RangoHorario>();
        }
    }
}
