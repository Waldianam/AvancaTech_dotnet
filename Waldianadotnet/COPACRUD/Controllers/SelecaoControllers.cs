using CopaCrud.Models;
using MySql.Data.MySqlClient;

namespace CopaCrud.Controllers
{
    public class SelecaoController
    {
        private readonly string conexao =
            "server=localhost;database=copadomundo;uid=root;pwd=;";

        public List<Selecao> Listar()
        {
            List<Selecao> lista = new();

            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql = "SELECT * FROM selecoes";

                MySqlCommand cmd = new(sql, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Selecao
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString()!,
                            Grupo = reader["grupo"].ToString()!,
                            Continente = reader["continente"].ToString()!,
                            Titulos = Convert.ToInt32(reader["titulos"])
                        });
                    }
                }
            }

            return lista;
        }

        public void Inserir(Selecao selecao)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    @"INSERT INTO selecoes
                    (nome, grupo, continente, titulos)
                    VALUES
                    (@nome,@grupo,@continente,@titulos)";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@nome", selecao.Nome);
                cmd.Parameters.AddWithValue("@grupo", selecao.Grupo);
                cmd.Parameters.AddWithValue("@continente", selecao.Continente);
                cmd.Parameters.AddWithValue("@titulos", selecao.Titulos);

                cmd.ExecuteNonQuery();
            }
        }

        public Selecao BuscarPorId(int id)
        {
            Selecao selecao = new();

            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    "SELECT * FROM selecoes WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        selecao.Id = Convert.ToInt32(reader["id"]);
                        selecao.Nome = reader["nome"].ToString()!;
                        selecao.Grupo = reader["grupo"].ToString()!;
                        selecao.Continente = reader["continente"].ToString()!;
                        selecao.Titulos = Convert.ToInt32(reader["titulos"]);
                    }
                }
            }

            return selecao;
        }

        public void Atualizar(Selecao selecao)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    @"UPDATE selecoes
                    SET nome=@nome,
                        grupo=@grupo,
                        continente=@continente,
                        titulos=@titulos
                    WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", selecao.Id);
                cmd.Parameters.AddWithValue("@nome", selecao.Nome);
                cmd.Parameters.AddWithValue("@grupo", selecao.Grupo);
                cmd.Parameters.AddWithValue("@continente", selecao.Continente);
                cmd.Parameters.AddWithValue("@titulos", selecao.Titulos);

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    "DELETE FROM selecoes WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
