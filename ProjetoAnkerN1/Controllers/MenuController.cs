using ProjetoAnkerN1.Views;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Controllers;

namespace ProjetoAnkerN1.Controllers
{
    public class MenuController
    {
        MenuView menuView = new MenuView();
        AlunoController alunoController = new AlunoController();
        DisciplinaController disciplinaController = new DisciplinaController();
        MatriculaController matriculaController = new MatriculaController();
        AlunoView alunoView = new AlunoView();
        DisciplinaView disciplinaView = new DisciplinaView();
        MatriculaView matriculaView = new MatriculaView();

        public void MenuPrincipal()
        {
            bool sair = true;
            while (sair)
            {
                int opcao = menuView.ExibirMenu();
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        SubMenuConsultar();
                        break;
                    case 2:
                        Console.Clear();
                        SubMenuCadastros();
                        break;
                    case 3:
                        Salvar();
                        Console.WriteLine("Dados salvos!");
                        break;
                    case 4:
                        Console.WriteLine("Tem Certeza que deseja sair? (S/N)");
                        string resposta = Console.ReadLine().Trim().ToUpper();
                        if (resposta == "S")
                        {
                            Salvar();
                            sair = false;
                        }
                        break;
                }
            }
        }

        public void SubMenuConsultar()
        {
            bool voltar = true;
            while (voltar)
            {
                int opcao = menuView.ExibirSubMenuConsultar();
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        alunoView.ExibirAlunos(alunoController.lstAlunos);
                        break;
                    case 2:
                        Console.Clear();
                        disciplinaView.ExibirDisciplina(disciplinaController.lstDisciplinas);
                        break;
                    case 3:
                        Console.Clear();
                        Disciplina disciplinaBuscada = disciplinaController.BuscarDisciplina();
                        Matricula[] lstAlunosDisciplina = BuscarAlunosNaDisciplina(disciplinaBuscada);
                        disciplinaView.ExibirAlunosNaDisciplina(lstAlunosDisciplina, disciplinaBuscada);
                        break;
                    case 4:
                        Console.Clear();
                        Aluno alunoBuscado = alunoController.BuscarAluno();
                        Matricula[] lstDisciplinasAluno = BuscarDisciplinasDoAluno(alunoBuscado);
                        alunoView.ExibirAlunos(lstDisciplinasAluno, alunoBuscado);
                        break;
                    case 0:
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
                int opcao = menuView.ExibirSubMenuCadastros();
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Aluno aluno = alunoView.CadastrarAlunoView();
                        alunoController.CadastrarAluno(aluno);
                        break;
                    case 2:
                        Console.Clear();
                        Disciplina disciplina = disciplinaView.CadastrarDisciplinaView();
                        disciplinaController.CadastrarDisciplina(disciplina);
                        break;
                    case 3:
                        Console.Clear();
                        Aluno alunoMatricula = alunoController.BuscarAluno();
                        Disciplina disciplinaMatricula = disciplinaController.BuscarDisciplina();
                        matriculaController.CadastrarMatricula(alunoMatricula.Matricula, disciplinaMatricula.Codigo);
                        break;
                    case 4:
                        Console.Clear();
                        Aluno alunoNota = alunoController.BuscarAluno();
                        Disciplina disciplinaNota = disciplinaController.BuscarDisciplina();
                        int[] notas = matriculaView.AtribuirNotaView();
                        matriculaController.AtribuirNota(alunoNota.Matricula, disciplinaNota.Codigo, notas[0], notas[1]);
                        break;
                    case 0:
                        voltar = false;
                        break;
                }
            }
        }

        private Matricula[] BuscarAlunosNaDisciplina(Disciplina disciplina)
        {
            Matricula[] resultado = new Matricula[100];
            int c = 0;
            foreach (Matricula m in matriculaController.lstMatriculas)
            {
                if (m == null) break;
                if (m.DisciplinaId != disciplina.Codigo) continue;

                foreach (Aluno a in alunoController.lstAlunos)
                {
                    if (a == null) break;
                    if (a.Matricula == m.AlunoMatricula)
                    {
                        double media = (m.Nota1 + m.Nota2) / 2.0;
                        m.NomeAluno = a.Nome;
                        m.Media = media;
                        if (media >= disciplina.NotaMinima)
                        {
                            m.Situacao = "Aprovado";
                        }
                        else
                        {
                            m.Situacao = "Reprovado";
                        }
                        resultado[c++] = m;
                        break;
                    }
                }
            }
            return resultado;
        }

        private Matricula[] BuscarDisciplinasDoAluno(Aluno aluno)
        {
            Matricula[] resultado = new Matricula[100];
            int c = 0;
            foreach (Matricula m in matriculaController.lstMatriculas)
            {
                if (m == null) break;
                if (m.AlunoMatricula != aluno.Matricula) continue;

                foreach (Disciplina d in disciplinaController.lstDisciplinas)
                {
                    if (d == null) break;
                    if (d.Codigo == m.DisciplinaId)
                    {
                        double media = (m.Nota1 + m.Nota2) / 2.0;
                        m.NomeDisciplina = d.Nome;
                        m.Media = media;
                        if (media >= d.NotaMinima)
                        {
                            m.Situacao = "Aprovado";
                        }
                        else
                        {
                            m.Situacao = "Reprovado";
                        }
                        resultado[c++] = m;
                        break;
                    }
                }
            }
            return resultado;
        }

        public void Salvar()
        {
            alunoController.Salvar();
            disciplinaController.Salvar();
            matriculaController.Salvar();
        }
    }
}