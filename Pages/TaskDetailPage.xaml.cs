using TarefasApp.Models;
using TarefasApp.Services;

namespace TarefasApp.Pages;

public partial class TaskDetailPage : ContentPage
{
    private readonly TaskItem _task;

    public TaskDetailPage(TaskItem task)
    {
        InitializeComponent();
        _task = task;
        BindingContext = task;
    }

    private async void OnEditClicked(object? sender, EventArgs e)
    {
        var result = await TaskFormPage.ShowAsync(this, _task);
        if (result is not null)
            SemanticScreenReader.Announce("Alterações salvas");
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        var confirmed = await DisplayAlertAsync("Excluir tarefa?", $"A tarefa “{_task.Title}” será removida permanentemente.", "Excluir", "Cancelar");
        if (!confirmed) return;
        TaskRepository.Instance.Remove(_task);
        await Navigation.PopAsync();
    }
}
