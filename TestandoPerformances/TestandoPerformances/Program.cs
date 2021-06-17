using System;
using System.Collections.Generic;
using System.Text;

namespace TestandoPerformances
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Comparando o tempo usando o Convert.ToDateTime() e New DateTime()

            var totalDeDatas = 10000000;

            List<DateTime> datas = new List<DateTime>();
            List<DateTime> dataConvert = new List<DateTime>();
            List<DateTime> data2NewDateTime = new List<DateTime>();

            var random = new Random();

            for (int i = 0; i < totalDeDatas; i++)
            {
                datas.Add(new(random.Next(1992, 2021), random.Next(1, 12), random.Next(1, 27)));
            }

            Console.WriteLine("Testando Convert de Datas: Total de {0:N2}", totalDeDatas);

            //Primeiro método

            var dataInicioConvert = DateTime.Now;
            for (int i = 0; i < totalDeDatas; i++)
            {
                data2NewDateTime.Add(PrimeiroDiaDoMesConvert(datas[i]));
            }

            var dataTerminoConvert = DateTime.Now;
            var tempoConvert = dataTerminoConvert - dataInicioConvert;

            Console.WriteLine($"Tempo utilizado com o Convert.ToDateTime { tempoConvert.Minutes }m "
                            + $"{ tempoConvert.Seconds }s { tempoConvert.Milliseconds }mm");

            //Segundo Método

            var dataInicioNew = DateTime.Now;
            for (int i = 0; i < totalDeDatas; i++)
            {
                datas.Add(PrimeiroDiaDoMesNewDateTime(datas[i]));
            }
            var dataTerminoNew = DateTime.Now;
            var tempoNew = dataTerminoNew - dataInicioNew;

            Console.WriteLine($"Tempo utilizado com o new DateTime { tempoNew.Minutes }m "
                            + $"{ tempoNew.Seconds }s { tempoNew.Milliseconds }mm");

            #endregion

            #region Comparação de Concatenação de String e StringBuilder

            string[] palavras = { "Palmeiras", "Real Madri", "Barcelona", "Internacional",
                                  "Brasil", "Holanda", "Alemanha", "Desenvolvimento" };

            var totalDePalvras = 100000;
            Console.WriteLine();
            Console.WriteLine("Testando Concatenação de Texto: Total de {0:N2}", totalDePalvras);
            var dataInicioString = DateTime.Now;

            var novaString = string.Empty;
            for (int i = 0; i < totalDePalvras; i++)
            {
                novaString += palavras[random.Next(0, 7)];
            }
            var dataTerminoString = DateTime.Now;
            var tempoString = dataTerminoString - dataInicioString;

            Console.WriteLine($"Tempo utilizado com o string += { tempoString.Minutes }m "
                            + $"{ tempoString.Seconds }s { tempoString.Milliseconds }mm");

            var dataInicioSB = DateTime.Now;
            StringBuilder novaSB = new StringBuilder();

            for (int i = 0; i < totalDePalvras; i++)
            {
                novaSB.Append(palavras[random.Next(0, 7)]);
            }
            var dataTerminoSB = DateTime.Now;
            var tempoSB = dataTerminoSB - dataInicioSB;

            Console.WriteLine($"Tempo utilizado com o StringBuilder { tempoSB.Minutes }m "
                            + $"{ tempoSB.Seconds }s { tempoSB.Milliseconds }mm");

            #endregion
        }

        public static DateTime PrimeiroDiaDoMesConvert(DateTime data)
        {
            return Convert.ToDateTime($"01/{ data.Month }/{data.Year}");
        }

        public static DateTime PrimeiroDiaDoMesNewDateTime(DateTime data)
        {
            return new DateTime(data.Year, data.Month, 1);
        }
    }
}

