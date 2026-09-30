using TarefasApp.Models;

namespace TarefasApp.Pages;

public partial class TaskFormPage : ContentPage
{
    private readonly TaskItem? _task;
    private readonly TaskCompletionSource<TaskItem?> _completion = new();

    private TaskFormPage(TaskItem? task)
    {
        InitializeComponent();
        _task = task;
        Title = task is null ? "Adicionar tarefa" : "Editar tarefa";
        CreatedAtPicker.Date = task?.CreatedAt ?? DateTime.Today;

        if (task is null) return;
        HeadingLabel.Text = "Editar tarefa";
        SubtitleLabel.Text = "Atualize as informações e salve as alterações.";
        SaveButton.Text = "Salvar alterações";
        TitleEntry.Text = task.Title;
        DescriptionEditor.Text = task.Description;
        PriorityPicker.SelectedItem = task.Priority;
    }

    public static async Task<TaskItem?> ShowAsync(Page owner, TaskItem? task = null)
    {
        var page = new TaskFormPage(task);
        await owner.Navigation.PushModalAsync(new NavigationPage(page));
        return await page._completion.Task;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        TitleEntry.Focus();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _completion.TrySetResult(null);
    }

    private void OnTitleCompleted(object? sender, EventArgs e) => DescriptionEditor.Focus();

    private async void OnCancelClicked(object? sender, EventArgs e)
    {
        _completion.TrySetResult(null);
        await Navigation.PopModalAsync();
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        var title = TitleEntry.Text?.Trim() ?? string.Empty;
        var description = DescriptionEditor.Text?.Trim() ?? string.Empty;
        if (title.Length < 3 || description.Length < 5 || PriorityPicker.SelectedItem is not string priority)
        {
            ErrorPanel.IsVisible = true;
            ErrorLabel.Text = "Informe um título (mín. 3 caracteres), uma descrição (mín. 5) e a prioridade.";
            SemanticScreenReader.Announce(ErrorLabel.Text);
            return;
        }

        var result = _task ?? new TaskItem();
        result.Title = title;
        result.Description = description;
        result.CreatedAt = CreatedAtPicker.Date ?? DateTime.Today;
        result.Priority = priority;
        _completion.TrySetResult(result);
        await Navigation.PopModalAsync();
    }
}
