using Microsoft.Maui.Controls;
using Model;
using APIService;
namespace MauiPro
{
    public partial class MainPage : ContentPage
    {
        private User user = new User();
        private UserList userList = new UserList();
        private ApiService apiService = new ApiService();

        public MainPage()
        {
            InitializeComponent();
        }

        private async void HandleLoginClicked(object sender, EventArgs e)
        {
            user.UserName = UsernameEntry.Text;
            user.Pass = PasswordEntry.Text;

            userList = await apiService.GetUser();

            var existingUser = userList.Find(x => x.UserName == user.UserName && x.Pass == user.Pass);
            if (existingUser == null)
            {
                MessageLabel.Text = "Invalid login attempt.";
            }
            else
            {
                MessageLabel.Text = "Login successful!";
                Navigation.PushAsync(new Data());
                
            }
        }

        private async void HandleRegisterClicked(object sender, EventArgs e)
        {
            user.UserName = UsernameEntry.Text;
            user.Pass = PasswordEntry.Text;

            userList = await apiService.GetUser();

            var existingUser = userList.FirstOrDefault(x => x.UserName == user.UserName);
            if (existingUser != null)
            {
                MessageLabel.Text = "Username already exists.";
            }
            else if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Pass))
            {
                MessageLabel.Text = "Username or password cannot be empty.";
            }
            else
            {
                user.Permission = false; // Assuming default permission is false
                await apiService.InsertUser(user);

                MessageLabel.Text = "Registration successful!";
                Navigation.PushAsync(new Data());
            }
        }
    }
}
