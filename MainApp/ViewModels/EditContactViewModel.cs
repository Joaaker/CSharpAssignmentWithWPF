﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace MainApp.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;


    [ObservableProperty]
    private string _title = "Edit contact";

    [RelayCommand]
    private void GoToListContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListContactsViewModel>();
    }

    public EditContactViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
}
