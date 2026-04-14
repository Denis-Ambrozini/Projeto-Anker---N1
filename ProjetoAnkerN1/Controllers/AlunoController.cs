using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    public class AlunoController
    {
        AlunoService alunoService = new AlunoService();
        public Aluno[] lstAlunos = new Aluno[100];
        public int totalAlunos = 0;

        public AlunoController()
        {
            lstAlunos = alunoService.CarregarAlunos();
            foreach (Aluno a in lstAlunos)
            {
                if (a == null) break;
                totalAlunos++;
            }
        }

        public Aluno BuscarAluno()
        {
            AlunoView alunoView = new AlunoView();
            string input = alunoView.EscolherAlunoView();

            foreach (Aluno a in lstAlunos)
            {
                if (a == null) break;
                if (int.TryParse(input, out int matricula))
                {
                    if (a.Matricula == matricula) return a;
                }
                else
                {
                    string nomeSemAcento = a.Nome.ToLower()
                        .Replace("á", "a").Replace("ã", "a").Replace("â", "a")
                        .Replace("é", "e").Replace("ê", "e")
                        .Replace("í", "i")
                        .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                        .Replace("ú", "u").Replace("ç", "c");
                    if (nomeSemAcento == input) return a;
                }
            }

            Console.WriteLine("Aluno não encontrado. Tente novamente!");
            return BuscarAluno();
        }

        public void CadastrarAluno(Aluno aluno)
        {
            aluno.Matricula = GerarMatricula();
            lstAlunos[totalAlunos++] = aluno;
            Console.WriteLine($"Aluno cadastrado com matrícula {aluno.Matricula}!");
        }

        public int GerarMatricula()
        {
            int maior = 0;
            foreach (Aluno a in lstAlunos)
            {
                if (a == null) break;
                if (a.Matricula > maior) maior = a.Matricula;
            }
            return maior + 1;
        }

        public void Salvar()
        {
            alunoService.Salvar(lstAlunos, totalAlunos);
        }
    }
}