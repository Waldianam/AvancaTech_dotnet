using EscolaCrud.Models;
using MySql.Data.MySqlClient;

namespace EscolaCrud.Controllers
{
    public class AlunoController
    {
        private readonly string conexao =
            "server=localhost;database=escola;uid=root;pwd=;";

        public List<Aluno> Listar()
        {
            List<Aluno> lista = new();

            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql = "SELECT * FROM alunos";

                MySqlCommand cmd = new(sql, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Aluno
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Nome = reader["nome"].ToString()!,
                            Email = reader["Email"].ToString()!,
                            Telefone = reader["Telefone"].ToString()!,
                            Endereco = Convert.ToInt32(reader["Endereco"]),
                            Unidades = Convert.ToInt32(reader["Unidades"]),
                            Serie = Convert.ToInt32(reader["Serie"])
                        });
                    }
                }
            }

            return lista;
        }

        public void Inserir(Aluno aluno)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    @"INSERT INTO alunos
                    (nome, email, telefone, endereco,unidades,serie)
                    VALUES
                    (@nome,@email,@telefone,@endereco,@unidades,@serie)";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@email", aluno.Email);
                cmd.Parameters.AddWithValue("@telefone", aluno.Telefone);
                cmd.Parameters.AddWithValue("@endereco", aluno.Endereco);
                cmd.Parameters.AddWithValue("@unidades", aluno.Unidades);
                cmd.Parameters.AddWithValue("@serie", aluno.Serie);



                cmd.ExecuteNonQuery();
            }
        }

        public Aluno BuscarPorId(int id)
        {
            Aluno aluno = new();

            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    "SELECT * FROM alunos WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        aluno.Id = Convert.ToInt32(reader["id"]);
                        aluno.Nome = reader["nome"].ToString()!;
                        aluno.Email = reader["email"].ToString()!;
                        aluno.Telefone = reader["telefone"].ToString()!;
                        aluno.Endereco = Convert.ToInt32(reader["endereco"]);
                        aluno.Unidades = Convert.ToInt32(reader["unidades"]);
                        aluno.Serie = Convert.ToInt32(reader["serie"]);
                    }
                }
            }

            return aluno;
        }

        public void Atualizar(Aluno aluno)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    @"UPDATE alunos
                    SET nome=@nome,
                        email=@email,
                        telefone=@telefone,
                        endereco=@endereco,
                        unidades=@unidades
                        serie=@serie
                    WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", aluno.Id);
                cmd.Parameters.AddWithValue("@nome", aluno.Nome);
                cmd.Parameters.AddWithValue("@email", aluno);
                cmd.Parameters.AddWithValue("@telefone", aluno.Telefone);
                cmd.Parameters.AddWithValue("@endereco", aluno.Endereco);
                cmd.Parameters.AddWithValue("@unidades", aluno.Unidades);
                cmd.Parameters.AddWithValue("@serie", aluno.Serie);


                

                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int id)
        {
            using (MySqlConnection conn = new(conexao))
            {
                conn.Open();

                string sql =
                    "DELETE FROM alunos WHERE id=@id";

                MySqlCommand cmd = new(sql, conn);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}