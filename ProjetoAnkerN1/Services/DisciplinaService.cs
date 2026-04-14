using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    public class DisciplinaService
    {
        public Disciplina[] CarregarDisciplinas()
        {
            Disciplina[] lst = new Disciplina[100];
            string[] linhas = File.ReadAllLines("Disciplinas.dat");
            int c = 0;
            foreach (string linha in linhas)
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] dados = linha.Split(';');
                lst[c++] = new Disciplina(int.Parse(dados[0]), dados[1], int.Parse(dados[2]));
            }
            return lst;
        }

        public void Salvar(Disciplina[] disciplinas, int total)
        {
            string[] linhas = new string[total];
            for (int i = 0; i < total; i++)
                linhas[i] = $"{disciplinas[i].Codigo};{disciplinas[i].Nome};{disciplinas[i].NotaMinima}";
            File.WriteAllLines("Disciplinas.dat", linhas);
        }
    }
}