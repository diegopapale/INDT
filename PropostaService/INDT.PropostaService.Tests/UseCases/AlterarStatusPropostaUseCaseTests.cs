using INDT.PropostaService.Application.UseCases.AlterarStatusProposta;
using INDT.PropostaService.Domain.Entities;
using INDT.PropostaService.Domain.Enum;
using INDT.PropostaService.Domain.Ports;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

public class AlterarStatusPropostaUseCaseTests
{
    [Fact]
    public async Task Deve_aprovar_proposta()
    {
        // Arrange
        var proposta = new Proposta("Cliente Teste");

        var repositoryMock = new Mock<IPropostaRepository>();
        repositoryMock
            .Setup(r => r.ObterPorIdAsync(proposta.Id))
            .ReturnsAsync(proposta);

        var useCase = new AlterarStatusPropostaUseCase(repositoryMock.Object);

        // Act
        await useCase.AprovarAsync(proposta.Id);

        // Assert
        Assert.Equal(PropostaStatus.Aprovada, proposta.Status);

        repositoryMock.Verify(
            r => r.AtualizarAsync(proposta),
            Times.Once
        );
    }
}
