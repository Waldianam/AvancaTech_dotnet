using CopaCrud.Controllers;
using CopaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CopaCrud.Pages
{
    public class ExcluirSelecaoModel : PageModel
    {
        [BindProperty]
        public Selecao Selecao { get; set; } = new();
        public void OnGet(int id)
        {
            SelecaoController controller = new();
            Selecao = controller.BuscarPorId(id);
        }


        public IActionResult OnPost()
        {
            SelecaoController controller = new();
            controller.Excluir(Selecao.Id);
            return RedirectToPage("Selecoes");
        }
    }
}
