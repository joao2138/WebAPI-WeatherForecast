namespace WebAPI_WeatherForecast.extensions
{
   public static class BuilderAddServicesExtension
   {
      public static void AddServices(this WebApplicationBuilder builder)
      {
         builder.Services.AddEndpointsApiExplorer();
         builder.Services.AddSwaggerGen();

         builder.Services.AddCors(options =>
         {
            options.AddPolicy("AllowCors",
               policy =>
               {
                  policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
               }
               );

            //builder.WebHost.ConfigureKestrel(options =>
            //{
            //   options.ListenAnyIP(4000);
            //});


         });
      }
   }
}
