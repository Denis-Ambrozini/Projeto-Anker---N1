namespace ProjetoAnkerN1.Models
{
    public class Matricula
    {
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public int[] Notas { get; set; }
        public int Media { get; set; }
        public string Situacao { get; set; }

        public Matricula(Aluno aluno, Disciplina disciplina, int[] notas)
        {
            this.Aluno = aluno;
            this.Disciplina = disciplina;
            this.Notas = notas;
            Situacao = "";
        }


    }
}
