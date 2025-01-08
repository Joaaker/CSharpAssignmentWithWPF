using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Shared.Interface;
using Shared.Models;
using Shared.Services;

namespace MainApp.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    public EditContactViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }


    [ObservableProperty]
    private ContactObjects _contact = new("", "", "", "", "", "", "", "");

    [RelayCommand]
    private void Save()
    {
        var result = _contactService.UpdateContact(Contact);

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

    [RelayCommand]
    private void DeleteContact(ContactObjects contact)
    {
        var result = _contactService.DeleteContact(contact.Id);
        if (result)
        {
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();
        }
    }
    }