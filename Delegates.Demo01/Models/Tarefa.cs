namespace Delegates.Demo01.Models;

public class Tarefa
{
    public Tarefa(string titulo, bool concluido, int usuarioId)
    {
        Titulo = titulo;
        Concluido = concluido;
        UsuarioId = usuarioId;
    }

    public int Id { get; set; }

    public string Titulo { get; set; }

    public bool Concluido { get; set; }

    public Usuario Usuario { get; set; }
    public int UsuarioId { get; set; }

    public override string ToString() =>
        $"Id: {Id} | Titulo: {Titulo} | Concluido: {Concluido} | UsuárioId: {UsuarioId}";

}

