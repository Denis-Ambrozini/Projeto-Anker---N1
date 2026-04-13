using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    public class AlunoController
    {
        AlunoService alunoService = new AlunoService();
        public Aluno[] ConsultarAluno()
        {
            return alunoService.ConsultarAluno();
        }

        public Aluno BuscarDisciplinas()
        {
            AlunoView alunoView = new AlunoView();
            string nomedoAluno = alunoView.EscolherAlunoView();

            Aluno[] alunos = alunoService.ConsultarAluno();

            foreach (Aluno a in alunos)
            {
                if(a == null) continue;

                if (int.TryParse(nomedoAluno, out int codigo))
                {
                    if (a.Matricula == codigo) return a;
                }
                else
                {
                    string nomeSemAcento = a.Nome.ToLower()
                    .Replace("á", "a").Replace("ã", "a").Replace("â", "a")
                    .Replace("é", "e").Replace("ê", "e")
                    .Replace("í", "i")
                    .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                    .Replace("ú", "u").Replace("ç", "c");

                    if (nomeSemAcento == nomedoAluno) return a;
                }
            }
            Console.WriteLine("Aluno não encontrado.");
            return BuscarDisciplinas();
        }

        public Matricula[] BuscarDisciplinasDoAluno(Aluno aluno)
        {
            return alunoService.BuscarDisciplinasDoAluno(aluno);
        }
    }
}
