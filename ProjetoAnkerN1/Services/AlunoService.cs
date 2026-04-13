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

        public Matricula[] BuscarDisciplinasDoAluno(Aluno aluno)
        {
            Matricula[] disciplinasDoAluno = new Matricula[100];
            string[] consultandoMatriculas = File.ReadAllLines("Matriculas.dat");

            int c = 0;
            foreach (string linha in consultandoMatriculas)
            {
                string[] dadosMatricula = linha.Split(';');

                int alunoId = int.Parse(dadosMatricula[0]);
                int disciplinaId = int.Parse(dadosMatricula[1]);
                int nota1 = int.Parse(dadosMatricula[2]);
                int nota2 = int.Parse(dadosMatricula[3]);

                if (alunoId != aluno.Matricula) continue;

                DisciplinaService disciplinaService = new DisciplinaService();
                Disciplina disciplina = disciplinaService.BuscarDisciplinaPorCodigo(disciplinaId);

                if (disciplina == null) continue;

                double media = (nota1 + nota2) / 2.0;
                string situacao;
                if (media >= disciplina.NotaMinima)
                {
                    situacao = "Aprovado";
                }
                else
                {
                    situacao = "Reprovado";
                }

                Matricula matriculaDisciplina = new Matricula(alunoId, disciplinaId, nota1, nota2);
                matriculaDisciplina.NomeDisciplina = disciplina.Nome;
                matriculaDisciplina.Media = media;
                matriculaDisciplina.Situacao = situacao;

                disciplinasDoAluno[c++] = matriculaDisciplina;
            }
            return disciplinasDoAluno;
        }
    }
}
