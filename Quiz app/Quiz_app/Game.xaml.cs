using Quiz_app.Models;
using Quiz_app.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Quiz_app
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private List<Question> QuestionList;
        private int Nr = 0;
        private int Score = 0;
        public string Username { get; set; }
        public int UserID { get; set; }
        public Game(string username, int userId)
        {
            UserID = userId;
            Username = username;

            InitializeComponent();            
            lblName.Text = Username;
            QuestionList = QuestionRepository.Get(10);
            UpdateGameLabels();
            LoadQuestion();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NavigationPage.SetHasNavigationBar(this, false);           
        }

        public void LoadQuestion()
        {
            if (Nr < QuestionList.Count)
            {                
                ResetAnswerButtons();                

                string[] MyArray = new string[] { QuestionList[Nr].WrongAnswer1, QuestionList[Nr].WrongAnswer2, QuestionList[Nr].WrongAnswer3 , QuestionList[Nr].CorrectAnswer };
                Random rnd = new Random();
                string[] MyRandomArray = MyArray.OrderBy(x => rnd.Next()).ToArray();

                lblQuestionText.Text = QuestionList[Nr].QuestionText;
                btnAnswer1.Text = MyRandomArray[0];
                btnAnswer2.Text = MyRandomArray[1];
                btnAnswer3.Text = MyRandomArray[2];
                btnAnswer4.Text = MyRandomArray[3];
                UpdateGameLabels();         
            }            
        }

        private void Answer_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string answer = button.Text;
            
            if (Nr == QuestionList.Count - 1)
                btnQuit.IsVisible = true;
            else
                btnNextQuestion.IsVisible = true;

            DisableAnswerButtons();
            if (answer == QuestionList[Nr].CorrectAnswer)
            {
                Score++;
                UpdateGameLabels();
                button.BackgroundColor = Color.Green;
            }
            else
            {
                button.BackgroundColor = Color.Red;
            }
        }

        private void btnNextQuestion_Clicked(object sender, EventArgs e)
        {
            Nr++;
            LoadQuestion();
            btnNextQuestion.IsVisible = false;
        }

        private void DisableAnswerButtons()
        {
            btnAnswer1.IsEnabled = false;
            btnAnswer2.IsEnabled = false;
            btnAnswer3.IsEnabled = false;
            btnAnswer4.IsEnabled = false;
        }

        private void ResetAnswerButtons()
        {
            btnAnswer1.BackgroundColor = Color.Default;
            btnAnswer2.BackgroundColor = Color.Default;
            btnAnswer3.BackgroundColor = Color.Default;
            btnAnswer4.BackgroundColor = Color.Default;

            btnAnswer1.IsEnabled = true;
            btnAnswer2.IsEnabled = true;
            btnAnswer3.IsEnabled = true;
            btnAnswer4.IsEnabled = true;
        }
        private void UpdateGameLabels()
        {
            lblScore.Text = "Poäng: " + Score;
            int questionNr = Nr + 1;
            lblQuestion.Text = "Fråga " + questionNr + "/" + QuestionList.Count;
        }

        private void btnQuit_Clicked(object sender, EventArgs e)
        {
            HighScoreRepository.Add(Username, Score);
            DisplayAlert("Grattis", "Grattis du fick " + Score + " poäng utav " + QuestionList.Count + " möjliga!", "Ok");
            Navigation.PushAsync(new MainPage());
        }
    }
}