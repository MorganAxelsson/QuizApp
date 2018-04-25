using Quiz_app.Models;
using Quiz_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Quiz_app
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);
            listViewUsers.ItemsSource = HighScoreRepository.GetTopScores(5);
        }     

        private void btnStartQuiz_Clicked(object sender, EventArgs e)
        {           
            string username = entryName.Text;           
            string password = entryPassword.Text;


            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                User user = UserRepository.Get(username);

                if(user == null)
                {
                    user = UserRepository.Add(username, password);
                    Navigation.PushAsync(new Game(user.UserName, user.Id));
                    entryName.Text = string.Empty;
                    entryPassword.Text = string.Empty;
                }
                else
                {
                    if(user.Password == password)
                        Navigation.PushAsync(new Game(user.UserName, user.Id));
                    else
                    {
                        entryPassword.Text = string.Empty;
                        DisplayAlert("Oops", "Fel lösenord!", "Ok");
                    }                      
                }                   
            }
            else
            {
                DisplayAlert("Oops", "Ange användarnamn och lösenord", "Ok");
            }            
        }
    }
}
