using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IContaReceberRepository
    {
        int Inserir(ContaReceber contaReceber);

        bool Delete(int id);

        bool Update(ContaReceber contaReceber);

        List<ContaReceber> ObterTodos(string busca);

        ContaReceber ObterPeloId(int id);
    }
}
