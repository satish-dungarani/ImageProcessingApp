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
            //var response = await GetAsync(Constants.RestUrl + "Account/Signin", new
            //{
            //    Email = viewModel.Username,
            //    Password = SecurityHelper.Encrypt(viewModel.Password)
            //});



            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get, Constants.RestUrl + "Account/Signin");
            var content = new StringContent("{\r\n  \"Email\": \"er.satish674@gmail.com\",\r\n  \"Password\": \"twJMKdVQUYWv/+BVZ4GKUg==\"\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());




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

        private async Task<HttpResponseMessage> GetAsync(string url, object data)
        {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Get, url)
            {
                Content = content
            };
            return await _httpClient.SendAsync(request);

        }
    }
}