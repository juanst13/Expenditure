using Expenditure.Common;
using Expenditure.Common.Models;
using Expenditure.Common.Services;
using Prism.Navigation;
using System.Collections.Generic;

namespace Expenditure.Prism.ViewModels
{
    public class TravelsPageViewModel : ViewModelBase
    {
        private readonly IApiService _apiService;
        private List<TravelsResponse> _travels;

        public TravelsPageViewModel(
            INavigationService navigationService,
            IApiService apiService)
            : base(navigationService)
        {
            _apiService = apiService;
            Title = "Travels";
            LoadTravelstsAsync();
        }

        public List<TravelsResponse> Travels
        {
            get => _travels;
            set => SetProperty(ref _travels, value);
        }

        private async void LoadTravelstsAsync()
        {
            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<TravelsResponse>(
                url,
                "/api",
                "/Travels");

            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                return;
            }

            Travels = (List<TravelsResponse>)response.Result;
        }
    }
}
