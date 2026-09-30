using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TarefasApp.Models;

public sealed class TaskItem : INotifyPropertyChanged
{
    private string _title = string.Empty;
    private string _description = string.Empty;
    private DateTime _createdAt = DateTime.Today;
    private string _priority = "Média";

    public Guid Id { get; } = Guid.NewGuid();
    public string Title { get => _title; set => SetField(ref _title, value); }
    public string Description { get => _description; set => SetField(ref _description, value); }
    public DateTime CreatedAt { get => _createdAt; set => SetField(ref _createdAt, value); }
    public string Priority { get => _priority; set => SetField(ref _priority, value); }
    public string CreatedAtText => CreatedAt.ToString("dd 'de' MMMM 'de' yyyy");
    public string PriorityBadge => Priority.ToUpperInvariant();
    public Color PriorityColor => Priority switch
    {
        "Alta" => Color.FromArgb("#E34850"),
        "Baixa" => Color.FromArgb("#159B74"),
        _ => Color.FromArgb("#E49A27")
    };

    public event PropertyChangedEventHandler? PropertyChanged;

    private void SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CreatedAtText)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PriorityBadge)));
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PriorityColor)));
    }
}
