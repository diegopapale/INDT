using INDT.ContratacaoService.Domain.Entities;
using INDT.ContratacaoService.Domain.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Infrastructure.Repositories
{
    public class ContratacaoRepositoryInMemory //: IContratacaoRepository
    {
        private static readonly List<Contratacao> _contratacoes = new();

        public void Salvar(Contratacao contratacao)
        {
            _contratacoes.Add(contratacao);
        }

        public void Adicionar(Contratacao contratacao)
        {
            _contratacoes.Add(contratacao);
        }

        public IEnumerable<Contratacao> Listar()
            => _contratacoes;
    }
}
