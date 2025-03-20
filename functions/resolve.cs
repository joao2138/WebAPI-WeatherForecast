using System.Security.AccessControl;

namespace WebAPI_WeatherForecast.functions
{
   public static class Resolve
   {

      public static Random rnd = new();

      static readonly string[] summaries =
            [
                 "Frio", "Fresco", "Nublado", "Limpo", "Ensolarado", "Chuvoso", "Úmido", "Tempestade", "Seco"
            ];

      public static string Summarry(int temperature, int humidity)
      {
         if (temperature > 20 && temperature < 27 && humidity < 30)
            return "Seco";

         else if (humidity > 88)
            return "Chuvoso";

         else if (humidity > 60 && temperature > 16 && temperature < 28)
            return "Úmido";

         else if (temperature < 14)
            return "Frio";

         else if (temperature >= 24 && temperature < 29)
            return "Nublado";

         else if (temperature >= 20 && temperature < 30 && humidity > 40)
            return "Limpo";

         else if (temperature > 27 && humidity < 40)
            return "Ensolarado";

         else return summaries[rnd.Next(summaries.Length)];


      }

      public static string IndexUV(int temperature)
      {
         if (temperature > 30)
            return "Alto";

         else if (temperature > 21 && temperature < 30)
            return "Médio";

         else return "Baixo";
      }

      public static int Seed(string? CityAddress)
      {
         if (string.IsNullOrEmpty(CityAddress))
         {
            return DateTime.Now.Minute;
         }
         else
         {
            return DateTime.Now.Minute + CityAddress.Length;
         }
      }

      public static int ThermalSensation(int temperature)
      {
         if (temperature > 40)
            return temperature + 2;

         else
            return temperature + rnd.Next(4, 9);
      }



   }
}
