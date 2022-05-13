using MediatR;
using MVP.Controllers;
using MVP.Extensions;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.Never;
    options.JsonSerializerOptions.WriteIndented = false;
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies())
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddLogging(log =>
{
    log.ClearProviders();

    if (!builder.Environment.IsDevelopment())
    {
        log.SetMinimumLevel(LogLevel.Information);
    }
    else
    {
        log.AddConsole();
    };
});

builder.Services.AddOptions()
    .ConfigureOptions(builder.Configuration)
    .AddAvengersService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(builder=> builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseAuthorization();

app.Map("/alive", builder => builder.Run(context => Task.CompletedTask));
app.MapGet("/", () => "Global Azure Bootcamp: Avengers API");

app.MapControllers();

app.Run();
