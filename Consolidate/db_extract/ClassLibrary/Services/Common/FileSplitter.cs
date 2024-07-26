using ClassLibrary.Services.Common.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common
{
    public static class FileSplitter
    {
        public static void SplitIntoFiles<T>(IEnumerable<T> items, int rowsPerFile, string tableName, string? _insertIntoValue, string pathFile)
        {
            ArgumentNullException.ThrowIfNull(items, nameof(items));
            if (string.IsNullOrEmpty(tableName)) throw new ArgumentException("Table name cannot be null or empty", nameof(tableName));
            if (string.IsNullOrEmpty(pathFile)) throw new ArgumentException("Path file cannot be null or empty", nameof(pathFile));

            string userName = Environment.UserName;
            int fileCount = 0;
            int lastCount = items.Count() % rowsPerFile;
            int totalLoop = (items.Count() - lastCount) / rowsPerFile + (lastCount > 0 ? 1 : 0);

            for (int startRow = 0; startRow < totalLoop; startRow++)
            {
                string prefix = typeof(T) == typeof(DataRow) ? userName : "merged";
                string fileName = $"{tableName}_{prefix}_{++fileCount}_{Guid.NewGuid()}.sql";
                string outputFilePath = Path.Combine(pathFile, fileName);
                int rowsToTake = (startRow == totalLoop - 1 && lastCount > 0) ? lastCount : rowsPerFile;

                string insertStatements;
                switch (items)
                {
                    case List<T> list:
                        {
                            List<T> file = list.Skip(rowsPerFile * startRow).Take(rowsToTake).ToList();
                            insertStatements = DataManager.GenerateInsertStatements(file, tableName, _insertIntoValue);
                            break;
                        }
                    case IEnumerable<DataRow> dataRows:
                        {
                            DataRow[] file = dataRows.Skip(rowsPerFile * startRow).Take(rowsToTake).ToArray();
                            insertStatements = DataManager.GenerateInsertStatements(file, tableName, null);
                            break;
                        }
                    default:
                        throw new ArgumentException("Unsupported type");
                }

                WriteToFile(tableName, insertStatements, outputFilePath, startRow == 0);
            }
            ConsoleHelper.ShowMessage(
               $"Total files created: {fileCount} ",
               ConsoleColor.Red,
               ConsoleColor.White
            );
        }
        private static void WriteToFile(string tableName, string insertStatements, string outputFilePath, bool isFirstFile)
        {
            string footerText = RessourcesManager.GenerateHeaderAndFooter(tableName, "footer", true);
            string headerText = isFirstFile ? RessourcesManager.GenerateHeaderAndFooter(tableName, "header", true)
                : RessourcesManager.GenerateHeaderAndFooter(tableName, "header", false);

            File.WriteAllText(outputFilePath, headerText + insertStatements + footerText);

            Console.WriteLine($"Data successfully exported to {outputFilePath}");
        }


    }
}
