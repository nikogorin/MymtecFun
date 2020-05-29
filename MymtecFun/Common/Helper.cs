using System;

namespace MymtecFun.Common
{
    public static class Helper
    {
        public static long GetMinutos(this string strHora)
        {
            if (strHora.Length != 4)
                throw new FormatException("El formato de la hora tiene que ser 'hhmm'");
            var hora = strHora.Substring(0, 2);            
            var minutos = strHora.Substring(2, 2);

            var timeSpan = new TimeSpan(Convert.ToInt32(hora), Convert.ToInt32(minutos), 0);
            return Convert.ToInt64(timeSpan.TotalMinutes);
        }

        public static string GetHora(this long intMinutos)
        {
            var timeSpan = TimeSpan.FromMinutes(intMinutos);
            var dateTime = new DateTime(timeSpan.Ticks);

            return $"{dateTime.Hour:00}{dateTime.Minute:00}";
        }

        public static long MinDif(string strInicio, string strFin)
        {
            var minInicio = GetMinutos(strInicio);
            var minFin = GetMinutos(strFin);

            return minFin - minInicio;
        }
    }
}
