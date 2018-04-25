using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_app.Models
{
    public class Question
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
