using System;
using SistemaChamados.Models;

Console.WriteLine("=== SISTEMA DE CHAMADOS ===");

var chamado = new Chamado(1, "Erro no login", "Usuário não consegue acessar a página principal.");

Console.WriteLine($"Chamado ID: {chamado.Id}");
Console.WriteLine($"Título: {chamado.Titulo}");
Console.WriteLine($"Status Inicial: {chamado.Status}");

chamado.UpdateStatus("Em Atendimento");
Console.WriteLine($"Novo Status: {chamado.Status}");