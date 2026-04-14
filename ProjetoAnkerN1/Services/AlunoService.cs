using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    public class AlunoService
    {
        public Aluno[] CarregarAlunos()
        {
            Aluno[] lst = new Aluno[100];
            string[] linhas = File.ReadAllLines("Aluno.dat");
            int c = 0;
            foreach (string linha in linhas)
            {
                if (string.IsNullOrEmpty(linha)) continue;
                string[] dados = linha.Split(';');
                lst[c++] = new Aluno(int.Parse(dados[0]), dados[1], int.Parse(dados[2]));
            }
            return lst;
        }

        public void Salvar(Aluno[] alunos, int total)
        {
            string[] linhas = new string[total];
            for (int i = 0; i < total; i++)
                linhas[i] = $"{alunos[i].Matricula};{alunos[i].Nome};{alunos[i].Idade}";
            File.WriteAllLines("Aluno.dat", linhas);
        }
    }
}