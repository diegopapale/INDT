using Xunit;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using INDT.ContratacaoService.Application.UseCases.ListarContratacoes;
using INDT.ContratacaoService.Domain.Entities;
using INDT.ContratacaoService.Domain.Ports;

public class ListarContratacoesUseCaseTests
{
    [Fact]
    public async Task Deve_retornar_lista_de_contratacoes()
    {
        // Arrange
        var contratacoes = new List<Contratacao>
        {
            new Contratacao(Guid.NewGuid()),
            new Contratacao(Guid.NewGuid())
        };

        var repositoryMock = new Mock<IContratacaoRepository>();
        repositoryMock
            .Setup(r => r.ListarAsync())
            .ReturnsAsync(contratacoes);

        var useCase = new ListarContratacoesUseCase(repositoryMock.Object);

        // Act
        var resultado = await useCase.ExecutarAsync();

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal(2, resultado.Count());
    }
}
