using System.IO;
using ProjetoAnkerN1.Models;

namespace ProjetoAnkerN1.Services
{
    public class AlunoService
    {
        public Aluno[] ConsultarAluno()
        {
            Aluno[] lst = new Aluno[100];
            string[] consultandoAlunos = File.ReadAllLines("Aluno.dat");
            int c = 0;
            foreach (string str in consultandoAlunos)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string[] dadosAluno = str.Split(';');
                Aluno aluno = new Aluno(Convert.ToInt32(dadosAluno[0]), dadosAluno[1], Convert.ToInt32(dadosAluno[2]));
                lst[c++] = aluno;
            }
            return lst;
        }

        public Aluno BuscarAlunoPorId(int alunoId)
        {
            string[] linhas = File.ReadAllLines("Aluno.dat");

            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(';');

                int id = int.Parse(dados[0]);
                string nome = dados[1];

                if (id == alunoId)
                {
                    return new Aluno
                    {
                        Matricula = id,
                        Nome = nome
                    };
                }
            }

            return null;
        }
    }
}
