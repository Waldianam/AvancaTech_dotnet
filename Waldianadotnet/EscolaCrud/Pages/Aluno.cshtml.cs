using EscolaCrud.Controllers;
using EscolaCrud.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EscolaCrud.Pages
{
    public class AlunoModel : PageModel
    {
        public List<Aluno> Aluno = new();


        public void OnGet()
        {
            AlunoController controller = new();


            Aluno = controller.Listar();
        }
    }
}


