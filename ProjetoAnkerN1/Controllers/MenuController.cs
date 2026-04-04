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
                        Console.WriteLine("\nVocê escolheu consultar!\n");
                        SubMenuConsultar();
                        break;
                    case 2:
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
                        Console.WriteLine("\nVocê escolheu consultar alunos!\n");
                        AlunoController alunoController = new AlunoController();
                        var lst = alunoController.ConsultarAluno();
                        foreach (var aluno in lst)
                        { 
                            if (aluno == null) break;
                            Console.WriteLine();
                            Console.WriteLine($"Matricula:{aluno.Matricula}\nNome:{aluno.Nome}\nIdade:{aluno.Idade}");
                        }
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("\nVocê escolheu consultar disciplinas!\n");
                        DisciplinaController disciplinaController = new DisciplinaController();
                        var lstDisciplina = disciplinaController.ConsultarDisciplina();
                        foreach(var disciplina in lstDisciplina)
                        {
                            if (disciplina == null) break;
                            Console.WriteLine();
                            Console.WriteLine($"Código:{disciplina.Codigo}\nNome:{disciplina.Nome}\nNota Mínima:{disciplina.NotaMinima}");
                        }
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("\nVocê escolheu consultar alunos da disciplina!\n");
                        break;
                    case 4:
                        Console.WriteLine("\nVocê escolheu consultar disciplinas do aluno!\n");
                        break;
                    case 0:
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
                        Console.WriteLine("\nVocê escolheu cadastrar alunos!\n");
                        break;
                    case 2:
                        Console.WriteLine("\nVocê escolheu cadastrar disciplinas!\n");
                        break;
                    case 3:
                        Console.WriteLine("\nVocê escolheu cadastrar matrículas!\n");
                        break;
                    case 4:
                        Console.WriteLine("\nVocê escolheu atribuir nota a aluno!\n");
                        break;
                    case 0:
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
