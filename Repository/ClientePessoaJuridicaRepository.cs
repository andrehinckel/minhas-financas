using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class ClientePessoaJuridicaRepository : IClientePessoaJuridicaRepository
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
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public int Inserir(ClientePessoaJuridica clientePessoaJuridica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO clientes_pessoa_juridica (cnpj, razao_social, inscricao_estadual) 
OUTPUT INSERTED.ID VALUES (@CNPJ, @RAZAO_SOCIAL, @INSCRICAO_ESTADUAL)";
            command.Parameters.AddWithValue("@CNPJ", clientePessoaJuridica.CNPJ);
            command.Parameters.AddWithValue("@RAZAO_SOCIAL", clientePessoaJuridica.RazaoSocial);
            command.Parameters.AddWithValue("@INSCRICAO_ESTADUAL", clientePessoaJuridica.InscricaoEstadual);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public ClientePessoaJuridica ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_juridica WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if(table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            ClientePessoaJuridica clientePessoaJuridica = new ClientePessoaJuridica();
            clientePessoaJuridica.Id = Convert.ToInt32(row["id"]);
            clientePessoaJuridica.CNPJ = row["cnpj"].ToString();
            clientePessoaJuridica.RazaoSocial = row["razao_social"].ToString();
            clientePessoaJuridica.InscricaoEstadual = row["inscricao_estadual"].ToString();
            return clientePessoaJuridica;
        }

        public List<ClientePessoaJuridica> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_juridica WHERE cnpj LIKE @CNPJ";
            busca = $"%{busca}%";
            command.Parameters.AddWithValue("@CNPJ", busca);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<ClientePessoaJuridica> clientesPessoaJuridica = new List<ClientePessoaJuridica>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                ClientePessoaJuridica clientePessoaJuridica = new ClientePessoaJuridica();
                clientePessoaJuridica.Id = Convert.ToInt32(row["id"]);
                clientePessoaJuridica.CNPJ = row["cnpj"].ToString();
                clientePessoaJuridica.RazaoSocial = row["razao_social"].ToString();
                clientePessoaJuridica.InscricaoEstadual = row["inscricao_estadual"].ToString();
                clientesPessoaJuridica.Add(clientePessoaJuridica);
            }
            command.Connection.Close();
            return clientesPessoaJuridica;

        }

        public bool Update(ClientePessoaJuridica clientePessoaJuridica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE clientes_pessoa_juridica SET cnpj = @CNPJ, razao_social = @RAZAO_SOCIAL,
inscricao_estadual = @INSCRICAO_ESTADUAL WHERE id = @ID";
            command.Parameters.AddWithValue("@CNPJ", clientePessoaJuridica.CNPJ);
            command.Parameters.AddWithValue("@RAZAO_SOCIAL", clientePessoaJuridica.RazaoSocial);
            command.Parameters.AddWithValue("@INSCRICAO_ESTADUAL", clientePessoaJuridica.InscricaoEstadual);
            command.Parameters.AddWithValue("@ID", clientePessoaJuridica.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
