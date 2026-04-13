namespace ProjetoAnkerN1.Models
{
    public class Aluno
    {
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Aluno() { } 

        public Aluno(int matricula, string nome, int idade)
        {
            this.Matricula = matricula;
            this.Nome = nome;
            this.Idade = idade;
        }
    }
}
