using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IClientePessoaJuridicaRepository
    {
        int Inserir(ClientePessoaJuridica clientePessoaJuridica);

        List<ClientePessoaJuridica> ObterTodos(string busca);

        ClientePessoaJuridica ObterPeloId(int id);

        bool Update(ClientePessoaJuridica clientePessoaJuridica);

        bool Delete(int id);
    }
}
