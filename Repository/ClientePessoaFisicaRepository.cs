using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientePessoaFisicaRepository: IClientePessoaFisicaRepository
    {
        private Conexao connection;
        
        public ClientePessoaFisicaRepository()
        {
            connection = new Conexao();
        }

        public List<ClientePessoaFisica> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_fisica WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            command.Parameters.AddWithValue("@NOME", busca);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();

            List<ClientePessoaFisica> clientesPessoaFisica = new List<ClientePessoaFisica>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
                clientePessoaFisica.Id = Convert.ToInt32(row["id"]);
                clientePessoaFisica.Nome = row["nome"].ToString();
                clientePessoaFisica.CPF = row["cpf"].ToString();
                clientePessoaFisica.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
                clientePessoaFisica.RG = row["rg"].ToString();
                clientePessoaFisica.Sexo = row["sexo"].ToString();
                clientesPessoaFisica.Add(clientePessoaFisica);
            }
            return clientesPessoaFisica;
            
        }

        public int Inserir(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO clientes_pessoa_fisica (nome, cpf, data_nascimento, rg, sexo)
OUTPUT INSERTED.ID VALUES(@NOME, @CPF, @DATA_NASCIMENTO, @RG, @SEXO)";
            command.Parameters.AddWithValue("@NOME", clientePessoaFisica.Nome);
            command.Parameters.AddWithValue("@CPF", clientePessoaFisica.CPF);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePessoaFisica.DataNascimento);
            command.Parameters.AddWithValue("@RG", clientePessoaFisica.RG);
            command.Parameters.AddWithValue("@SEXO", clientePessoaFisica.Sexo);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public bool Delete(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "DELETE FROM clientes_pessoa_fisica WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = Convert.ToInt32(command.ExecuteNonQuery());
            return quantidadeAfetada == 1;
        }
        
        public bool Update(ClientePessoaFisica clientePessoaFisica)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE clientes_pessoa_fisica SET nome = @NOME, cpf = @CPF, data_nascimento = @DATA_NASCIMENTO,
rg = @RG, sexo = @SEXO WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", clientePessoaFisica.Nome);
            command.Parameters.AddWithValue("@CPF", clientePessoaFisica.CPF);
            command.Parameters.AddWithValue("@DATA_NASCIMENTO", clientePessoaFisica.DataNascimento);
            command.Parameters.AddWithValue("@RG", clientePessoaFisica.RG);
            command.Parameters.AddWithValue("@SEXO", clientePessoaFisica.Sexo);
            command.Parameters.AddWithValue("@ID", clientePessoaFisica.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public ClientePessoaFisica ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM clientes_pessoa_fisica WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if(table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            ClientePessoaFisica clientePessoaFisica = new ClientePessoaFisica();
            clientePessoaFisica.Id = Convert.ToInt32(row["id"]);
            clientePessoaFisica.Nome = row["nome"].ToString();
            clientePessoaFisica.CPF = row["cpf"].ToString();
            clientePessoaFisica.DataNascimento = Convert.ToDateTime(row["data_nascimento"]);
            clientePessoaFisica.RG = row["rg"].ToString();
            clientePessoaFisica.Sexo = row["sexo"].ToString();
            return clientePessoaFisica;
        }
    }
}
