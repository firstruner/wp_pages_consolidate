using ClassLibrary.Interfaces;
using ClassLibrary.Properties;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using ClassLibrary.Services.Extractor;
using db_extract.Enumerations;
using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace ClassLibrary.Services.Merger
{
    internal abstract class SqlFileMerger : ISqlFileMerger
    {
        protected readonly string _directoryPath;
        protected string _insertIntoValue;
        protected readonly string _outputFilePath;

        public SqlFileMerger(string dirName, string outputFilePath)
        {
            _outputFilePath = outputFilePath;
            _directoryPath = DirectoryHelper.SetDirectoryPath(dirName);
            _insertIntoValue = string.Empty;
        }

        public abstract void MergeFiles(string tableName);
        public abstract List<string> MergeInsertStatements(List<string[]> allFileLines, string tableName);
        public List<string> GrabSqlFiles(string tableName)
        {
            // Get tableName files
            string[] sourceSqlFiles = Directory.GetFiles(_directoryPath, "*.sql")
                                        .Where(file => Path.GetFileName(file).StartsWith(tableName))
                                        .ToArray();
            if (sourceSqlFiles.Length == 0)
            {
                Console.WriteLine("No SQL files found to merge.");
                return new List<string>();
            }

            // Read files into memory and save the userName
            List<string> sqlFiles = new List<string>();
            foreach (string file in sourceSqlFiles)
            {
                string fileName = Path.GetFileName(file);
                string[] parts = fileName.Split('_');

                // Check if the filename has the expected format
                if (parts.Length > 2)
                {
                    string userName = parts[2];
                    List<string> lines = File.ReadAllLines(file).ToList();

                    // Insert the user name line at the beginning
                    lines.Insert(0, $"@@@{userName}@@@");

                    // Join lines back into a single string
                    string contentWithUserName = string.Join(Environment.NewLine, lines);
                    sqlFiles.Add(contentWithUserName);
                }
                else
                {
                    Console.WriteLine($"File name format is incorrect: {fileName}");
                }
            }
            return sqlFiles;
        }
        protected static List<string[]> CleanFiles(List<string> sqlFiles, string tableName)
        {
            // Remove header and footer from sqlFiles
            List<string[]> cleanedFiles = new List<string[]>();

            string patternHeader = RessourcesManager.GenerateHeaderAndFooter(tableName, "header", true);
            string patternHeader2 = RessourcesManager.GenerateHeaderAndFooter(tableName, "header", false);
            string patternFooter = RessourcesManager.GenerateHeaderAndFooter(tableName, "footer", true);
       
            foreach (string content in sqlFiles)
            {           
                string cleanedContent = content.Replace(patternHeader, string.Empty)
                                        .Replace(patternHeader2, string.Empty)
                                       .Replace(patternFooter, string.Empty);
               // Console.WriteLine(cleanedContent);
                string[] lines = cleanedContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                cleanedFiles.Add(lines);
            }
            return cleanedFiles;
        }

        protected string CleanLine(string line)
        {
            string patternInsertInto = @"INSERT INTO.*?VALUES";

            // Find the match and extract the value
            Match match = Regex.Match(line, patternInsertInto, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                // Extract the value
                _insertIntoValue = match.Value.Trim();
                // Remove the captured value from the original line
                line = Regex.Replace(line, patternInsertInto, string.Empty, RegexOptions.IgnoreCase);
            }
            string trimmedLine = line.Trim().TrimEnd(',', ';');
            return trimmedLine;
        }
    }
}
