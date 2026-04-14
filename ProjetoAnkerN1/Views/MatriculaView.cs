namespace ProjetoAnkerN1.Views
{
    public class MatriculaView
    {
        public int[] AtribuirNotaView()
        {
            Console.WriteLine("Digite a Nota 1:");
            int nota1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Nota 2:");
            int nota2 = int.Parse(Console.ReadLine());
            return new int[] { nota1, nota2 };
        }
    }
}
