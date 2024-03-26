namespace Delegates.Demo02;

public delegate void GerenciarTarefa(Tarefa tarefa);

public class GerenciadorTarefas
{
    List<Tarefa> listaTarefas = new List<Tarefa>();

    // Evento do tipo delegate que atuam como contêineres para métodos com a mesma assinatura
    public event GerenciarTarefa HorarioCriacaoTarefa;
        
    public void AdicionarTarefa(Tarefa tarefa)
    {
        listaTarefas.Add(tarefa);
        // Chamando o EventHandler para disparar os eventos
        EventHandler(tarefa);
    }

    public void ConcluirTarefa(string nomeTarefa)
    {
        var tarefa = listaTarefas.FirstOrDefault(x => x.Titulo == nomeTarefa);
        tarefa.Concluido = true;
        Console.WriteLine($"Tarefa: {tarefa.Titulo} - Concluída!");
    }

    // Método que dispara os eventos
    private void EventHandler(Tarefa tarefa)
    {
        // Quando disparados, os eventos chamam todos os métodos registrados
        HorarioCriacaoTarefa(tarefa);
    }

     // Método ImprimirTodasTarefas que recebe uma ação (Action) como parâmetro e a aplica a todos os itens na lista.
    public void ImprimirTodasTarefas(Action<Tarefa> action)
    {
        listaTarefas.ForEach(action);
    }

     // Método PegarTarefaPorId que recebe uma função (Func) como parâmetro para encontrar um item com base em um critério.
    public Tarefa PegarTarefaPorId(Func<Tarefa,bool> func)
    {
       return listaTarefas.FirstOrDefault(func);
    }

     // Método ExisteTarefaConcluida que recebe um predicado (Predicate) como parâmetro para verificar se um item atende a um critério específico.
    public bool ExisteTarefaConcluida(Predicate<Tarefa> pred)
    {
        return listaTarefas.Exists(pred);
    }
}