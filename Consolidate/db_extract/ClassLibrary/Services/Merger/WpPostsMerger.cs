using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using ClassLibrary.Services.Merger.IdManager;

namespace ClassLibrary.Services.Merger
{
    internal class WpPostsMerger : SqlFileMerger
    {
        public WpPostsMerger(string dirName, string outputFilePath)
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

                // Limit the extraction to 300 rows per file
                FileSplitter.SplitIntoFiles(mergedLines, Constants.ROWS_PER_FILE, tableName, _insertIntoValue, _outputFilePath);

                ConsoleHelper.ShowMessage(
                    $"All SQL {tableName} files have been successfully merged into {_outputFilePath}",
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

        public override List<string> MergeInsertStatements(List<string[]> allFileLines, string tableName)
        {
            List<string> mergedLines = new List<string>();
            HashSet<string> uniqueLines = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            IdManagerWpPosts idManager = IdManagerWpPosts.Instance;

            for (int i = 0; i < allFileLines.Count; i++)
            {
                string[] fileLines = allFileLines[i];
                if (fileLines.Length == 0) continue;

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
                        // Make the merge list with new ids and save id ref for postmeta link
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
