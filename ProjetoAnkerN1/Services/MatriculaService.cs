using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    public class MatriculaService
    {
        public Matricula[] CarregarMatriculas()
        {
            Matricula[] lst = new Matricula[100];
            string[] linhas = File.ReadAllLines("Matriculas.dat");
            int c = 0;
            foreach (string linha in linhas)
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] dados = linha.Split(';');
                lst[c++] = new Matricula(int.Parse(dados[0]), int.Parse(dados[1]), int.Parse(dados[2]), int.Parse(dados[3]));
            }
            return lst;
        }

        public void Salvar(Matricula[] matriculas, int total)
        {
            string[] linhas = new string[total];
            for (int i = 0; i < total; i++)
                linhas[i] = $"{matriculas[i].AlunoMatricula};{matriculas[i].DisciplinaId};{matriculas[i].Nota1};{matriculas[i].Nota2}";
            File.WriteAllLines("Matriculas.dat", linhas);
        }
    }
}