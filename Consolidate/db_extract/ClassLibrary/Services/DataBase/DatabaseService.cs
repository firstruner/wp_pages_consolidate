using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using db_extract.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DataBase
{
    public sealed class DatabaseService : IDatabaseService
    {
        private static readonly Lazy<DatabaseService> _instance = new(() => new DatabaseService());
        public static DatabaseService Instance => _instance.Value;

        private MySqlConnection? _connection;
        private DatabaseService() { }

        public void OpenConnection(string? connectionString)
        {
            if (_connection == null)
            {

                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    throw new ArgumentNullException(nameof(connectionString), "Connection string cannot be null or empty.");
                }
                _connection = new MySqlConnection(connectionString);
                _connection.Open();
                ConsoleHelper.ShowMessage(
                     "Connection successful!",
                      ConsoleColor.White,
                      ConsoleColor.DarkCyan
                 );
            }
            else
            {
                ConsoleHelper.ShowMessage(
                     "Connection is already open.",
                      ConsoleColor.White,
                      ConsoleColor.DarkCyan
                 );
            }
        }

        public void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection = null;
                ConsoleHelper.ShowMessage(
                   "Connection closed.",
                    ConsoleColor.White,
                    ConsoleColor.DarkCyan
               );
            }
        }
        public bool IsConnectionOpen => _connection != null;
        public MySqlConnection? Connection => _connection;

    }
}
