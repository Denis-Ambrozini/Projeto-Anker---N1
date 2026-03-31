using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Controllers
{
    public class AlunoController
    {
        public Aluno[] ConsultarAluno()
        {
            Aluno[] lst = new Aluno[100];
            Console.WriteLine("Consultando alunos...");
            string[] consultandoAlunos = File.ReadAllLines("Aluno.dat");
            int c = 0;
            foreach(string str in consultandoAlunos)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string[] dadosAluno = str.Split(';');
                Aluno aluno = new Aluno(Convert.ToInt32(dadosAluno[0]), dadosAluno[1], Convert.ToInt32(dadosAluno[2]));
                lst[c++] = aluno;
            }
            return lst;
        }
    }
}
