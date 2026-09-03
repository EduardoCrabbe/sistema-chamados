# Sistema de Chamados

Aplicação de console em C# onde eu registro um chamado de suporte e mudo o status dele. É pouco de propósito: o objetivo aqui não é entregar um sistema, é aprender orientação a objetos em C# e fluxo de trabalho com Git escrevendo código de verdade em vez de só ler sobre.

Se você caiu aqui procurando um help desk funcional, não é este repositório. Se caiu procurando como alguém aprendendo .NET organiza as primeiras classes, talvez sirva.

## O que funciona hoje

O `Program.cs` cria um chamado, imprime os dados no terminal e atualiza o status:

```
=== SISTEMA DE CHAMADOS ===
Chamado ID: 1
Título: Erro no login
Status Inicial: Aberto
Novo Status: EmAtendimento
```

Não há menu, entrada de dados, lista de chamados nem banco. Tudo é instanciado direto no código.

## Estrutura

```text
sistema-chamados/
├── Models/
│   ├── Chamado.cs          # Entidade Chamado + a interface IChamado
│   └── StatusChamado.cs    # Enum com os status possíveis
├── Program.cs              # Ponto de entrada (top-level statements)
├── .gitignore              # Padrão do ecossistema .NET
└── sistema-chamados.csproj
```

## Decisões e o que eu aprendi com elas

**Status é um enum, não uma string.** A primeira versão guardava `"Aberto"` como texto. Bastava errar uma letra ou o acento para gravar um status que não existe, e o compilador não reclamava. Com `StatusChamado` isso vira erro de compilação em vez de bug em tempo de execução. Foi minha primeira refatoração feita por um motivo claro, não por estética.

**As propriedades não têm `set` público.** `Id` usa `init` (só pode ser definido na criação) e os demais campos usam `private set`. Quem está de fora lê, mas não escreve direto — qualquer mudança precisa passar por um método da própria classe. É encapsulamento na prática, e serviu para eu entender por que ele existe.

**O construtor valida o título.** Título nulo, vazio ou só com espaços dispara `ArgumentException`. A ideia é que não exista objeto `Chamado` inválido na memória: ou ele nasce completo, ou não nasce.

**Existe uma interface `IChamado`.** Sendo honesto: com uma única implementação, ela ainda não me dá nenhum ganho real. Criei para praticar a ideia de contrato e para deixar o caminho pronto para quando eu tiver mais de um tipo de chamado ou precisar de testes com mocks.

## Como rodar

Você vai precisar do SDK do .NET. O `.csproj` está apontando para `net10.0`; se você tem outra versão instalada, troque essa linha para a sua (`net8.0`, por exemplo) antes de rodar.

```bash
git clone https://github.com/EduardoCrabbe/sistema-chamados.git
cd sistema-chamados
dotnet run
```

Para conferir qual SDK você tem: `dotnet --list-sdks`.

## Limitações conhecidas

Deixo registrado o que ainda não funciona, porque é daqui que sai o próximo commit:

- `UpdateStatus` aceita qualquer transição. Hoje dá para mover um chamado de `Fechado` para `Aberto` sem nenhuma restrição — falta a regra de negócio que decide quais transições são válidas.
- Nada é salvo. Fechou o programa, perdeu os dados.
- Não existe coleção de chamados, só uma instância solta no `Program.cs`.
- Sem testes automatizados.
- Há um `info.txt` no repositório, sobra de um exercício de branch. Ele sai no próximo commit.

## Próximos passos

1. Validar transições de status dentro de `UpdateStatus`.
2. Criar uma lista de chamados em memória com operações de cadastrar, listar e buscar por id.
3. Menu interativo no console.
4. Testes com xUnit, começando pelas validações do construtor.
5. Separar a persistência atrás de uma interface (`IChamadoRepository`) para depois trocar memória por arquivo ou banco.

## Sobre o versionamento

Estou usando Conventional Commits para praticar mensagens padronizadas (`feat:`, `refactor:`, `chore:`). Também usei o repositório para exercitar branches e resolução de conflitos de propósito, e é por isso que o histórico tem alguns commits que existem só como exercício.

---

Projeto de estudo de Eduardo Crabbe. Feedback e correções são bem-vindos — inclusive nos pontos que eu ainda não percebi que estão errados.
