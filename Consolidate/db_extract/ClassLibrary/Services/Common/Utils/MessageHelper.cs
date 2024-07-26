using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common.Utils
{
    public static class MessageHelper
    {
        public static void ExtractionMessage(string tableName)
        {
            ConsoleHelper.ShowMessage($"Extraction : {tableName} :", ConsoleColor.Black, ConsoleColor.Yellow);
            ConsoleHelper.ChangeColors(ConsoleColor.Black, ConsoleColor.White);
        }
        public static void BackupMessage(string state)
        {
            state = state.ToLower();
            if (string.IsNullOrWhiteSpace(state))
                throw new InvalidOperationException("Backup message state not valid.");

            var (message, additionalInfo) = state switch
            {
                "start" => ("SQL files merging :", $"{EnumDictionary.Get(DatabaseTables.WpPosts)} and {EnumDictionary.Get(DatabaseTables.WpPostMeta)} backup :"),
                "end" => ("Backup successful", $"{EnumDictionary.Get(DatabaseTables.WpPosts)} and {EnumDictionary.Get(DatabaseTables.WpPostMeta)} merging start ..."),
                _ => throw new InvalidOperationException("Invalid backup message state.")
            };

            ConsoleHelper.ShowMessage(message, ConsoleColor.White, ConsoleColor.Blue);
            Console.WriteLine(additionalInfo);
            Console.WriteLine();
        }

    }
}
