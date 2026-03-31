using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    public class MenuController
    {
        public MenuView menuView = new MenuView();

        public void MenuPrincipal()
        {
            bool sair = true;
            while (sair) {
                int menuView = this.menuView.ExibirMenu();
                switch (menuView)
                {
                    case 1:
                        Console.WriteLine("Você escolheu consultar!");
                        SubMenuConsultar();
                        break;
                    case 2:
                        Console.WriteLine("Você escolheu cadastros!");
                        SubMenuCadastros();
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu salvar!");
                        break;
                    case 4:
                        Console.WriteLine("Você escolheu sair!");
                        sair = false;
                        break;
                }
            }
        }

        public void SubMenuConsultar()
        {
            bool voltar = true;
            while (voltar)
            {
                int menuView = this.menuView.ExibirSubMenuConsultar();
                switch (menuView)
                {
                    case 1:
                        Console.WriteLine("Você escolheu consultar alunos!");
                        AlunoController alunoController = new AlunoController();
                        var lst = alunoController.ConsultarAluno();
                        foreach (var aluno in lst)
                        { 
                            if (aluno == null) break;
                            Console.WriteLine();
                            Console.WriteLine($"Matricula:{aluno.Matricula}\nNome:{aluno.Nome}\nIdade:{aluno.Idade}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Você escolheu consultar disciplinas!");
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu consultar alunos da disciplina!");
                        break;
                    case 4:
                        Console.WriteLine("Você escolheu consultar disciplinas do aluno!");
                        break;
                    case 0:
                        Console.WriteLine("Você escolheu voltar!");
                        voltar = false;
                        break;
                }
            }
        }

        public void SubMenuCadastros()
        {
            bool voltar = true;
            while (voltar)
            {
                int menuView = this.menuView.ExibirSubMenuCadastros();
                switch (menuView)
                {
                    case 1:
                        Console.WriteLine("Você escolheu cadastrar alunos!");
                        break;
                    case 2:
                        Console.WriteLine("Você escolheu cadastrar disciplinas!");
                        break;
                    case 3:
                        Console.WriteLine("Você escolheu cadastrar matrículas!");
                        break;
                    case 4:
                        Console.WriteLine("Você escolheu atribuir nota a aluno!");
                        break;
                    case 0:
                        Console.WriteLine("Você escolheu voltar!");
                        voltar = false;
                        break;
                }
            }
        }

        public void Salvar()
        {

        }
    }
}
