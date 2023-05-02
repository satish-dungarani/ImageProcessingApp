using ImageProcessingApp.Model;
using ImageProcessingApp.ViewModels;
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
    public partial class ProfilePage : ContentPage
    {
        private readonly UserViewModel user;
        public ProfilePage(UserViewModel user)
        {
            InitializeComponent();

            // Set the binding context of the page to the user view model
            BindingContext = user;
        }
    }
}
