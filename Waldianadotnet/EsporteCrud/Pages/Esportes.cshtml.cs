using System.Data.SqlTypes;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace EsporteCrud.Pages;

public class EsportesModel : PageModel
{    public List<Esporte> Esportes{get; set;} = new();
     public void OnGet()
    {
        string conexao = "server=localhost;database=esportedotnet;user=root;password=";

        using MySqlConnection conn = new(conexao);

        conn.Open();
        string sql = "SELECT * FROM esportes";

        using MySqlCommand cmd =new(sql,conn);
        
        using var reader = cmd.ExecuteReader();

        while(reader.Read())
        {
            Esportes.Add(new Esporte
            {
                Id= Convert.ToInt32(reader["id"]),
                Nome = reader["nome"].ToString(),
                Categoria= reader["categoria"].ToString(),
                Jogadores = Convert.ToInt32(reader["jogadores"])

            });


        }
    }
}
        

public class Esporte
{    public int Id {get; set;}
    public string Nome{get; set;}= "Futebol";
    public string Categoria{get; set;}= "Coletivo";
    public int Jogadores{get; set;}=11;
}