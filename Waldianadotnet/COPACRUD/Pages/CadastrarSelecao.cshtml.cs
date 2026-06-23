using CopaCrud.Controllers;
using CopaCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CopaCrud.Pages
{
    public class CadastrarSelecaoModel : PageModel
    {
        [BindProperty]
        public Selecao Selecao { get; set; } = new();


        public IActionResult OnPost()
        {
            SelecaoController controller = new();
            controller.Inserir(Selecao);
            return RedirectToPage("Selecoes");
        }
    }
}
