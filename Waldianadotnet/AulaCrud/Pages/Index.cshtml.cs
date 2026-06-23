using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using AULACRUD.Models;
using AULACRUD.Services;

namespace AULACRUD.Pages
{
    public class Indexmodel : PageModel
    {
        Conexao con = new Conexao();
        
        [BindProperty] 
        public Aluno NovoAluno{get; set;}

        public List<Aluno> ListaAlunos = new List<Aluno>();

        public void OnGet()
        {
            BuscarAlunos();

        }
        public void OnPost()
        {
            var conn= con.Conectar();
            conn.Open();

            string sql = "INSERT INTO Alunos(nome, idade) VALUES (@nome, @idade)";

            MySqlCommand cmd= new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nome",NovoAluno.Nome);
            cmd.Parameters.AddWithValue("@idade", NovoAluno.Idade);

            cmd.ExecuteNonQuery();

            conn.Close();

            BuscarAlunos();

        }

        public void BuscarAlunos()
        {
            var conn = con.Conectar();

            conn.Open();

            string sql = "SELECT * FROM alunos";

            MySqlCommand cmd = new MySqlCommand(sql, conn);

            MySqlDataReader dados = cmd.ExecuteReader();

            while(dados.Read())
            {
                ListaAlunos.Add(new Aluno
                {
                    Id = dados.GetInt32("id"),
                    Nome = dados.GetString("nome"),
                    Idade = dados.GetInt32("idade")


                });
            }

            conn.Close();


        }
    }
}