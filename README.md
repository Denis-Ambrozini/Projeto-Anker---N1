# Projeto AED 2 

Disciplina: Algoritmos e Estruturas de Dados II  
Professor: Anker D. Loss  
Grupo: Denis Ambrozini e Victor Rocha Alves  

---

## Descrição

Sistema de gerenciamento escolar desenvolvido em C# para calcular o resultado das provas dos alunos, lendo e gravando informações em arquivos de texto.

---

## Arquivos de Dados

Os arquivos `.dat` ficam na pasta `Data/` e seguem o padrão: cada registro em uma linha, dados separados por `;`.

- `Aluno.dat` — Matricula;Nome;Idade
- `Disciplinas.dat` — Codigo;Nome;NotaMinima
- `Matriculas.dat` — AlunoMatricula;DisciplinaId;Nota1;Nota2

---

## Estrutura do Projeto

```
ProjetoAnkerN1/
├── Data/
│   ├── Aluno.dat
│   ├── Disciplinas.dat
│   └── Matriculas.dat
├── Models/
│   ├── Aluno.cs
│   ├── Disciplina.cs
│   └── Matricula.cs
├── Services/
│   ├── AlunoService.cs
│   ├── DisciplinaService.cs
│   └── MatriculaService.cs
├── Views/
│   ├── AlunoView.cs
│   ├── DisciplinaView.cs
│   ├── MatriculaView.cs
│   └── MenuView.cs
├── Controllers/
│   ├── AlunoController.cs
│   ├── DisciplinaController.cs
│   ├── MatriculaController.cs
│   └── MenuController.cs
└── Program.cs
```

---

## Funcionalidades

### Consultas
- Listar todos os alunos
- Listar todas as disciplinas
- Listar alunos de uma disciplina (aceita nome ou codigo), exibindo notas, media e situacao
- Listar disciplinas de um aluno (aceita nome ou matricula), exibindo notas, media e situacao

### Cadastros
- Cadastrar aluno (matricula gerada automaticamente)
- Cadastrar disciplina (codigo gerado automaticamente)
- Cadastrar matricula (vincula aluno a disciplina)
- Atribuir notas a aluno em uma disciplina

### Salvar
- Grava os dados dos vetores nos arquivos `.dat`

### Sair
- Salva os dados e encerra o programa

---

## Regras de Negocio

- Media: (Nota1 + Nota2) / 2
- Aprovado: media maior ou igual a NotaMinima da disciplina
- Reprovado: media menor que NotaMinima da disciplina
- Matricula e codigo de disciplina sao unicos e calculados automaticamente

---

## Como Executar

Requer .NET 10 SDK instalado.

```bash
cd ProjetoAnkerN1
dotnet run
```
