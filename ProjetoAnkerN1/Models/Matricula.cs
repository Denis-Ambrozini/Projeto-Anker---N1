namespace ProjetoAnkerN1.Models
{
    public class Matricula
    {
        public string NomeAluno { get; set; }
        public string NomeDisciplina { get; set; }
        public int AlunoMatricula { get; set; }
        public int DisciplinaId { get; set; }
        public int Nota1 { get; set; }
        public int Nota2 { get; set; }
        public double Media { get; set; }
        public string Situacao { get; set; }

        public Matricula(int alunoMatricula, int disciplinaId, int nota1, int nota2)
        {
            this.AlunoMatricula = alunoMatricula;
            this.DisciplinaId = disciplinaId;
            this.Nota1 = nota1;
            this.Nota2 = nota2;
            Situacao = "";
        }
    }
}
