using WebAPI_WeatherForecast.functions;

namespace WebAPI_WeatherForecast.models
{
   public record TodayForecastModel(string DayOfWeek, int TemperatureC, int humidity)
   {
      public int maxTmperature => TemperatureC + 1 + (Resolve.rnd.Next(3));

      public int minTmperature => TemperatureC - (Resolve.rnd.Next(4));

      public string IndexUV => Resolve.IndexUV(TemperatureC);

      public string Summary => Resolve.Summarry(TemperatureC, humidity);

      public int ThermalSensation => Resolve.ThermalSensation(TemperatureC);
   }
}
