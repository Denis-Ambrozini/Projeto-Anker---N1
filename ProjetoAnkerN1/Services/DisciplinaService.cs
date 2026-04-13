using System.IO;
using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Views;
using ProjetoAnkerN1.Controllers;
using ProjetoAnkerN1.Services;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace ProjetoAnkerN1.Services
{
    public class DisciplinaService
    {
        public Disciplina[] ConsultarDisciplina()
        {
            Disciplina[] lst = new Disciplina[100];
            string[] consultandoDisciplinas = File.ReadAllLines("Disciplinas.dat");
            int c = 0;
            foreach (string str in consultandoDisciplinas)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string[] dadosDisciplina = str.Split(';');
                Disciplina disciplina = new Disciplina(Convert.ToInt32(dadosDisciplina[0]), dadosDisciplina[1], Convert.ToInt32(dadosDisciplina[2]));
                lst[c++] = disciplina;
            }
            return lst;
        }

        public Matricula[] BuscarAlunosNaDisciplina(Disciplina disciplina)
        {
            Matricula[] alunosNaDisciplina = new Matricula[100];
            string[] consultandoAlunos = File.ReadAllLines("Matriculas.dat");

            int c = 0;
            foreach (string linha in consultandoAlunos)
            {
                string[] alunosDisciplina = linha.Split(';');

                int alunoId = int.Parse(alunosDisciplina[0]);
                int disciplinaId = int.Parse(alunosDisciplina[1]);
                int nota1 = int.Parse(alunosDisciplina[2]);
                int nota2 = int.Parse(alunosDisciplina[3]);

                if (disciplinaId != disciplina.Codigo) continue;

                AlunoService alunoService = new AlunoService();
                Aluno aluno = alunoService.BuscarAlunoPorId(alunoId);

                if (aluno == null)
                    continue;

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

                Matricula alunoDisciplina = new Matricula(alunoId, disciplinaId, nota1, nota2);
                alunoDisciplina.NomeAluno = aluno.Nome;
                alunoDisciplina.Media = media;
                alunoDisciplina.Situacao = situacao;

                alunosNaDisciplina[c++] = alunoDisciplina;
            }
            return alunosNaDisciplina;
        }

        public Disciplina BuscarDisciplinaPorCodigo(int disciplinaCodigo)
        {
            string[] linhas = File.ReadAllLines("Disciplinas.dat");
            foreach (string linha in linhas)
            {
                string[] dados = linha.Split(';');
                int codigo = int.Parse(dados[0]);
                string nome = dados[1];
                int notaMinima = int.Parse(dados[2]);
                if (codigo == disciplinaCodigo)
                {
                    return new Disciplina
                    {
                        Codigo = codigo,
                        Nome = nome,
                        NotaMinima = notaMinima
                    };
                }
            }
            return null;
        }
    }
}
