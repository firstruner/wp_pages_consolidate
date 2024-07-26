using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Factory;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using ClassLibrary.Services.Merger.IdManager;

namespace ClassLibrary.Services.Merger
{
    internal class WpPostmetaMerger : SqlFileMerger
    {
        public WpPostmetaMerger(string dirName, string outputFilePath)
        : base(dirName, outputFilePath) { }

        public override void MergeFiles(string tableName)
        {
            try
            {
                // Grab sql files into a new List
                List<string> sqlFiles = GrabSqlFiles(tableName);
            
                // Clean file contents
                List<string[]> cleanedFiles = CleanFiles(sqlFiles, tableName);
          
                // Merge cleaned lines
                List<string> mergedLines = MergeInsertStatements(cleanedFiles, tableName);

                FileSplitter.SplitIntoFiles(mergedLines, Constants.ROWS_PER_FILE, tableName, _insertIntoValue, _outputFilePath);

                ConsoleHelper.ShowMessage(
                    $"All SQL {tableName} files have been successfully merged into {_outputFilePath}",
                    ConsoleColor.White,
                    ConsoleColor.Blue
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while merging files: {ex.Message}");
            }
        }
   
        public override List<string> MergeInsertStatements(List<string[]> allFileLines, string tableName)
        {           
            List<string> mergedLines = new();
            HashSet<string> uniqueLines = new(StringComparer.OrdinalIgnoreCase);
            IdManagerWpPostmeta idManager = IdManagerWpPostmetaFactory.Create();

            for (int i = 0; i < allFileLines.Count; i++)
            {
                string[] fileLines = allFileLines[i];
      
                if (fileLines.Length == 0)
                {
                    throw new ArgumentException($"The file at index {i} is empty.", nameof(allFileLines));
                }

                // Read and extract the username
                string userLine = fileLines[0];
                string userName = string.Empty;

                if (userLine.StartsWith("@@@") && userLine.EndsWith("@@@"))
                {
                    userName = userLine.Substring(3, userLine.Length - 6).Trim();
                    fileLines = fileLines.Skip(1).ToArray(); //then delete it from the file
                }

                // Clean lines and merge files
                foreach (string line in fileLines)
                {        
                    string cleanLine = CleanLine(line);
                    if (!string.IsNullOrWhiteSpace(cleanLine))
                    {
                        // Make the merge list with new ids and new post_id
                        if (uniqueLines.Add(cleanLine))
                        {
                            // ID management
                            string newLine = idManager.ManageId(cleanLine, userName);
                            mergedLines.Add(newLine);

                        }
                    }
                }
            }
            return mergedLines;
        }
    }
}