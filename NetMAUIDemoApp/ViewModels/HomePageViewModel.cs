using NetMAUIDemoApp.Models;
using NetMAUIDemoApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui;

namespace NetMAUIDemoApp.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        private readonly BitcoinPriceService _bitcoinPriceService = new BitcoinPriceService();

        private string _usdPrice;
        public string UsdPrice
        {
            get => _usdPrice;
            set
            {
                _usdPrice = value;
                OnPropertyChanged();
            }
        }

        private string _gbpPrice;
        public string GbpPrice
        {
            get => _gbpPrice;
            set
            {
                _gbpPrice = value;
                OnPropertyChanged();
            }
        }

        private string _eurPrice;
        public string EurPrice
        {
            get => _eurPrice;
            set
            {
                _eurPrice = value;
                OnPropertyChanged();
            }
        }

        public ICommand FetchNewPriceCommand { get; }

        public HomePageViewModel()
        {
            FetchNewPriceCommand = new Command(async () => await FetchNewPrice());
            LoadData();
        }

        private async void LoadData()
        {
            await FetchNewPrice();
        }

        private async Task FetchNewPrice()
        {
            var bitcoinPriceIndex = await _bitcoinPriceService.GetBitcoinPriceIndexAsync();
            UsdPrice = $"USD: {bitcoinPriceIndex.bpi.USD.rate}";
            GbpPrice = $"GBP: {bitcoinPriceIndex.bpi.GBP.rate}";
            EurPrice = $"EUR: {bitcoinPriceIndex.bpi.EUR.rate}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
