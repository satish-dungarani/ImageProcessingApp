using ImageProcessingApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageProcessingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        private readonly IUserService userService;

        public RegisterPage(IUserService userService)
        {
            InitializeComponent();
            this.userService = userService;
        }

        async void OnRegisterButtonClicked(object sender, EventArgs e)
        {

            //pop the page to go back to the list
            await Navigation.PopAsync();

        }
    }
}