using ProjetoAnkerN1.Controllers;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;

namespace ProjetoAnkerN1.Views
{
    public class DisciplinaView
    {
        public void ExibirDisciplina(Disciplina[] disciplinas)
        {
            Console.WriteLine("Consultando Disciplinas...");
            Console.WriteLine();
            foreach (var disciplina in disciplinas)
            {
                if (disciplina == null) continue;
                Console.WriteLine($"Código: {disciplina.Codigo}");
                Console.WriteLine($"Nome: {disciplina.Nome}");
                Console.WriteLine($"Nota Mínima: {disciplina.NotaMinima}\n");
            }
        }

        public string EscolherDisciplinaView()
        {
            Console.WriteLine("Digite o código ou o nome da disciplina:");
            string nomeDisciplina = Console.ReadLine().ToLower().Trim();
            nomeDisciplina = nomeDisciplina.Replace("á", "a")
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

            if(string.IsNullOrWhiteSpace(nomeDisciplina))
            {
                Console.WriteLine("Código ou nome inválido da disciplina! Tente novamente!\n");
                return EscolherDisciplinaView();
            }
            return nomeDisciplina;
        }

        public void ExibirAlunosNaDisciplina(Matricula[] lstalunos, Disciplina disciplina)
        {
            Console.WriteLine($"Alunos na disciplina de {disciplina.Nome}:");
            Console.WriteLine();
            foreach (var aluno in lstalunos)
            {
                if (aluno == null) continue;
                Console.WriteLine($"Nome: {aluno.NomeAluno}");
                Console.WriteLine($"Nota 1: {aluno.Nota1}");
                Console.WriteLine($"Nota 2: {aluno.Nota2}");
                Console.WriteLine($"Média: {aluno.Media}");
                Console.WriteLine($"Situação: {aluno.Situacao}\n");
            }

            if (lstalunos[0] == null)
            {
                Console.WriteLine("Nenhum aluno matriculado nesta disciplina.\n");
            }
        }

        public Disciplina CadastrarDisciplinaView()
        {
            Console.WriteLine("Digite o nome da disciplina:");
            string nome = Console.ReadLine().Trim();
            Console.WriteLine("Digite a nota mínima:");
            int notaMinima = int.Parse(Console.ReadLine());
            return new Disciplina { Nome = nome, NotaMinima = notaMinima };
        }
    }
}
