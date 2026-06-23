using EscolaCrud.Controllers;
using EscolaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EscolaCrud.Pages
{
    public class CadastrarAlunoModel : PageModel
    {
        [BindProperty]
        public Aluno Aluno { get; set; } = new();


        public IActionResult OnPost()
        {
            AlunoController controller = new();
            controller.Inserir(Aluno);
            return RedirectToPage("Aluno");
        }
    }
}


