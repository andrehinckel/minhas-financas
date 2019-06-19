using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    interface IEnderecoRepository
    {
        int Inserir(Endereco endereco);

        bool Delete(int id);

        bool Update(Endereco endereco);

        List<Endereco> ObterTodos(string busca);

        Endereco ObterPeloId(int id);
    }
}
