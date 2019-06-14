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
    public class ContaPagarRepository : IRepository
    {
        private Conexao connection;

        public ContaPagarRepository()
        {
            connection = new Conexao();
        }

        public int Inserir(ContaPagar contaPagar)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"INSERT INTO contas_pagar (nome, valor, tipo, descricao, status)
OUTPUT INSERTED.ID VALUES(@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";
            command.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            command.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            command.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            command.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            command.Parameters.AddWithValue("@STATUS", contaPagar.Status);
            int id = Convert.ToInt32(command.ExecuteScalar());
            command.Connection.Close();
            return id;
        }


        public bool Delete(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "DELETE FROM contas_pagar WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public bool Update(ContaPagar contaPagar)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = @"UPDATE contas_pagar SET nome = @NOME, valor = @VALOR,
tipo = @TIPO, descricao = @DESCRICAO, status = @STATUS WHERE id = @ID";
            command.Parameters.AddWithValue("@NOME", contaPagar.Nome);
            command.Parameters.AddWithValue("@VALOR", contaPagar.Valor);
            command.Parameters.AddWithValue("@TIPO", contaPagar.Tipo);
            command.Parameters.AddWithValue("@DESCRICAO", contaPagar.Descricao);
            command.Parameters.AddWithValue("@STATUS", contaPagar.Status);
            command.Parameters.AddWithValue("@ID", contaPagar.Id);
            int quantidadeAfetada = command.ExecuteNonQuery();
            command.Connection.Close();
            return quantidadeAfetada == 1;
        }

        public ContaPagar ObterPeloId(int id)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM contas_pagar WHERE id = @ID";
            command.Parameters.AddWithValue("@ID", id);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            if(table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            ContaPagar contaPagar = new ContaPagar();
            contaPagar.Id = Convert.ToInt32(row["id"]);
            contaPagar.Nome = row["nome"].ToString();
            contaPagar.Valor = Convert.ToDecimal(row["valor"]);
            contaPagar.Tipo = row["tipo"].ToString();
            contaPagar.Descricao = row["descricao"].ToString();
            contaPagar.Status = row["status"].ToString(); ;
            return contaPagar;
        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand command = connection.conectar();
            command.CommandText = "SELECT * FROM contas_pagar WHERE nome LIKE @NOME";
            busca = $"%{busca}%";
            command.Parameters.AddWithValue("@NOME", busca);
            DataTable table = new DataTable();
            table.Load(command.ExecuteReader());
            command.Connection.Close();
            List<ContaPagar> contasPagar = new List<ContaPagar>();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                DataRow row = table.Rows[i];
                ContaPagar contaPagar = new ContaPagar();
                contaPagar.Id = Convert.ToInt32(row["id"]);
                contaPagar.Nome = row["nome"].ToString();
                contaPagar.Valor = Convert.ToDecimal(row["valor"]);
                contaPagar.Tipo = row["tipo"].ToString();
                contaPagar.Descricao = row["descricao"].ToString();
                contaPagar.Status = row["status"].ToString();
                contasPagar.Add(contaPagar);
            }
            return contasPagar;
        }
    }
}
