using TarefasApp.Models;
using TarefasApp.Pages;
using TarefasApp.Services;

namespace TarefasApp;

public partial class MainPage : ContentPage
{
    private TaskRepository Repository { get; } = TaskRepository.Instance;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = Repository;
        Repository.Tasks.CollectionChanged += (_, _) => UpdateSummary();
        UpdateSummary();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        TasksView.SelectedItem = null;
        UpdateSummary();
    }

    private void UpdateSummary() => SummaryLabel.Text = Repository.Tasks.Count switch
    {
        0 => "Nenhuma tarefa pendente",
        1 => "1 tarefa para acompanhar",
        var count => $"{count} tarefas para acompanhar"
    };

    private async void OnAddClicked(object? sender, EventArgs e)
    {
        var task = await TaskFormPage.ShowAsync(this);
        if (task is null) return;
        Repository.Add(task);
        SemanticScreenReader.Announce("Tarefa adicionada com sucesso");
    }

    private async void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is TaskItem task)
            await Navigation.PushAsync(new TaskDetailPage(task));
    }
}
