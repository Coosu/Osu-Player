using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia.Media;

namespace Milki.OsuPlayer.ViewModels;

public sealed class NavigationItemViewModel : INotifyPropertyChanged
{
    private readonly Action<NavigationItemViewModel> _navigate;
    private bool _isSelected;
    private bool _isTextVisible = true;

    public NavigationItemViewModel(string title, string key, Geometry icon, Action<NavigationItemViewModel> navigate)
    {
        Title = title;
        Key = key;
        Icon = icon;
        _navigate = navigate;
        ActivateCommand = new RelayCommand(() => _navigate(this));
    }

    public string Title { get; }

    public string Key { get; }

    public Geometry Icon { get; }

    public ICommand ActivateCommand { get; }

    public bool IsSelected
    {
        get => _isSelected;
        set
        {
            if (_isSelected == value) return;
            _isSelected = value;
            OnPropertyChanged();
        }
    }

    public bool IsTextVisible
    {
        get => _isTextVisible;
        set
        {
            if (_isTextVisible == value) return;
            _isTextVisible = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
