using FurnitureAssemblyBusinessLogic.BussinessLogic;
using FurnitureAssemblyBusinessLogic.MailWorker;
using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.StoragesContracts;
using FurnitureAssemblyDatabaseImplement.Implements;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Logging.AddLog4Net("log4net.config");


// Add services to the container.

builder.Services.AddTransient<IClientStorage, ClientStorage>();
builder.Services.AddTransient<IOrderStorage, OrderStorage>();
builder.Services.AddTransient<IFurnitureStorage, FurnitureStorage>();
builder.Services.AddTransient<IImplementerStorage, ImplementerStorage>();
builder.Services.AddTransient<IMessageInfoStorage, MessageInfoStorage>();

builder.Services.AddTransient<IOrderLogic, OrderLogic>();
builder.Services.AddTransient<IClientLogic, ClientLogic>();
builder.Services.AddTransient<IFurnitureLogic, FurnitureLogic>();
builder.Services.AddTransient<IImplementerLogic, ImplementerLogic>();
builder.Services.AddTransient<IMessageInfoLogic, MessageInfoLogic>();

builder.Services.AddSingleton<AbstractMailWorker, MailKitWorker>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Для работы app.UseSwaggerUI
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FurnitureAssemblyRestApi", Version = "v1" });
});

var app = builder.Build();

var mailSender = app.Services.GetService<AbstractMailWorker>();

mailSender?.MailConfig(new MailConfigBindingModel
{
    MailLogin = builder.Configuration?.GetSection("MailLogin")?.Value?.ToString() ?? string.Empty,
    MailPassword = builder.Configuration?.GetSection("MailPassword")?.Value?.ToString() ?? string.Empty,
    SmtpClientHost = builder.Configuration?.GetSection("SmtpClientHost")?.Value?.ToString() ?? string.Empty,
    SmtpClientPort = Convert.ToInt32(builder.Configuration?.GetSection("SmtpClientPort")?.Value?.ToString()),
    PopHost = builder.Configuration?.GetSection("PopHost")?.Value?.ToString() ?? string.Empty,
    PopPort = Convert.ToInt32(builder.Configuration?.GetSection("PopPort")?.Value?.ToString())
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    // Встроенный Swagger для проверки
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FurnitureAssemblyRestApi v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
