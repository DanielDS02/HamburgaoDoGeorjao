using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgaoDoGeorjao.DAO.ValueObjects
{
    public class ClienteVo : EntidadeBaseVo
    {
        
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public EnderecoVo EnderecoVo { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
