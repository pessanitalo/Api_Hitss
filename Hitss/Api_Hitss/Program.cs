using Api_Hitss.Context;
using Api_Hitss.Interface;
using Api_Hitss.Repository;
using Api_Hitss.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IPropostaRepository, PropostaRepository>();
builder.Services.AddScoped<IPropostaService, PropostaService>();

builder.Services.AddScoped<IPaymentFlowSummaryRepository, PaymentFlowSummaryRepository>();
builder.Services.AddScoped<IPaymentScheduleRepository, PaymentScheduleRepository>();
builder.Services.AddScoped<IPaymentScheduleService, PaymentScheduleService>();
builder.Services.AddScoped<IPaymentFlowSummaryService, PaymentFlowSummaryService>();
builder.Services.AddScoped<IPaymentScheduleCalcService, PaymentScheduleCalcService>();
builder.Services.AddScoped<IPaymentScheduleCalcService, PaymentScheduleCalcService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
