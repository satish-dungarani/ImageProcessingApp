using ImageProcessingApp.Data;
using ImageProcessingApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageProcessingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        //private readonly IUserService userService;

        //public RegisterPage(IUserService userService)
        //{
        //    InitializeComponent();
        //    this.userService = userService;
        //}

        //public async void OnRegisterButtonClicked(object sender, EventArgs e)
        //{

        //    //pop the page to go back to the list
        //    await Navigation.PopAsync();

        //}

        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            // Validate form data
            if (string.IsNullOrEmpty(FirstNameEntry.Text) || string.IsNullOrEmpty(LastNameEntry.Text) ||
                string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text) ||
                string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Please fill all fields", "OK");
                return;
            }

            if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
            {
                await DisplayAlert("Error", "Password and confirm password do not match", "OK");
                return;
            }

            // Create user model from form data
            var user = new UserModel
            {
                Firstname = FirstNameEntry.Text,
                Lastname = LastNameEntry.Text,
                Email = EmailEntry.Text,
                Password = PasswordEntry.Text
            };

            // Serialize user model to JSON
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send registration request to API
            var response = await PostAsync(Constants.RestUrl + "Account/Register", content);

            if (response.IsSuccessStatusCode)
            {
                // Registration successful, show success message
                await DisplayAlert("Success", "Registration successful", "OK");
            }
            else
            {
                // Registration failed, show error message
                await DisplayAlert("Error", "Registration failed", "OK");
            }
        }

        private async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            using (var httpClient = new HttpClient())
            {
                return await httpClient.PostAsync(url, content);
            }
        }
    }
}