using ProjetoAnkerN1.Models;
using ProjetoAnkerN1.Services;
using ProjetoAnkerN1.Views;

namespace ProjetoAnkerN1.Controllers
{
    public class DisciplinaController
    {
        DisciplinaService disciplinaService = new DisciplinaService();
        public Disciplina[] lstDisciplinas = new Disciplina[100];
        public int totalDisciplinas = 0;

        public DisciplinaController()
        {
            lstDisciplinas = disciplinaService.CarregarDisciplinas();
            foreach (Disciplina d in lstDisciplinas)
            {
                if (d == null) break;
                totalDisciplinas++;
            }
        }

        public Disciplina BuscarDisciplina()
        {
            DisciplinaView disciplinaView = new DisciplinaView();
            string input = disciplinaView.EscolherDisciplinaView();

            foreach (Disciplina d in lstDisciplinas)
            {
                if (d == null) break;
                if (int.TryParse(input, out int codigo))
                {
                    if (d.Codigo == codigo) return d;
                }
                else
                {
                    string nomeSemAcento = d.Nome.ToLower()
                        .Replace("á", "a").Replace("ã", "a").Replace("â", "a")
                        .Replace("é", "e").Replace("ê", "e")
                        .Replace("í", "i")
                        .Replace("ó", "o").Replace("ô", "o").Replace("õ", "o")
                        .Replace("ú", "u").Replace("ç", "c");
                    if (nomeSemAcento == input) return d;
                }
            }

            Console.WriteLine("Disciplina não encontrada. Tente novamente!");
            return BuscarDisciplina();
        }

        public void CadastrarDisciplina(Disciplina disciplina)
        {
            disciplina.Codigo = GerarCodigo();
            lstDisciplinas[totalDisciplinas++] = disciplina;
            Console.WriteLine($"Disciplina cadastrada com código {disciplina.Codigo}!");
        }

        public int GerarCodigo()
        {
            int maior = 0;
            foreach (Disciplina d in lstDisciplinas)
            {
                if (d == null) break;
                if (d.Codigo > maior) maior = d.Codigo;
            }
            return maior + 1;
        }

        public void Salvar()
        {
            disciplinaService.Salvar(lstDisciplinas, totalDisciplinas);
        }
    }
}