using System.Collections.ObjectModel;
using TarefasApp.Models;

namespace TarefasApp.Services;

public sealed class TaskRepository
{
    public static TaskRepository Instance { get; } = new();
    public ObservableCollection<TaskItem> Tasks { get; } = [];

    private TaskRepository()
    {
        Tasks.Add(new TaskItem { Title = "Preparar apresentação do projeto", Description = "Revisar os slides e ensaiar a demonstração do aplicativo.", CreatedAt = DateTime.Today, Priority = "Alta" });
        Tasks.Add(new TaskItem { Title = "Revisar conteúdo de MAUI", Description = "Estudar navegação, modais e passagem de dados entre páginas.", CreatedAt = DateTime.Today.AddDays(-1), Priority = "Média" });
        Tasks.Add(new TaskItem { Title = "Organizar anotações", Description = "Reunir referências e exemplos usados durante as aulas.", CreatedAt = DateTime.Today.AddDays(-3), Priority = "Baixa" });
    }

    public void Add(TaskItem task) => Tasks.Insert(0, task);
    public bool Remove(TaskItem task) => Tasks.Remove(task);
}
