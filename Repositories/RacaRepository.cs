using API_Pets.Context;
using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class RacaRepository
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public Raca Alterar(int id, Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE Raca SET Descricao = @descricao, WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            return a;
        }

        public Raca BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Raca a = new Raca();

            while (dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return a;
        }

        public Raca Cadastrar(Raca a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO Raca (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM Raca WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //Use o NonQuery para comandos DML
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }


        public List<Raca> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM Raca";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Raca> racas = new List<Raca>();

            while (dados.Read())
            {
                racas.Add(
                    new Raca()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return racas;
        }
    }
}
