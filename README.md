# CBTPRDM — Trabalho Prático 02

Aplicativo de lista de tarefas desenvolvido em .NET MAUI para a disciplina CBTPRDM do curso de Análise e Desenvolvimento de Sistemas do IFSP — Campus Cubatão.

## Funcionalidades

- lista responsiva com título, descrição, data e prioridade;
- navegação hierárquica da lista para os detalhes;
- inclusão e edição em páginas modais com validação;
- exclusão com diálogo de confirmação;
- passagem de dados entre páginas e atualização imediata da interface;
- estado vazio, feedback acessível e interface adaptada a desktop e dispositivos móveis.

## Executar no Windows

Abra `TarefasApp.slnx` no Visual Studio, selecione **Windows Machine** e pressione `F5`, ou execute:

```powershell
dotnet build TarefasApp.csproj -f net10.0-windows10.0.19041.0
dotnet run --project TarefasApp.csproj -f net10.0-windows10.0.19041.0
```

## Autores

- Matheus Correia de França — CB3030318
- Davi Leite Coelho — CB303142X

## Tecnologias

.NET 10, .NET MAUI, XAML e C#.
