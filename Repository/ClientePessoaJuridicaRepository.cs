using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ClientePessoaJuridicaRepository : IClientePessoaFisicaRepository
    {

        private Conexao connection;

        public ClientePessoaJuridicaRepository()
        {
            connection = new Conexao();
        }

        public bool Delete(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "DELETE clientes_pessoa_juridica WHERE id = @ID";
            command.Connection.Close();
        }

        public int Inserir(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO (nome, cnpj, razao_social, inscricao_estadual) 
OUTPUT INSERTED.ID VALUES (@NOME, @CNPJ, @RAZAO_SOCIAL, @INSCRICAO_ESTADUAL)";
            command.Connection.Close();
        }

        public ClientePessoaFisica ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_juridica WHERE id = @ID";
            command.Connection.Close();
        }

        public List<ClientePessoaFisica> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_juridica WHERE nome LIKE @NOME";
            command.Connection.Close();
        }

        public bool Update(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE clientes_pessoa_juridica SET nome = @NOME, cnpj = @CNPJ, razao_social = @RAZAO_SOCIAL,
inscricao_estadual = @INSCRICAO_ESTADUAL";
            command.Connection.Close();
        }
    }
}
