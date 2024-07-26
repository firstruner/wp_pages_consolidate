// See https://aka.ms/new-console-template for more information
using db_extract.Enumerations;
using db_extract.Interfaces;
//using db_extract.Services;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using ClassLibrary.Services.Merger;
using ClassLibrary.Services.DataBase;
using ClassLibrary.Services.Extractor;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;

if (args.Length == 0)
{
Console.WriteLine("No arguments provided. Please specify 'push' or 'pull'.");
return;
}

string command = args[0].ToLower();

switch (command)
{
    case "push":
        HandlePush(EnumDictionary.Get(ExtractDir.DbExtraction));
        break;

    case "pull":
        HandlePull();
        break;

    default:
        Console.WriteLine($"Unknown command: {command}. Please specify 'push' or 'pull'.");
        break;
}

void HandlePush(string extractionDir)
{
    try
    {
        DatabaseService.Instance.OpenConnection(DatabaseConfig.ConnectionString);
        if (DatabaseService.Instance.IsConnectionOpen)
        {
            DatabaseExtractor databaseExtractor = new(DatabaseConfig.ConnectionString, DatabaseConfig.SetExtractionDir(extractionDir));

            // wp_posts extraction
            databaseExtractor.ExtractData(DatabaseTables.WpPosts);

            // wp_postmeta extraction
            databaseExtractor.ExtractData(DatabaseTables.WpPostMeta);
        }
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

void HandlePull()
{
    try
    {
        PullOperations pullOperations = new(HandlePush);
        // Backup DB
        pullOperations.BackupDatabase();

        // Merge new sql files
        pullOperations.MergeSqlFiles();

        // Import merged files in DB
        pullOperations.ImportMergedFiles();
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
ConsoleHelper.CloseConsole();

