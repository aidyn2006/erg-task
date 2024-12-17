using ERG_Task.Data;
using ERG_Task.Repository;
using ERG_Task.Repository.impl;
using ERG_Task.Services;
using ERG_Task.Services.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddScoped<IEventHistoryRepository, EventHistoryRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IGenealogyRepository, GenealogyRepository>();
builder.Services.AddScoped<IInvoiceHistoryRepository, InvoiceHistoryRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IPackageHistoryRepository, PackageHistoryRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();
builder.Services.AddScoped<ISupplyRepository, SupplyRepository>();
builder.Services.AddScoped<ITrainHistoryRepository, TrainHistoryRepository>();
builder.Services.AddScoped<ITrainRepository, TrainRepository>();
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IGenealogyService, GenealogyService>();
builder.Services.AddScoped<IInvoiceService, InvoiceService>();
builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<ISupplyService, SupplyService>();
builder.Services.AddScoped<ITrainService, TrainService>();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy.WithOrigins("http://localhost:63343") 
            .AllowAnyMethod()                     
            .AllowAnyHeader();                    
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins");
app.UseMiddleware<GlobalExceptionMiddleware>();
app.MapControllers();
app.Run();

