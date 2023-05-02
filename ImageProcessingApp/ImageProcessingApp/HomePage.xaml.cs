using ImageProcessingApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageProcessingApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void onUserListClicked(object sender, EventArgs e)
        {
            //load the repositories page
            Console.Out.WriteLine("User List clicked");
            await Navigation.PushModalAsync(page: new UserListViewPage());
        }

        //async void onHistoryClicked(object sender, EventArgs e)
        //{
        //    //load the todos page
        //    Console.Out.WriteLine("Register clicked");
        //    await Navigation.PushModalAsync(page: new NavigationPage(new RegisterPage()));
        //}
    }
}