using System.Security.Cryptography.X509Certificates;
using WebAPI_WeatherForecast.functions;

namespace WebAPI_WeatherForecast.models
{
   public record WeatherForecastModel(DateTime date,PlaceModel Place, TodayForecastModel today, IEnumerable<ForecastModel> NextDays);
}
