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
    public class EnderecoRepository : IEnderecoRepository
    {
        private Conexao connection;

        public EnderecoRepository()
        {
            connection = new Conexao();
        }

        public bool Delete(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "DELETE enderecos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            return quantidadeAfetada == 1;
        }

        public int Inserir(Endereco endereco)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO enderecos (unidade_federativa, cidade, logradouro, cep,
numero, complemento) OUTPUT INSERTED.ID VALUES (@UNIDADE_FEDERATIVA, @CIDADE, @LOGRADOURO, @CEP, @NUMERO, @COMPLEMENTO)";
            command.Parameters.AddWithValue("@UNIDADE_FEDERATIVA", endereco.UnidadeFederativa);
            command.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", endereco.Logradouro);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);
            command.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            int id = Convert.ToInt32(command.ExecuteReader());
            command.Connection.Close();
            return id;
        }

        public Endereco ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM enderecos WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if(table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            Endereco endereco = new Endereco();
            endereco.Id = Convert.ToInt32(row["id"]);
            endereco.UnidadeFederativa = row["unidade_federativa"].ToString();
            endereco.Cidade = row["cidade"].ToString();
            endereco.Logradouro = row["logradouro"].ToString();
            endereco.CEP = row["cep"].ToString();
            endereco.Numero = Convert.ToInt32(row["numero"]);
            endereco.Complemento = row["complemento"].ToString();
            return endereco;
            
        }

        public List<Endereco> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM enderecos WHERE unidade_federativa = @UNIDADE_FEDERATIVA";
            busca = $"%{busca}%";
            command.Parameters.AddWithValue("@UNIDADE_FEDERATIVA", busca);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            List<Endereco> enderecos = new List<Endereco>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                Endereco endereco = new Endereco();
                endereco.Id = Convert.ToInt32(row["id"]);
                endereco.UnidadeFederativa = row["unidade_federativa"].ToString();
                endereco.Cidade = row["cidade"].ToString();
                endereco.Logradouro = row["logradouro"].ToString();
                endereco.CEP = row["cep"].ToString();
                endereco.Numero = Convert.ToInt32(row["numero"]);
                endereco.Complemento = row["complemento"].ToString();
                enderecos.Add(endereco);
            }
            command.Connection.Close();
            return enderecos;
        }

        public bool Update(Endereco endereco)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE enderecos SET unidade_federativa = @UNIDADE_FEDERATIVA, cidade = @CIDADE, logradouro = @LOGRADOURO,
cep = @CEP, numero = @NUMERO, complemento = @COMPLEMENTO WHERE id = @ID";
            command.Parameters.AddWithValue("@UNIDADE_FEDERATIVA", endereco.UnidadeFederativa);
            command.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            command.Parameters.AddWithValue("@LOGRADOURO", endereco.Logradouro);
            command.Parameters.AddWithValue("@CEP", endereco.CEP);
            command.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            command.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            command.Parameters.AddWithValue("@ID", endereco.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }
    }
}
