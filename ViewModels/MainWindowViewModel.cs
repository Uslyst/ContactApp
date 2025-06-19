using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using FirstAvaloniaApp.Models;
using MsBox.Avalonia;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FirstAvaloniaApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Contact> Contacts { get; } = new();

    public ICommand AddContactCommand { get; }
    public MainWindowViewModel()
    {
        AddContactCommand = new Helper.RelayCommand(_ => AddContact());
    }

    private void AddContact()
    {
        if (string.IsNullOrWhiteSpace(NewName) || string.IsNullOrWhiteSpace(NewEmail) || string.IsNullOrWhiteSpace(NewPhone))
            return;


        var novoContato = new Contact(NewName, NewEmail, NewPhone);
        Contacts.Add(novoContato);

        // Limpa os campos depois de adicionar
        NewName = string.Empty;
        NewEmail = string.Empty;
        NewPhone = string.Empty;
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private string _newName;
    public string NewName
    {
        get => _newName;
        set
        {
            if (_newName != value)
            {
                _newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }
    }

    private string _newEmail;
    public string NewEmail
    {
        get => _newEmail;
        set
        {
            if (_newEmail != value)
            {
                _newEmail = value;
                OnPropertyChanged(nameof(NewEmail));
            }
        }
    }

    private string _newPhone;
    public string NewPhone
    {
        get => _newPhone;
        set
        {
            if (_newPhone != value)
            {
                _newPhone = value;
                OnPropertyChanged(nameof(NewPhone));
            }
        }
    }

}
