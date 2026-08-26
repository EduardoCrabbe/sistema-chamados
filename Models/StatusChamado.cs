// Define que este arquivo pertence à pasta Models do seu projeto
namespace SistemaChamados.Models;

//"public enum" avisa o C# que esta é uma lista fizxa de constantes, não uma classe comum
public enum StatusChamado
{
    // Cada item do enum representa um status possível para um chamado
    Aberto,          // Chamado recém-criado, ainda não atendido
    EmAtendimento,   // Chamado está sendo processado por um técnico
    Resolvido,       // Problema foi resolvido, mas o chamado ainda não foi fechado
    Fechado          // Chamado finalizado e encerrado
}