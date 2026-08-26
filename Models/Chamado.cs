using System;

namespace SistemaChamados.Models;

public class Chamado
{
    public int Id { get; init; } 
    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public string Status { get; private set; }
    public DateTime DataCriacao { get; private set; }

    public Chamado(int id, string titulo, string descricao)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título não pode ser vazio.");

        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Status = "Aberto";
        DataCriacao = DateTime.Now;
    }

    public void UpdateStatus(string novoStatus)
    {
        Status = novoStatus;
    }
}