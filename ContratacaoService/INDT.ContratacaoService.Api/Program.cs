using INDT.ContratacaoService.Application.UseCases.ContratarProposta;
using INDT.ContratacaoService.Application.UseCases.ListarContratacoes;
using INDT.ContratacaoService.Domain.Ports;
using INDT.ContratacaoService.Infrastructure.HttpClients;
using INDT.ContratacaoService.Infrastructure.Repositories;
// 🔽 NOVO: DbContext e EF Core (Infraestrutura real)
using INDT.ContratacaoService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ===============================
// SERVIÇOS
// ===============================

// Controllers da API (camada de entrada)
builder.Services.AddControllers();

// Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// =======================================================
// 🔁 REPOSITÓRIO — TROCA DE ADAPTER (HEXAGONAL)
// =======================================================

// IMPLEMENTAÇÃO ANTIGA (InMemory)
// Usada para testes e validação inicial da arquitetura
// builder.Services.AddSingleton<IContratacaoRepository, ContratacaoRepositoryInMemory>();

//  IMPLEMENTAÇÃO ATUAL (SQL SERVER)
// Adapter de infraestrutura real, sem impacto no domínio
builder.Services.AddScoped<IContratacaoRepository, ContratacaoRepositoryEf>();


// =======================================================
// 🗄BANCO DE DADOS (EF CORE)
// =======================================================

// DbContext configurado SOMENTE na infraestrutura
// Nenhuma camada acima conhece EF Core
builder.Services.AddDbContext<ContratacaoDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);


// =======================================================
// COMUNICAÇÃO ENTRE SERVIÇOS
// =======================================================

// HttpClient para comunicação com PropostaService
// ContratacaoService NÃO altera proposta — apenas consulta
builder.Services.AddHttpClient<IPropostaServiceClient, PropostaServiceHttpClient>(client =>
{
    // Porta configurável — evita acoplamento
    client.BaseAddress = new Uri("http://localhost:5186");
});


// =======================================================
//  CASOS DE USO (APPLICATION)
// =======================================================

// Regras de negócio — independentes de infraestrutura
builder.Services.AddScoped<ContratarPropostaUseCase>();
builder.Services.AddScoped<ListarContratacoesUseCase>();


var app = builder.Build();

// ===============================
// PIPELINE HTTP
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
