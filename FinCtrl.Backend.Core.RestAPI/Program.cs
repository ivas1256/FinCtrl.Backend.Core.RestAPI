using FinCtrl.Backend.Core.RestAPI.BL.Implementation;
using FinCtrl.Backend.Core.RestAPI.DAL;
using FinCtrl.Backend.Core.RestAPI.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FinCtrlDBContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabase")));
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddTransient<PaymentSourceRepository>();
builder.Services.AddScoped<PaymentRepository>();

builder.Services.AddScoped<ExcelFileLoader>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
