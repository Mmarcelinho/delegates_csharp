namespace Delegates.Demo02;

public class Program
{
    static void Main(string[] args)
    {
        var gerenciadorTarefas = new GerenciadorTarefas();

        // Registrando os métodos para serem chamados quando os eventos forem disparados
        gerenciadorTarefas.HorarioCriacaoTarefa += HorarioCriacaoTarefa;

        // Definindo um delegate Action para representar um método que realiza uma ação e não produz um resultado
        Action<Tarefa> action = i => Console.WriteLine(i);
        // Definindo um delegate Func para representar um método que recebe um argumento e retorna um resultado
        Func<Tarefa, bool> func = i => i.Id == 5;
        // Verifica se um item específico atende a um critério específico em uma lista de objetos do tipo Tarefa.
        Predicate<Tarefa> pred = i => i.Concluido == true;

        for (int i = 1; i <= 5; i++)
        {
            gerenciadorTarefas.AdicionarTarefa(new Tarefa(i, $"Tarefa {i}", false, "Usuário"));
        }

        gerenciadorTarefas.ConcluirTarefa("Tarefa 5");
        gerenciadorTarefas.ImprimirTodasTarefas(action);

        var tarefa = gerenciadorTarefas.PegarTarefaPorId(func);
        Console.WriteLine(tarefa);

        var tarefaConcluidaExistente = gerenciadorTarefas.ExisteTarefaConcluida(pred);
        Console.WriteLine(tarefaConcluidaExistente);
    }

    // Método que imprime o horário de criação de uma tarefa a partir de um evento
    static void HorarioCriacaoTarefa(Tarefa tarefa) => Console.WriteLine($"{tarefa.Titulo} - Horário da criação: {DateTime.Now}");
}
