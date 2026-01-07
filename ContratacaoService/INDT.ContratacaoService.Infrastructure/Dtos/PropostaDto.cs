using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INDT.ContratacaoService.Infrastructure.Dtos
{
    public class PropostaDto
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; } = string.Empty;
        public PropostaStatusDto Status { get; set; }
    }
}
