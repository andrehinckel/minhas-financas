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
    public class ContaReceberRepository : IContaReceberRepository
    {

        private Conexao connection;

        public ContaReceberRepository()
        {
            connection = new Conexao();
        }

        public List<ContaReceber> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM contas_receber WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            command.Parameters.AddWithValue("@NOME", busca);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            List<ContaReceber> ContasReceber = new List<ContaReceber>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                ContaReceber contaReceber = new ContaReceber();
                contaReceber.Id = Convert.ToInt32(row["id"]);
                contaReceber.Nome = row["nome"].ToString();
                contaReceber.Valor = Convert.ToDecimal(row["valor"]);
                contaReceber.Tipo = row["tipo"].ToString();
                contaReceber.Descricao = row["descricao"].ToString();
                contaReceber.Status = row["status"].ToString();
                ContasReceber.Add(contaReceber);
            }
            return ContasReceber;

        }

        public ContaReceber ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM contas_receber WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            if(table.Rows.Count == 0)
            {
                return null;
            }
            DataRow row = table.Rows[0];
            ContaReceber contaReceber = new ContaReceber();
            contaReceber.Id = Convert.ToInt32(row["id"]);
            contaReceber.Nome = row["nome"].ToString();
            contaReceber.Valor = Convert.ToDecimal(row["valor"]);
            contaReceber.Tipo = row["tipo"].ToString();
            contaReceber.Descricao = row["descricao"].ToString();
            contaReceber.Status = row["status"].ToString();
            return contaReceber;
        }
        public int Inserir(ContaReceber contaReceber)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO contas_receber(nome, valor, tipo, descricao, status)
OuTPUT INSERTED.ID VALUES(@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            command.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            command.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            command.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            command.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            command.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }

        public bool Delete(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "DELETE FROM contas_receber WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            return quantidadeAfetada == 1;
        }

        public bool Update(ContaReceber contaReceber)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE contas_receber SET nome = @NOME, valor = @VALOR, tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", contaReceber.Nome);
            command.Parameters.AddWithValue("@VALOR", contaReceber.Valor);
            command.Parameters.AddWithValue("@TIPO", contaReceber.Tipo);
            command.Parameters.AddWithValue("@DESCRICAO", contaReceber.Descricao);
            command.Parameters.AddWithValue("@STATUS", contaReceber.Status);
            command.Parameters.AddWithValue("@ID", contaReceber.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        

    }
}
