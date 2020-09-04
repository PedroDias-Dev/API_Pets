using API_Pets.Context;
using API_Pets.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class TipoDePetRepository
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();
        public TipoDePet Alterar(int id, TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE TipoPet SET Descricao = @descricao, WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            return a;
        }

        public TipoDePet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            TipoDePet a = new TipoDePet();

            while (dados.Read())
            {
                a.IdTipoDePet = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return a;
        }

        public TipoDePet Cadastrar(TipoDePet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText =
                "INSERT INTO TipoPet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM TipoPet WHERE IdTipoPet = @id";
            cmd.Parameters.AddWithValue("@id", id);

            //Use o NonQuery para comandos DML
            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }


        public List<TipoDePet> LerTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM TipoPet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<TipoDePet> tipos = new List<TipoDePet>();

            while (dados.Read())
            {
                tipos.Add(
                    new TipoDePet()
                    {
                        IdTipoDePet = Convert.ToInt32(dados.GetValue(0)),
                        Descricao = dados.GetValue(1).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return tipos;
        }
    }
}
