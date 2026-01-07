using Xunit;
using Moq;
using System;
using INDT.PropostaService.Application.UseCases.CriarProposta;
using INDT.PropostaService.Domain.Ports;
using INDT.PropostaService.Domain.Entities;

public class CriarPropostaUseCaseTests
{
    [Fact]
    public async Task Deve_criar_proposta_e_salvar_no_repositorio()
    {
        // Arrange
        var repositoryMock = new Mock<IPropostaRepository>();

        var useCase = new CriarPropostaUseCase(repositoryMock.Object);

        // Act
        var id = await useCase.ExecutarAsync("Cliente Teste");

        // Assert
        Assert.NotEqual(Guid.Empty, id);

        repositoryMock.Verify(
            r => r.AdicionarAsync(It.IsAny<Proposta>()),
            Times.Once
        );
    }
}
