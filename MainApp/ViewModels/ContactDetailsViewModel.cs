using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interface;
using Shared.Models;
using Shared.Services;

namespace MainApp.ViewModels;


public partial class ContactDetailsViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;


    [ObservableProperty]
    private ContactObjects _contact = new("", "", "", "", "", "", "", "");

    [RelayCommand]
    private void GoBack()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();
    }


    [RelayCommand]
    private void GoToEditContact(ContactObjects contact)
    {
        var editContactViewModel = _serviceProvider.GetRequiredService<EditContactViewModel>();
        editContactViewModel.Contact = contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editContactViewModel;
    }
}