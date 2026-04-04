using ProjetoAnkerN1.Controllers;
using ProjetoAnkerN1.Models;

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
    }
}
