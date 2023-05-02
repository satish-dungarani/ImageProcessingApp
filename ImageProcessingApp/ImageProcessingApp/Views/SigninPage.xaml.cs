using ImageProcessingApp.Data;
using ImageProcessingApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageProcessingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SigninPage : ContentPage
    {
        private readonly HttpClient _httpClient;

        public SigninPage()
        {
            InitializeComponent();
            BindingContext = new SignnViewModel();

            // Initialize HttpClient
            _httpClient = new HttpClient();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var viewModel = (SignnViewModel)BindingContext;

            // Call the API to sign in the user
            var response = await PostAsync(Constants.RestUrl + "Account/Signin", new
            {
                username = viewModel.Username,
                password = viewModel.Password
            });


            // Check if the response was successful
            if (response.IsSuccessStatusCode)
            {
                // Navigate to the next page (e.g. the main app page)
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                // Show an error message
                await DisplayAlert("Sign In Failed", "Invalid username or password", "OK");
            }
        }

        private async Task<HttpResponseMessage> PostAsync(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return await _httpClient.PostAsync(url, content);
        }
    }
}