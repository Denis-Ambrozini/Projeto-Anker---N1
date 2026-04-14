namespace ProjetoAnkerN1.Views
{
    public class MenuView
    {
        public int ExibirMenu()
        {
            Console.Clear();
            Console.WriteLine(" ==== MENU PRINCIPAL ====\nO que deseja fazer:\n" +
                "1 - Consultar\n2 - Cadastros\n3 - Salvar" +
                "\n4 - Sair\n");
            if(int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }
            return 0;
        }

        public int ExibirSubMenuConsultar()
        {
            //Console.Clear();
            Console.WriteLine(" ==== MENU CONSULTAR ====\nO que deseja consultar:\n" +
                "1 - Alunos \n2 - Disciplinas\n3 - Alunos da Disciplinas\n4 - Disciplinas do Aluno" +
                "\n0 - Voltar\n");
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }
            return 0;
        }

        public int ExibirSubMenuCadastros()
        {
            //Console.Clear();
            Console.WriteLine(" ==== MENU CADASTROS ====\nO que deseja cadastrar:\n" +
                "1 - Alunos \n2 - Disciplinas\n3 - Matrículas\n4 - Atribuir Nota a Aluno" +
                "\n0 - Voltar\n");
            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }
            return 0;
        }
    }
}
