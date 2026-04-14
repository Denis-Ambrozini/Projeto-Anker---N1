using ProjetoAnkerN1.Controllers;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;

namespace ProjetoAnkerN1.Views
{
    public class AlunoView
    {
        public void ExibirAlunos(Aluno[] alunos)
        {
            Console.WriteLine("Consultando alunos...");
            Console.WriteLine();
            foreach (var aluno in alunos)
            {
                if (aluno == null) break;
                Console.WriteLine($"Matrícula: {aluno.Matricula}");
                Console.WriteLine($"Nome: {aluno.Nome}");
                Console.WriteLine($"Idade: {aluno.Idade}\n");
            }
        }

        public string EscolherAlunoView()
        {
            Console.WriteLine("Digite a matrícula ou o nome do aluno:");
            string nomeAluno = Console.ReadLine().ToLower().Trim();
            nomeAluno = nomeAluno.Replace("á", "a")
             .Replace("ã", "a")
             .Replace("â", "a")
             .Replace("é", "e")
             .Replace("ê", "e")
             .Replace("í", "i")
             .Replace("ó", "o")
             .Replace("ô", "o")
             .Replace("õ", "o")
             .Replace("ú", "u")
             .Replace("ç", "c");

            if (string.IsNullOrWhiteSpace(nomeAluno))
            {
                Console.WriteLine("Matrícula ou nome inválido do aluno! Tente novamente!\n");
                return EscolherAlunoView();
            }

            return nomeAluno;
        }

        public void ExibirAlunos(Matricula[] disciplinasDoAluno, Aluno alunobuscado)
        {
            Console.WriteLine($"\nDisciplinas do aluno {alunobuscado.Nome}:");
            Console.WriteLine();
            foreach (var disciplina in disciplinasDoAluno)
            {
                if (disciplina == null) break;
                Console.WriteLine($"Código da disciplina: {disciplina.DisciplinaId}");
                Console.WriteLine($"Nome da disciplina: {disciplina.NomeDisciplina}");
                Console.WriteLine($"Nota 1: {disciplina.Nota1}");
                Console.WriteLine($"Nota 2: {disciplina.Nota2}\n");
            }
        }

        public Aluno CadastrarAlunoView()
        {
            Console.WriteLine("Digite o nome do aluno:");
            string nomeAluno = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(nomeAluno))
            {
                Console.WriteLine("Nome do aluno inválido! Tente novamente!\n");
                return CadastrarAlunoView();
            }
            Console.WriteLine("Digite a idade do aluno:");
            string idadeAluno = Console.ReadLine();

            return new Aluno { Nome = nomeAluno, Idade = int.Parse(idadeAluno) };
        }
    }
}
