using Xunit;
using Moq;
using System;
using System.Threading.Tasks;
using INDT.ContratacaoService.Application.UseCases.ContratarProposta;
using INDT.ContratacaoService.Domain.Ports;
using INDT.ContratacaoService.Domain.Entities;

public class ContratarPropostaUseCaseTests
{
    [Fact]
    public async Task Deve_criar_contratacao_quando_proposta_estiver_aprovada()
    {
        // Arrange
        var propostaId = Guid.NewGuid();

        var propostaServiceMock = new Mock<IPropostaServiceClient>();
        propostaServiceMock
            .Setup(p => p.PropostaEstaAprovada(propostaId))
            .ReturnsAsync(true);

        var repositoryMock = new Mock<IContratacaoRepository>();

        var useCase = new ContratarPropostaUseCase(
            repositoryMock.Object,
            propostaServiceMock.Object
        );

        // Act
        await useCase.ExecutarAsync(propostaId);

        // Assert
        repositoryMock.Verify(
            r => r.SalvarAsync(It.IsAny<Contratacao>()),
            Times.Once
        );
    }
}
