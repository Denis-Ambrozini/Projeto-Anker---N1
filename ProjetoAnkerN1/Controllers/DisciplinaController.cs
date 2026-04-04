using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Controllers
{
    public class DisciplinaController
    {
        public Disciplina[] ConsultarDisciplina()
        {
            Disciplina[] lst = new Disciplina[100];
            Console.WriteLine("Consultando disciplinas...");
            string[] consultandoDisciplinas = File.ReadAllLines("Disciplinas.dat");
            int c = 0;
            foreach(string str in consultandoDisciplinas)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string[] dadosDisciplina = str.Split(';');
                Disciplina disciplina = new Disciplina(Convert.ToInt32(dadosDisciplina[0]), dadosDisciplina[1], Convert.ToInt32(dadosDisciplina[2]));
                lst[c++] = disciplina;
            }
            return lst;
        }
    }
}
