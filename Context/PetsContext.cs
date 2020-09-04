using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Context
{
    public class PetsContext
    {
        SqlConnection con = new SqlConnection();

        public PetsContext()
        {
            // 2 - Defino os dados de conexão com meu servidor SQL
            con.ConnectionString = @"Data Source=DESKTOP-5LQ975E\SQLEXPRESS;Initial Catalog=Pets;User ID=sa;Password=sa132;";
        }

        public SqlConnection Conectar()
        {
            // 3 - Verifico se a conexão está fechada para conectar ao banco
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            Console.WriteLine("Conectado");
            return con;
        }

        public void Desconectar()
        {
            // 4 - Verifico se a conexão está aberta para fechar a conexão
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
