using Delegates.Demo01.Data;
using Delegates.Demo01.Models;

namespace Delegates.Demo01;

public delegate bool UsuarioDelegate(int usuarioId);
public delegate bool TarefaUsuarioDelegate(Tarefa tarefa);
public class Program
{
    static bool GetUsuariosMaioresQue(int usuarioId)
    => usuarioId > 2;
    static void Main()
    {
        // for (int i = 1; i <= 5; i++)
        // {
        //     AdicionarTarefas(i);
        // }

        //var tarefas = Get_Tarefas_De_UsuarioId_Igual_A_4();
        //var tarefas = Get_Tarefas_De_UsuarioId(4);
        //var tarefas = Get_Tarefas_De_Usuario_Delegate(new UsuarioDelegate(GetUsuariosMaioresQue));

        //Lambda Expression
        //var tarefas = Get_Tarefas_De_Usuario_Delegate(usuarioId => usuarioId > 2);

        //var tarefas = Get_Tarefas_De_TarefaUsuario_Delegate(x => x.UsuarioId >= 4);

        var tarefas = Get_Tarefas(x => x.Concluido == false);

        foreach (var tarefa in tarefas)
        {
            Console.WriteLine(tarefa);
        }
        Console.ReadLine();
    }

    //Método com 0% de reutilização.
    private static List<Tarefa> Get_Tarefas_De_UsuarioId_Igual_A_4()
    {
        List<Tarefa> tarefas = [];
        using var data = new Context();
        var dbTarefas = data.Tarefas.ToList();

        foreach (var tarefa in dbTarefas)
        {
            if (tarefa.UsuarioId == 4)
                tarefas.Add(tarefa);
        }

        return tarefas;
    }

    //Método com 25% de reutilização.
    private static List<Tarefa> Get_Tarefas_De_UsuarioId(int usuarioId)
    {
        List<Tarefa> tarefas = new();
        using var data = new Context();
        var dbTarefas = data.Tarefas.ToList();

        foreach (var tarefa in dbTarefas)
        {
            if (tarefa.UsuarioId == usuarioId)
                tarefas.Add(tarefa);
        }

        return tarefas;
    }

    //Método com 75% de reutilização.
    private static List<Tarefa> Get_Tarefas_De_Usuario_Delegate(UsuarioDelegate usuarioDelegate)
    {
        List<Tarefa> tarefas = new();
        using var data = new Context();
        var dbTarefas = data.Tarefas.ToList();

        foreach (var tarefa in dbTarefas)
        {
            if (usuarioDelegate(tarefa.UsuarioId))
                tarefas.Add(tarefa);
        }

        return tarefas;
    }

    //Método com 100% de reutilização.
    private static List<Tarefa> Get_Tarefas_De_TarefaUsuario_Delegate(TarefaUsuarioDelegate usuarioDelegate)
    {
        List<Tarefa> tarefas = new();
        using var data = new Context();
        var dbTarefas = data.Tarefas.ToList();

        foreach (var tarefa in dbTarefas)
        {
            if (usuarioDelegate(tarefa))
                tarefas.Add(tarefa);
        }

        return tarefas;
    }

    //Método com 100% de reutilização.
    private static List<Tarefa> Get_Tarefas(Predicate<Tarefa> predicate)
    {
        List<Tarefa> tarefas = new();
        using var data = new Context();
        var dbTarefas = data.Tarefas.ToList();

        foreach (var tarefa in dbTarefas)
        {
            if (predicate(tarefa))
                tarefas.Add(tarefa);
        }

        return tarefas;
    }

    static void AdicionarTarefas(int i)
    {
        using var data = new Context();
        var usuario = new Usuario($"Usuario{i}");
        data.Usuarios.Add(usuario);
        data.SaveChanges();

        var tarefa = new Tarefa($"Tarefa {i}", false, usuario.Id);
        data.Tarefas.Add(tarefa);
        data.SaveChanges();
    }
}