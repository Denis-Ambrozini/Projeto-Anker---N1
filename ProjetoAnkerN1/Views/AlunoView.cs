using ProjetoAnkerN1.Controllers;
using ProjetoAnkerN1.Models;

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
    }
}
