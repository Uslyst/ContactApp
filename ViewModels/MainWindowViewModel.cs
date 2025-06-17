using CommunityToolkit.Mvvm.Input;
using FirstAvaloniaApp.Models;
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
        Contacts.Add(new Contact("New Contact", "contactemail@gmail.com,", "number"));
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
