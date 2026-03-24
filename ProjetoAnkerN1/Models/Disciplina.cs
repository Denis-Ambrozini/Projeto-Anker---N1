namespace ProjetoAnkerN1.Models
{
    public class Disciplina
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public int NotaMinima { get; set; }

        public Disciplina(int codigo, string nome, int notaMinima)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.NotaMinima = notaMinima;
        }


    }
}
