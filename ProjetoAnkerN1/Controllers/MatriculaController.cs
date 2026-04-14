using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;

namespace ProjetoAnkerN1.Controllers
{
    public class MatriculaController
    {
        MatriculaService matriculaService = new MatriculaService();
        public Matricula[] lstMatriculas = new Matricula[100];
        public int totalMatriculas = 0;

        public MatriculaController()
        {
            lstMatriculas = matriculaService.CarregarMatriculas();
            foreach (Matricula m in lstMatriculas)
            {
                if (m == null) break;
                totalMatriculas++;
            }
        }

        public void CadastrarMatricula(int alunoMatricula, int disciplinaId)
        {
            Matricula matricula = new Matricula(alunoMatricula, disciplinaId, 0, 0);
            lstMatriculas[totalMatriculas++] = matricula;
            Console.WriteLine("Matrícula cadastrada!");
        }

        public void AtribuirNota(int alunoMatricula, int disciplinaId, int nota1, int nota2)
        {
            foreach (Matricula m in lstMatriculas)
            {
                if (m == null) break;
                if (m.AlunoMatricula == alunoMatricula && m.DisciplinaId == disciplinaId)
                {
                    m.Nota1 = nota1;
                    m.Nota2 = nota2;
                    Console.WriteLine("Notas atribuídas!");
                    return;
                }
            }
            Console.WriteLine("Matrícula não encontrada!");
        }

        public void Salvar()
        {
            matriculaService.Salvar(lstMatriculas, totalMatriculas);
        }
    }
}