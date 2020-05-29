using System.Collections.Generic;
using MymtecFun.Classes;
using Newtonsoft.Json;
using NUnit.Framework;

namespace MymtecFun.Tests
{
    [TestFixture]
    public class FunTest
    {
        [TestCase]
        public static void Test_GetMinutos_1200()
        {
            var input = "1200";

            var result = Common.Helper.GetMinutos(input);

            Assert.AreEqual(720, result);
        }

        [TestCase]
        public static void Test_GetMinutos_0130()
        {
            var input = "0130";

            var result = Common.Helper.GetMinutos(input);

            Assert.AreEqual(90, result);
        }

        [TestCase]
        public static void Test_GetHora_60()
        {
            var input = 60;

            var result = Common.Helper.GetHora(input);

            Assert.AreEqual("0100", result);
        }

        [TestCase]
        public static void Test_GetHora_90()
        {
            var input = 90;

            var result = Common.Helper.GetHora(input);

            Assert.AreEqual("0130", result);
        }

        [TestCase]
        public static void Test_GetHora_360()
        {
            var input = 360;

            var result = Common.Helper.GetHora(input);

            Assert.AreEqual("0600", result);
        }

        [TestCase]
        public static void Test_MinDif_1500_1615()
        {
            var input_1 = "1500";
            var input_2 = "1615";

            var result = Common.Helper.MinDif(input_1, input_2);

            Assert.AreEqual(75, result);
        }

        [TestCase]
        public static void Test_MinDif_1200_1800()
        {
            var input_1 = "1200";
            var input_2 = "1800";

            var result = Common.Helper.MinDif(input_1, input_2);

            Assert.AreEqual(360, result);
        }

        [TestCase]
        public static void Test_DevolverHorariosPosibles_1()
        {
            var input = new List<Persona>();

            var p_1 = new Persona
            {
                Nombre = "Carla",
                JornadaLaboral = new RangoHorario { Inicio = "0900", Fin = "1800" },
                Actividades = new List<RangoHorario> { 
                    new RangoHorario { Inicio = "0900", Fin = "1130" },
                    new RangoHorario { Inicio = "1300", Fin = "1400" },
                    new RangoHorario { Inicio = "1500", Fin = "1540" }
                }
            };
            var p_2 = new Persona
            {
                Nombre = "Jose",
                JornadaLaboral = new RangoHorario { Inicio = "0830", Fin = "1730" },
                Actividades = new List<RangoHorario> {
                    new RangoHorario { Inicio = "1200", Fin = "1400" },
                    new RangoHorario { Inicio = "1645", Fin = "1730" }
                }
            };
            var p_3 = new Persona
            {
                Nombre = "Maria",
                JornadaLaboral = new RangoHorario { Inicio = "1000", Fin = "1700" },
                Actividades = new List<RangoHorario> {
                    new RangoHorario { Inicio = "1000", Fin = "1100" },
                    new RangoHorario { Inicio = "1530", Fin = "1600" }
                }
            };

            input.Add(p_1);
            input.Add(p_2);
            input.Add(p_3);

            var result = Calcular.DevolverHorariosPosibles(input, 30);

            Assert.AreEqual(JsonConvert.SerializeObject(new RangoHorario { Inicio = "1130", Fin = "1200" }), JsonConvert.SerializeObject(result[0]));
            Assert.AreEqual(JsonConvert.SerializeObject(new RangoHorario { Inicio = "1400", Fin = "1430" }), JsonConvert.SerializeObject(result[1]));
            Assert.AreEqual(JsonConvert.SerializeObject(new RangoHorario { Inicio = "1430", Fin = "1500" }), JsonConvert.SerializeObject(result[2]));
            Assert.AreEqual(JsonConvert.SerializeObject(new RangoHorario { Inicio = "1600", Fin = "1630" }), JsonConvert.SerializeObject(result[3]));
        }

        [TestCase]
        public static void Test_DevolverHorariosPosibles_2()
        {
            var input = new List<Persona>();

            var p_1 = new Persona
            {
                Nombre = "Carla",
                JornadaLaboral = new RangoHorario { Inicio = "0900", Fin = "1800" },
                Actividades = new List<RangoHorario> {
                    new RangoHorario { Inicio = "0900", Fin = "1130" },
                    new RangoHorario { Inicio = "1300", Fin = "1400" },
                    new RangoHorario { Inicio = "1500", Fin = "1540" }
                }
            };
            var p_2 = new Persona
            {
                Nombre = "Jose",
                JornadaLaboral = new RangoHorario { Inicio = "0830", Fin = "1730" },
                Actividades = new List<RangoHorario> {
                    new RangoHorario { Inicio = "1200", Fin = "1400" },
                    new RangoHorario { Inicio = "1645", Fin = "1730" }
                }
            };
            var p_3 = new Persona
            {
                Nombre = "Maria",
                JornadaLaboral = new RangoHorario { Inicio = "1000", Fin = "1700" },
                Actividades = new List<RangoHorario> {
                    new RangoHorario { Inicio = "1000", Fin = "1100" },
                    new RangoHorario { Inicio = "1530", Fin = "1600" }
                }
            };

            input.Add(p_1);
            input.Add(p_2);
            input.Add(p_3);

            var result = Calcular.DevolverHorariosPosibles(input, 60);

            var expected = new RangoHorario { Inicio = "1400", Fin = "1500" };

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(result[0]));
        }
    }
}
