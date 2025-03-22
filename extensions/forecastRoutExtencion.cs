using System.Globalization;
using WebAPI_WeatherForecast.functions;
using WebAPI_WeatherForecast.models;

namespace WebAPI_WeatherForecast.extensions
{
   public static class ForecastRoutExtencion
   {
      public static void ForecastRout(this WebApplication app)
      {
         app.MapGet("/weatherforecast", (string? City) =>
         {
            //minha ideia é tentar gerar uma previsão aleatoria sempre que
            //não for passado um endereço
            //se passado o endereço, então gero uma seed com base no numero de caracteres
            //dessa string + a data, assim sempre que fizer a busca pela
            //previsão do tempo de "Vitoria" (exemplo) no mesmo horario,
            //a previsão será a mesma para aquele local, 
            //tentando não ser sempre "uma previsão aleatoria"

            //o endereço pode ser null só não pode ser menor do que 4 caracteres
            if (City != null && City.Length < 4)
               return Results.BadRequest($"Invalid address '{City}'");


            DateTime date = DateTime.Now;

            //definindo a seed
            int seed = Resolve.Seed(City);
            Random rnd = new(seed);
            Resolve.rnd = rnd;

            //criando um gerador aleatorio a parte, para que sempre que se consultar
            //em um local especifico, a coordenada não mude
            Resolve.PlaceRnd = new(City?.Length ?? 10);


            var culture = new CultureInfo("pt-BR");


            //gerando a previsão do dia atual
            var today = new TodayForecastModel(
               DayOfWeek: date.ToString("dddd", culture),  //dia da semana formatado
               TemperatureC: rnd.Next(8, 45),              //temperatura
               humidity: rnd.Next(0, 101)                  //% de umidade
            );                                    //temperatura min e max

            //temp Max e min são geradas dentro da classe <TodayForecastModel>


            //gerando as previsões dos proximos dias
            var forecasts = Enumerable.Range(1, 7).Select(index =>
                new ForecastModel
                (
                    DayOfWeek: date.AddDays(index).ToString("ddd", culture),
                    TemperatureC: rnd.Next(8, 50),
                    Humidity: rnd.Next(0, 101)
                ));



            return Results.Ok(
            new WeatherForecastModel
            (
               date,
               Place: new PlaceModel(
                     country: "Brazil",
                     City: City ?? "Vila Velha",
                     Long: Resolve.PlaceRnd.NextDouble() * 360 - 180, //simulando coordenadas
                     lat: Resolve.PlaceRnd.NextDouble() * 180 - 90    //geográficas
                     ),
               today,
               NextDays: forecasts
            )
            );

         })
         .Produces<WeatherForecastModel>(200)
         .Produces(400)
         .WithName("GetWeatherForecast")
         .WithOpenApi();
         //fim do endpoint




      }


   }
}
