# INDT – Proposta & Contratação Services

Este repositório contém a implementação de dois serviços independentes, desenvolvidos como parte de um teste técnico, com foco em **arquitetura limpa**, **boas práticas**, **persistência em banco de dados** e **testes unitários**.

O objetivo principal foi demonstrar capacidade de modelagem, separação de responsabilidades e maturidade em decisões arquiteturais.

---

## Arquitetura Geral

O projeto é composto por **dois serviços independentes**, cada um com seu próprio banco de dados:

### PropostaService
Responsável por:
- Criar propostas
- Listar propostas
- Aprovar ou rejeitar propostas
- Persistir propostas em banco de dados próprio

### ContratacaoService
Responsável por:
- Criar contratações somente a partir de propostas aprovadas
- Listar contratações
- Persistir contratações em banco de dados próprio
- Consultar o status da proposta via HTTP

Cada serviço segue o mesmo padrão arquitetural:

	Api
	Application
	Domain
	Infrastructure
	Tests
	
	
---

# Decisões Arquiteturais

 Clean Architecture
- **Domain**: regras de negócio puras (entidades e contratos)
- **Application**: casos de uso
- **Infrastructure**: EF Core, repositórios e HTTP clients
- **Api**: controllers e configuração

Essa separação garante:
- Testabilidade
- Baixo acoplamento
- Facilidade de manutenção

---

## Persistência de Dados

- Utilizado **Entity Framework Core**
- Cada serviço possui:
  - `DbContext` próprio
  - Banco de dados próprio (ex: `PropostaDB`, `ContratacaoDB`)
- Migrations criadas e aplicadas via EF Core

---

## Comunicação entre Serviços

O `ContratacaoService` consulta o `PropostaService` via HTTP para validar se uma proposta está aprovada antes de criar uma contratação.

Essa comunicação é feita através da interface:	IPropostaServiceClient


permitindo:
- Mock em testes
- Baixo acoplamento
- Evolução futura para mensageria

---

## Consistência e Transações Distribuídas

Cada serviço grava em seu próprio banco, sem transação distribuída.

Cenário possível:
1. Proposta é aprovada
2. Falha ao criar contratação
3. Proposta permanece aprovada sem contratação

Essa decisão assume **consistência eventual**, comum em arquiteturas distribuídas.

Alternativas possíveis (não implementadas por escopo):
- Saga Pattern
- Eventos de domínio
- Mensageria
- Processos de compensação

---

## Testes Unitários

Os testes foram implementados em projetos separados (`*.Tests`) para cada serviço.

### Ferramentas utilizadas
- **xUnit**
- **Moq**
- **.NET Test SDK**

---

###  O que os testes validam

#### PropostaService
- Criação de propostas
- Alteração de status (aprovar / rejeitar)
- Listagem de propostas

#### ContratacaoService
- Contratação só é criada quando a proposta está aprovada
- Repositório é acionado corretamente
- Regras de negócio são respeitadas

---

### Exemplo de teste unitário

```csharp
[Fact]
public async Task Deve_criar_proposta_e_salvar_no_repositorio()
{
    var repositoryMock = new Mock<IPropostaRepository>();
    var useCase = new CriarPropostaUseCase(repositoryMock.Object);

    var id = await useCase.ExecutarAsync("Cliente Teste");

    Assert.NotEqual(Guid.Empty, id);

    repositoryMock.Verify(
        r => r.AdicionarAsync(It.IsAny<Proposta>()),
        Times.Once
    );
}
```

Os testes **não acessam banco de dados real**.  
Os repositórios são **mockados**, garantindo testes rápidos e isolados.

### Executando os testes

Na raiz do projeto de testes:

```bash
dotnet test
```

Todos os testes são descobertos e executados automaticamente.

---

## Executando a Aplicação

### 1. Aplicar migrations

```bash
dotnet ef database update
```

### 2. Executar os serviços

```bash
dotnet run
```

### 3. Acessar o Swagger

- **PropostaService**: http://localhost:5186/swagger  
- **ContratacaoService**: http://localhost:5231/swagger  

---

## Considerações Finais

Este projeto foi desenvolvido com foco em:

- Boas práticas
- Testabilidade
- Clareza arquitetural
- Decisões técnicas conscientes

Mesmo sendo um teste técnico, a solução foi pensada como um **cenário real de produção**.
