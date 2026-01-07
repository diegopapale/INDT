using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using INDT.PropostaService.Application.UseCases.ListarPropostas;
using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Ports;

public class ListarPropostasUseCaseTests
{
    [Fact]
    public async Task Deve_retornar_lista_de_propostas()
    {
        // Arrange
        var propostas = new List<Proposta>
        {
            new Proposta("Cliente A"),
            new Proposta("Cliente B")
        };

        var repositoryMock = new Mock<IPropostaRepository>();
        repositoryMock
            .Setup(r => r.ListarAsync())
            .ReturnsAsync(propostas);

        var useCase = new ListarPropostasUseCase(repositoryMock.Object);

        // Act
        var resultado = await useCase.ExecutarAsync();

        // Assert
        Assert.Equal(2, resultado.Count());
    }
}
