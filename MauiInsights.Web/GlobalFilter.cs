using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiInsights.Web;

public class GlobalFilter : INotifyPropertyChanged
{
    private int numberOfDays = 30;

    public int NumberOfDays
    {
        get => numberOfDays;
        set => SetField(ref numberOfDays, value);
    }
    
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}