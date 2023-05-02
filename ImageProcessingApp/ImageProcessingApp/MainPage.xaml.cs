using ImageProcessingApp.Data;
using ImageProcessingApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImageProcessingApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        async void onSigninClicked(object sender, EventArgs e)
        {
            //load the repositories page
            Console.Out.WriteLine("Signin clicked");
            await Navigation.PushModalAsync(page: new SigninPage());
        }

        async void onRegisterClicked(object sender, EventArgs e)
        {
            //load the todos page
            Console.Out.WriteLine("Register clicked");
            await Navigation.PushModalAsync(page: new NavigationPage(new RegisterPage(new UserService())));
        }
    }
}
