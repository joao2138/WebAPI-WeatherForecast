using WebAPI_WeatherForecast.extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowCors");


//esta é a rota da api
app.ForecastRout();



app.Run();