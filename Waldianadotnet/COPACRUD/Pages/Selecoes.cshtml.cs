using CopaCrud.Controllers;
using CopaCrud.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace CopaCrud.Pages
{
    public class SelecoesModel : PageModel
    {
        public List<Selecao> Selecoes = new();


        public void OnGet()
        {
            SelecaoController controller = new();


            Selecoes = controller.Listar();
        }
    }
}






