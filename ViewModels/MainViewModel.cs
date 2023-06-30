using CommunityToolkit.Mvvm.ComponentModel;
using CurrencyConverter.Maui.Services;
using CurrencyConverter.Maui.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;

namespace CurrencyConverter.Maui.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        [ObservableProperty]
        decimal _usDollar;

        [ObservableProperty]
        decimal _convertedAmount;

        [ObservableProperty]
        Currency _selectedCurrency;

        [ObservableProperty]
        string _resultText;

        public ObservableCollection<Currency> Currencies { get; private set; } = new();

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Currencies.Add(new Currency("Philippine Peso", 55.32m));
            Currencies.Add(new Currency("British Pound", 0.79m));
        }

        [RelayCommand]
        public void Compute()
        {
            if (SelectedCurrency == null)
            {
                return;
            }

            ConvertedAmount = UsDollar * SelectedCurrency.Rate;
            ResultText = $"Amount in {SelectedCurrency.Title}: {ConvertedAmount}";
        }
    }
}

