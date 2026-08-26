// Importa o namespace System, que contém tipos fundamentais como DateTime e ArgumentException
using System;

// Define o namespace do projeto, organizando esta classe dentro de SistemaChamados.Models
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

// Classe que representa um chamado (ticket) no sistema
public class Chamado : IChamado
{
    // Identificador único do chamado. "init" permite definir o valor apenas na criação do objeto
    public int Id { get; init; }
    // Título do chamado. "private set" impede alteração direta por código externo à classe
    public string Titulo { get; private set; }
    // Descrição detalhada do problema ou solicitação
    public string Descricao { get; private set; }
    // Status atual do chamado (ex: "Aberto", "Fechado"). Só pode ser alterado internamente
    public StatusChamado Status { get; private set; }
    // Data e hora em que o chamado foi criado
    public DateTime DataCriacao { get; private set; }

    // Construtor: método chamado ao criar um novo Chamado. Recebe id, título e descrição
    public Chamado(int id, string titulo, string descricao)
    {
        // Validação: se o título for nulo, vazio ou só espaços, lança uma exceção
        if (string.IsNullOrWhiteSpace(titulo))
            throw new ArgumentException("O título não pode ser vazio.");

        // Atribui os valores recebidos às propriedades do objeto
        Id = id;
        Titulo = titulo;
        Descricao = descricao;
        // Define o status inicial como "Aberto"
        Status = StatusChamado.Aberto;
        // Registra a data/hora atual como data de criação
        DataCriacao = DateTime.Now;
    }

   public void UpdateStatus(StatusChamado novoStatus)
    {
        // Validação: se o novo status for nulo, lança uma exceção
        Status = novoStatus;
    }
} // Fim do arquivo (apenas uma chave fechará a classe)