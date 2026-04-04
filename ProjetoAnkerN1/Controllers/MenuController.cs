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
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu consultar!\n");
                        SubMenuConsultar();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu cadastros!\n");
                        SubMenuCadastros();
                        break;
                    case 3:
                        Console.WriteLine("\nVocê escolheu salvar!\n");
                        break;
                    case 4:
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
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu consultar alunos!\n");
                        AlunoController alunoController = new AlunoController();
                        var lstalunos = alunoController.ConsultarAluno();
                        AlunoView alunoView = new AlunoView();
                        alunoView.ExibirAlunos(lstalunos);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu consultar disciplinas!\n");
                        DisciplinaController disciplinaController = new DisciplinaController();
                        var lstdisciplinas = disciplinaController.ConsultarDisciplina();
                        DisciplinaView disciplinaView = new DisciplinaView();
                        disciplinaView.ExibirDisciplina(lstdisciplinas);
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu consultar alunos da disciplina!\n");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu consultar disciplinas do aluno!\n");
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu voltar!\n");
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
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu cadastrar alunos!\n");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu cadastrar disciplinas!\n");
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu cadastrar matrículas!\n");
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("\nVocê escolheu atribuir nota a aluno!\n");
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\\nVocê escolheu voltar!\n");
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
