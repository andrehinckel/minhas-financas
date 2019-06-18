using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
     interface IClientePessoaFisicaRepository
     {
        int Inserir(ClientePessoaFisica clientePessoaFisica);

        bool Delete(int id);

        bool Update(ClientePessoaFisica clientePessoaFisica);

        List<ClientePessoaFisica> ObterTodos(string busca);

        ClientePessoaFisica ObterPeloId(int id);
     }
}
