using Quiz_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_app.Repository
{
    public static class HighScoreRepository
    {
        public static void Add(string username, int score)
        {
            HighScores highscore = new HighScores()
            {
                Score = score,
                Username = username
            };

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_path))
            {
                connection.CreateTable<HighScores>();
                connection.Insert(highscore);
            
            };
        }
        public static List<HighScores> GetTopScores(int count)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_path))
            {
                connection.CreateTable<HighScores>();
                return connection.Table<HighScores>().OrderByDescending(x=>x.Score).Take(count).ToList();
            };
        }
    }
}
