// Importa o namespace System, que fornece funcionalidades básicas como Console.WriteLine
using System;
// Importa o namespace onde está a classe Chamado, permitindo usá-la neste arquivo
using SistemaChamados.Models;

// Exibe o cabeçalho do sistema no terminal
Console.WriteLine("=== SISTEMA DE CHAMADOS ===");

// Cria um novo objeto Chamado com:
//   - Id: 1
//   - Título: "Erro no login"
//   - Descrição: "Usuário não consegue acessar a página principal."
// O status será automaticamente "Aberto" e a data de criação será a atual (definidos no construtor)
var chamado = new Chamado(1, "Erro no login", "Usuário não consegue acessar a página principal.");

// Exibe o ID do chamado criado
Console.WriteLine($"Chamado ID: {chamado.Id}");
// Exibe o título do chamado
Console.WriteLine($"Título: {chamado.Titulo}");
// Exibe o status inicial (será "Aberto", pois é o valor padrão definido no construtor)
Console.WriteLine($"Status Inicial: {chamado.Status}");

// Atualiza o status do chamado para "Em atendimento" usando o método UpdateStatus
// Internamente, o método valida se o novo status não é vazio antes de aplicar a mudança
chamado.UpdateStatus(StatusChamado.EmAtendimento);
// Exibe o novo status após a atualização
Console.WriteLine($"Novo Status: {chamado.Status}");