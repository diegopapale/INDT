using INDT.PropostaService.Domain.Ports;
using INDT.PropostaService.Infrastructure.Repositories;
using INDT.PropostaService.Infrastructure.Persistence;
using INDT.PropostaService.Application.UseCases.CriarProposta;
using INDT.PropostaService.Application.UseCases.ListarPropostas;
using INDT.PropostaService.Application.UseCases.AlterarStatusProposta;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// SERVIÇOS
// ===============================

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// ===============================
// BANCO DE DADOS (EF CORE)
// ===============================

builder.Services.AddDbContext<PropostaDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// ===============================
// PORTA → ADAPTER (REPOSITORY)
// ===============================


// builder.Services.AddSingleton<IPropostaRepository, PropostaRepositoryInMemory>();
builder.Services.AddScoped<IPropostaRepository, PropostaRepositoryEf>();


// ===============================
// CASOS DE USO (APPLICATION)
// ===============================

builder.Services.AddScoped<CriarPropostaUseCase>();
builder.Services.AddScoped<ListarPropostasUseCase>();
builder.Services.AddScoped<AlterarStatusPropostaUseCase>();


var app = builder.Build();

// ===============================
// PIPELINE
// ===============================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
