using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    public class DisciplinaController
    {
        DisciplinaService disciplinaService = new DisciplinaService();
        public Disciplina[] ConsultarDisciplina()
        {
            return disciplinaService.ConsultarDisciplina();
        }

        public Disciplina BuscarPorNome()
        {
            DisciplinaView disciplinaView = new DisciplinaView();
            string nome = disciplinaView.EscolherDisciplinaView();

            Disciplina[] todas = disciplinaService.ConsultarDisciplina();

            if (string.IsNullOrWhiteSpace(nome))
            {
                Console.WriteLine("Código ou nome inválido da disciplina! Tente novamente!\n");
                return BuscarPorNome();
            }

            foreach (Disciplina d in todas)
            {
                if (d == null) continue;

                if (int.TryParse(nome, out int codigo))
                {
                    if (d.Codigo == codigo) return d;
                }
                else
                {
                    string nomeSemAcento = d.Nome.ToLower()
                    .Replace("á", "a").Replace("ã", "a").Replace("â", "a")
                    .Replace("é", "e").Replace("ê", "e")
                    .Replace("í", "i")
                    .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                    .Replace("ú", "u").Replace("ç", "c");

                    if (nomeSemAcento == nome) return d;
                }
            }

            Console.WriteLine("\nDisciplina não encontrada! Tente novamente!");
            return BuscarPorNome();
        }

        public Matricula[] BuscarAlunosNaDisciplina(Disciplina disciplina)
        {
            return disciplinaService.BuscarAlunosNaDisciplina(disciplina);
        }
    }
}
