using ImageProcessingApp.Model;
using ImageProcessingApp.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ImageProcessingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserListViewPage : ContentPage
    {
        private List<UserViewModel> users = new List<UserViewModel>();

        public UserListViewPage()
        {
           
            InitializeComponent();

            //try
            //{
            //    // Populate the users list from the API
            //    users = GetUsersFromApi().GetAwaiter().GetResult();
            //}
            //catch (Exception)
            //{
                users.Add(new UserViewModel()
                {
                    Id = 1,
                    Firstname = "Satish",
                    Lastname = "Dungarani",
                    DOB = DateTime.Now.AddYears(-30),
                    Gender = "Male",
                    Email = "er.satish674@gmail.com",
                    IsAdmin = true,
                    IsActive = true,
                    ProfilePictureUrl = "https://lh3.googleusercontent.com/a/AGNmyxbjGpf3BMsiwWe6AAihyytfi9gIifIufnlns3f4ZQ=s360"
                });
                users.Add(new UserViewModel()
                {
                    Id = 1,
                    Firstname = "Akhil",
                    Lastname = "Gopi",
                    DOB = DateTime.Now.AddYears(-30),
                    Gender = "Male",
                    Email = "akhil@gmail.com",
                    IsAdmin = true,
                    IsActive = true,
                    ProfilePictureUrl = "https://m.media-amazon.com/images/M/MV5BNDJiY2VlZTctYjdjMi00ZjU4LTgxYTgtZmM0NjI2MTIyYTUzXkEyXkFqcGdeQXVyMjkxNzQ1NDI@._V1_FMjpg_UX1000_.jpg"
                });
           // }
             
           

            // Set the items source of the ListView to the users list
            UserListView.ItemsSource = users;

            // Add the ItemTapped event handler
            UserListView.ItemTapped += async (sender, e) =>
            {
                var user = (UserViewModel)e.Item;
                //await Navigation.PushAsync(new ProfilePage(user));
                await Navigation.PushModalAsync(page: new ProfilePage(user));
            };
            UserListView.ItemsSource = users;
        }

        public async Task<List<UserViewModel>> GetUsersFromApi()
        {

            var apiUrl = Constants.RestUrl + "Account/Getuser";
            var signinModel = new SignInModel()
            {
                Email = Constants.Email,
                Password = Constants.Password
            };

            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await Constants.GetTokenAsync(JsonConvert.SerializeObject(signinModel)));

                var response = await httpClient.GetAsync(apiUrl);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to get users from API. Status code: {response.StatusCode}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<UserViewModel>>(json);

                return users;
            }
        }
    }
}
