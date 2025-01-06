using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;



    [ObservableProperty]
    private string _title = "Add a new contact";


    [RelayCommand]
    private void GoToListContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();
    }


    public AddContactViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

}
