﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class Conexao
    {
        public SqlCommand conectar()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\65970\Documents\Feira.mdf;Integrated Security=True;Connect Timeout=30";
            connection.Open();

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }
    }
}
