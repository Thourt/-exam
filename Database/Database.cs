using System;
using System.Data.SQLite;
using System.IO;

namespace exam.Database
{
    class Database
    {

        SQLiteConnection connection;

        public Database()
        {
            if (!File.Exists(@"Database.db")) 
            {
                SQLiteConnection.CreateFile(@"Database.db");
            }
            connection = new SQLiteConnection(@"Data Source=Database.db; Version=3;");

            string sql = "CREATE TABLE IF NOT EXISTS [accounts] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [login] VARCHAR(30), [pass] VARCHAR(30))"; // создать таблицу, если её нет
            SQLiteCommand Command = new SQLiteCommand(sql, connection);
            connection.Open(); // открыть соединение
            Command.ExecuteNonQuery(); // выполнить запрос
            connection.Close(); // закрыть соединение
        }

        public Boolean login(string login, string pass)
        {
            connection.Open();
            SQLiteCommand Command = new SQLiteCommand
            {
                Connection = connection,
                CommandText = @"SELECT * FROM [accounts] WHERE [login] = '" + login + "'"
            };
            SQLiteDataReader sqlReader = Command.ExecuteReader();
            string dbpass = "";
            while (sqlReader.Read())
            {
                dbpass = sqlReader.GetString(1);
            }
            connection.Close();

            return pass == dbpass;
        }

        public void register(string login, string pass)
        {
            string commandText = @"INSERT INTO [accounts] ([login], [pass]) VALUES(@login, @pass)";
            SQLiteCommand Command = new SQLiteCommand(commandText, connection);
            Command.Parameters.AddWithValue("@login", login); // присваиваем переменной значение
            Command.Parameters.AddWithValue("@pass", pass);
            connection.Open();
            Command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
