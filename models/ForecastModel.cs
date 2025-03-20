using WebAPI_WeatherForecast.functions;

namespace WebAPI_WeatherForecast.models
{
   public record ForecastModel(string DayOfWeek, int TemperatureC, int Humidity)
   {

      public string IndexUV => Resolve.IndexUV(TemperatureC);

      public string Summary => Resolve.Summarry(TemperatureC, Humidity);
   }
}
