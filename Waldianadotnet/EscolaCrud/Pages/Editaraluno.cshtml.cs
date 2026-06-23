using EscolaCrud.Controllers;
using EscolaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EscolaCrud.Pages
{
    public class EditarAlunoModel : PageModel
    {
        [BindProperty]
        public Aluno Aluno { get; set; } = new();
        public void OnGet(int id)
        {
            AlunoController controller = new();
            Aluno = controller.BuscarPorId(id);
        }


        public IActionResult OnPost()
        {
            AlunoController controller = new();
            controller.Atualizar(Aluno);
            return RedirectToPage("Aluno");
        }
    }
}
