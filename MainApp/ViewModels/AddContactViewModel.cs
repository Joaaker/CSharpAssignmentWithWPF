using System.Net;
using System.Reflection.Emit;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Shared.Factories;
using Shared.Interface;

namespace MainApp.ViewModels;

public partial class AddContactViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    [ObservableProperty]
    private string? _firstName = string.Empty;

    [ObservableProperty]
    private string? _lastName = string.Empty;

    [ObservableProperty]
    private string? _email = string.Empty;

    [ObservableProperty]
    private string? _phoneNumber = string.Empty;

    [ObservableProperty]
    private string? _address = string.Empty;

    [ObservableProperty]
    private string? _zipCode = string.Empty;

    [ObservableProperty]
    private string? _city = string.Empty;


    [RelayCommand]
    private void Save()
    {
        var newContact = ContactFactory.CreateContact(
            FirstName ?? string.Empty,
            LastName ?? string.Empty,
            Email ?? string.Empty,
            PhoneNumber ?? string.Empty,
            Address ?? string.Empty,
            ZipCode ?? string.Empty,
            City ?? string.Empty
            );

       
        var result = _contactService.AddContact(newContact);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();

        }
    }

    [RelayCommand]
    private void Cancel()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();
    }
}