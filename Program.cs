using System;
using System.Linq;
using SistemaChamados.Data;
using SistemaChamados.Models;

Console.WriteLine("=== SIMULADOR DE ATUALIZAÇÃO (EF CORE) ===");

using var db = new AplicacaoDbContext();

// 1. Limpeza rápida e criação de um chamado de teste em aberto
db.Chamados.RemoveRange(db.Chamados);
db.SaveChanges();

var chamadoOriginal = new Chamado(0, "Bug no Login", "Não entra com senha padrão.");
db.Chamados.Add(chamadoOriginal);
db.SaveChanges();

Console.WriteLine($"[Antes] Chamado criado com Status: {chamadoOriginal.Status}");

// =======================================================
// 2. O FLUXO DE ATUALIZAÇÃO
// =======================================================

// Passo A: Buscamos o chamado direto do banco pelo título
var chamadoDoBanco = db.Chamados.FirstOrDefault(c => c.Titulo == "Bug no Login");

if (chamadoDoBanco != null)
{
    Console.WriteLine("\nIniciando atendimento (alterando status no C#)...");

    // Passo B: Alteramos o status usando a nossa regra de negócio protegida
    chamadoDoBanco.UpdateStatus(StatusChamado.EmAtendimento);

    // Passo C: O EF Core detecta a mudança e sincroniza com o SQL Server
    db.SaveChanges();

    Console.WriteLine("Alteração salva com sucesso no banco de dados!");
}

// =======================================================
// 3. PROVA REAL: Buscamos novamente do banco para conferir
// =======================================================
var chamadoAtualizado = db.Chamados.FirstOrDefault(c => c.Titulo == "Bug no Login");
Console.WriteLine($"\n[Depois] Status atualizado no banco: {chamadoAtualizado?.Status}");

// Mantém a janela aberta
Console.ReadLine();