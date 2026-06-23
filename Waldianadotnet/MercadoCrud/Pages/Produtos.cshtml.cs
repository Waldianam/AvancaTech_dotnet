using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using MercadoCrud.Models;

namespace MercadoCrud.Pages;

public class ProdutosModel : PageModel
{
    public List<Produto> Produtos = new();

    [BindProperty]
    public string Nome { get; set; }

    [BindProperty]
    public decimal Preco { get; set; }

    [BindProperty]

    public string Imagem {get;set;}

    string conexao =
        "server=localhost;database=mercadodotnet;uid=root;pwd=;";

    public void OnGet()
    {
        CarregarProdutos();
    }

    public IActionResult OnPost()
    {
        MySqlConnection conn =
            new MySqlConnection(conexao);

        conn.Open();

        string sql =
            "INSERT INTO produtos(nome, preco,imagem) VALUES(@nome,@preco,@imagem)";

        MySqlCommand cmd =
            new MySqlCommand(sql, conn);

        cmd.Parameters.AddWithValue("@nome", Nome);
        cmd.Parameters.AddWithValue("@preco", Preco);
        cmd.Parameters.AddWithValue("@imagem", Imagem);

        cmd.ExecuteNonQuery();

        conn.Close();

        return RedirectToPage();
    }

    private void CarregarProdutos()
    {
        MySqlConnection conn =
            new MySqlConnection(conexao);

        conn.Open();

        string sql = "SELECT * FROM produtos";

        MySqlCommand cmd =
            new MySqlCommand(sql, conn);

        MySqlDataReader reader =
            cmd.ExecuteReader();

        while (reader.Read())
        {
            Produtos.Add(new Produto
            {
                Id = Convert.ToInt32(reader["id"]),
                Nome = reader["nome"].ToString(),
                Preco = Convert.ToDecimal(reader["preco"]),
                Imagem = reader["imagem"].ToString()
            });
        }

        conn.Close();
    }
}