namespace Delegates.Demo01.Models;

public class Usuario
{
    public Usuario(string nome)
    {
        Nome = nome;
    }
    public int Id { get; set; }

    public string Nome { get; set; }

    public ICollection<Tarefa> Tarefas { get; set; }

    public override string ToString() => $"Id = {Id}, Nome = {Nome}";

}
