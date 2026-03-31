using ProjetoAnkerN1.Controllers;

namespace ProjetoAnkerN1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var menuController = new MenuController();
            menuController.MenuPrincipal();
        }
    }
}
