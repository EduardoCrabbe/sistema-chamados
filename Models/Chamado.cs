using System;

namespace SistemaChamados.Models;

public interface IChamado
{
    int Id { get; init; }
    string Titulo { get; }
    string Descricao { get; }
    StatusChamado Status { get; }
    DateTime DataCriacao { get; }

    void UpdateStatus(StatusChamado statusChamado);
}

public class Chamado : IChamado
{
    // 1. PROPRIEDADES (O seu modelo de dados)
    public int Id { get; init; }
    
    // O "= null!" avisa o compilador que o EF Core vai preencher isso ao ler o banco
    public string Titulo { get; private set; } = null!;
    public string Descricao { get; private set; } = null!;
    
    public StatusChamado Status { get; private set; }
    public DateTime DataCriacao { get; private set; }

    // 2. CONSTRUTORES (Temos dois agora!)
    
    // O vazio: Protegido, invisível para o Program.cs, mas usado pelo EF Core
    protected Chamado() { }

    // O público: Usado por você no Program.cs para criar novos chamados com validação
    public Chamado(int id, string titulo, string descricao)
    {
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título não pode ser vazio.");

        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        Status = StatusChamado.Aberto;
        DataCriacao = DateTime.Now;
    }

    // 3. MÉTODOS (Comportamentos da classe)
    public void UpdateStatus(StatusChamado novoStatus)
    {
        Status = novoStatus;
    }
}