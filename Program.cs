using WebAPI_WeatherForecast.extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => {
   options.AddPolicy("AllowCors",
   policy => {
      policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
   }
   );
});


//builder.WebHost.ConfigureKestrel(options =>
//{
//   options.ListenAnyIP(4000);
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");


//esta é a rota da api
app.forecastRout();



app.Run();


