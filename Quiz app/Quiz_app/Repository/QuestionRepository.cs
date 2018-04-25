using Quiz_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_app.Repository
{
    public class QuestionRepository
    {
        public static List<Question> Get(int count)
        {
            List<Question> questions = new List<Question>();

            questions.Add(
                new Question()
                {
                    QuestionText = "Vilket lag är bäst?",
                    CorrectAnswer = "Fc Barcelona",
                    WrongAnswer1 = "Real madrid",
                    WrongAnswer2 = "Juventus",
                    WrongAnswer3 = "Milan"
                });

            questions.Add(
               new Question()
               {
                   QuestionText = "Vem är den bästa spelaren genom alla tider?",
                   CorrectAnswer = "Lionel Messi",
                   WrongAnswer1 = "Cristiano Ronaldo",
                   WrongAnswer2 = "Ronaldinho",
                   WrongAnswer3 = "Maradona"
               });

            questions.Add(
               new Question()
               {
                   QuestionText = "Vem är den bästa mittfältaren?",
                   CorrectAnswer = "Xavi",
                   WrongAnswer1 = "Zidane",
                   WrongAnswer2 = "Pirlo",
                   WrongAnswer3 = "Modric"
               });

            questions.Add(
               new Question()
               {
                   QuestionText = "Näst sista frågan?",
                   CorrectAnswer = "2",
                   WrongAnswer1 = "3",
                   WrongAnswer2 = "4",
                   WrongAnswer3 = "5"
               });

            questions.Add(
               new Question()
               {
                   QuestionText = "sista frågan?",
                   CorrectAnswer = "Rätt svar",
                   WrongAnswer1 = "Nej",
                   WrongAnswer2 = "Nope",
                   WrongAnswer3 = "fel svar"
               });

            return questions;
        }
    }
}
