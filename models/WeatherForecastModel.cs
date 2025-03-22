namespace WebAPI_WeatherForecast.models
{
   public record WeatherForecastModel(DateTime date,PlaceModel Place, TodayForecastModel today, IEnumerable<ForecastModel> NextDays);
}
