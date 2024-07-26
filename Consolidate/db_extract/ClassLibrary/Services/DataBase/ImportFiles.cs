using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using db_extract.Enumerations;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.DataBase
{
    public static class ImportFiles
    {
        public static void ImportMergedFiles(string folderName)
        {
            try
            {
                string directoryPath = DirectoryHelper.GetStartupPath() + $@"\Consolidate\{folderName}";

                // Setup the new id ref for the elementor kit
                ChangeElementorKitRef(directoryPath);

                ConsoleHelper.ShowMessage(
                     "Import merged files in database ...",
                     ConsoleColor.White,
                     ConsoleColor.Blue
                 );

                var files = Directory.GetFiles(directoryPath, "*.sql")
                                .Select(f => new FileInfo(f))
                                .Where(f => 
                                    f.Name.StartsWith(EnumDictionary.Get(DatabaseTables.WpPosts)) 
                                    || f.Name.StartsWith(EnumDictionary.Get(DatabaseTables.WpPostMeta)))
                                .OrderBy(f => f.Name.StartsWith($"{EnumDictionary.Get(DatabaseTables.WpPosts)}_merged") ? 0 : 1)
                                .ThenBy(f =>
                                {
                                    string[] parts = Path.GetFileNameWithoutExtension(f.Name).Split('_');
                                    return int.Parse(parts[3]);
                                })
                                .ToList();
                DatabaseService.Instance.OpenConnection(DatabaseConfig.ConnectionString);
                if (DatabaseService.Instance.IsConnectionOpen)
                {
                    MySqlConnection? connection = DatabaseService.Instance.Connection;

                    foreach (var file in files)
                    {
                        string sql = File.ReadAllText(file.FullName);

                        MySqlCommand command = new(sql, connection);

                        command.ExecuteNonQuery();
                        ConsoleHelper.ChangeColors(ConsoleColor.Black, ConsoleColor.White);
                        Console.WriteLine($"{file.Name} import succeed!");
                    }
                    Console.WriteLine();
                }
                DatabaseService.Instance.CloseConnection();
                ConsoleHelper.ShowMessage(
                    "Import completed.",
                    ConsoleColor.White,
                    ConsoleColor.Blue
                );
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowMessage(
                    "An error occured: " + ex.Message,
                    ConsoleColor.White,
                    ConsoleColor.Red
                );

            }
        }

        public static void ChangeElementorKitRef(string directoryPath)
        {
            string? file = Directory.GetFiles(directoryPath, "*.sql")
                                     .Where(file => Path.GetFileName(file).StartsWith(EnumDictionary.Get(DatabaseTables.WpPosts)))
                                     .FirstOrDefault();
            if (file != null)
            {
                string[] lines = File.ReadAllLines(file);
                string? targetLine = lines.FirstOrDefault(line => line.Contains("kit-par-defaut") || line.Contains("Kit par défaut"));

                if (targetLine != null)
                {
                    string[] parts = targetLine.Split(new char[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length > 0)
                    {
                        string id = parts[0].Trim();
                        ReplaceValueRequest(id);
                    }
                    else
                    {
                        Console.WriteLine("Unable to find the first number (id) in the line.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No file found starting with 'wppostmeta'.");
            }       
        }
        public static void ReplaceValueRequest(string id)
        {
            try
            {
                DatabaseService.Instance.OpenConnection(DatabaseConfig.ConnectionString);
                if (DatabaseService.Instance.IsConnectionOpen)
                {
                    MySqlConnection? connection = DatabaseService.Instance.Connection;
                    string sql = "UPDATE wp_options SET option_value = @newId WHERE option_name = 'elementor_active_kit'";

                    MySqlCommand command = new(sql, connection);
                    command.Parameters.AddWithValue("@newId", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No rows were updated. Check if the 'elementor_active_kit' option exists in wp_options..");
                    }

                }
                ConsoleHelper.ShowMessage(
                   "Ementor kit id attribution in wp_options ok.",
                   ConsoleColor.Black,
                   ConsoleColor.White
               );
                DatabaseService.Instance.CloseConnection();
            }
            catch (Exception ex)
            {
                ConsoleHelper.ShowMessage(
                    "An error occured: " + ex.Message,
                    ConsoleColor.White,
                    ConsoleColor.Red
                );
            }
        }
    }
}
