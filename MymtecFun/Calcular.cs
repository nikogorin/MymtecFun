using MymtecFun.Classes;
using MymtecFun.Common;
using System.Collections.Generic;
using System.Linq;

namespace MymtecFun
{
    public static class Calcular
    {
        public static List<RangoHorario> DevolverHorariosPosibles(List<Persona> personas, int duracion)
        {
            //Obtengo el maximo del inicio y el minimo del fin para encontrar el denominador comun de la jornada.
            var minutosIniJornada = personas.Max(x => x.JornadaLaboral.Inicio.GetMinutos());
            var minutosFinJornada = personas.Min(x => x.JornadaLaboral.Fin.GetMinutos());

            var minutosJornada = minutosFinJornada - minutosIniJornada;
            var minutosJornadaSobreDuracion = minutosJornada / duracion;
            //Armo el listado de la jornada en rango horario.
            var listJornada = new List<RangoHorario>();
            for (int i = 1; i <= minutosJornadaSobreDuracion; i++)
            {
                listJornada.Add(new RangoHorario { Inicio = (minutosIniJornada + (i - 1) * duracion).GetHora(), Fin = (minutosIniJornada + i * duracion).GetHora() });
            }
            //Recorro las personas para buscar las actividades cargadas para cada uno
            var listHorariosDisponibles = listJornada;
            foreach (var persona in personas)
            {
                foreach (var actividad in persona.Actividades)
                {
                    var iniMin = actividad.Inicio.GetMinutos();
                    var finMin = actividad.Fin.GetMinutos();
                    //Obtengo los rangos horarios no disponibles en funcion del listado de la jornada
                    var horariosNoDisponibles = listJornada.Where(x => finMin > x.Inicio.GetMinutos() && iniMin < x.Fin.GetMinutos()).ToList();
                    //Quito del listado de horarios disponibles el listado de los no disponibles, cargados previamente.
                    listHorariosDisponibles = listHorariosDisponibles.Except(horariosNoDisponibles).ToList();
                }
            }

            return listHorariosDisponibles;
        }

    }
}
