using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;

namespace ProjetoAnkerN1.Controllers
{
    public class AlunoController
    {
        AlunoService alunoService = new AlunoService();
        public Aluno[] ConsultarAluno()
        {
            return alunoService.ConsultarAluno();
        }
    }
}
