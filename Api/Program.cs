var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddConfiguration(builder.Configuration)
    .AddLogging(loggingBuilder =>
    {
        // configure Logging with NLog
        loggingBuilder.ClearProviders();
        loggingBuilder.SetMinimumLevel(LogLevel.Trace);
        loggingBuilder.AddNLog(builder.Configuration);
    })
    .AddSwagger();

builder.Services
    .LoadServiceServices()
    .LoadApplicationServices()
    .LoadInfrastructureServices()
    .LoadApiServices();

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

app.LoadSwagger();

app.UseRouting()
   .UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader())
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.InitDatabase();
app.Run();
