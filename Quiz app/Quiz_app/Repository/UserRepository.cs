using Quiz_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_app.Repository
{
    public static class UserRepository
    {
        public static User Add(string username, string password)
        {
            User user = new User()
            {
                UserName = username,
                Password = password              
            };

            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_path))
            {
                connection.CreateTable<User>();
                connection.Insert(user);
                return user;
            };          
        }
        public static User Get(string userName)
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_path))
            {
                connection.CreateTable<User>();
                return connection.Table<User>().Where(x=>x.UserName == userName).FirstOrDefault();
            };
        }

        public static List<User> GetAll()
        {
            using (SQLite.SQLiteConnection connection = new SQLite.SQLiteConnection(App.DB_path))
            {
                connection.CreateTable<User>();
                return connection.Table<User>().ToList();            
            };
        }
    }
}
