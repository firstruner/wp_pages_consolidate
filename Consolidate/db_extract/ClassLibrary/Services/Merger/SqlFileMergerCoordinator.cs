using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Merger
{
    public class SqlFileMergeCoordinator
    {
        private readonly string _dirName;
        private readonly string _outputFilePath;

        public SqlFileMergeCoordinator(string dirName, string outputFilePath)
        {
            _dirName = dirName;
            _outputFilePath = DirectoryHelper.SetDirectoryPath(outputFilePath);
            DirectoryHelper.InitializeDirectories(_outputFilePath);
        }

        public void ProcessMerge(string tableName1, string tableName2)
        {
            ConsoleHelper.ShowMessage($"Merging : {tableName1} :", ConsoleColor.Black, ConsoleColor.Yellow);
            MergeTable(tableName1);
            ConsoleHelper.ShowMessage($"Merging : {tableName2} :", ConsoleColor.Black, ConsoleColor.Yellow);
            MergeTable(tableName2);

            ConsoleHelper.ShowMessage(
                "Merge successful",
                ConsoleColor.White,
                ConsoleColor.Blue
            );
        }

        private void MergeTable(string tableName)
        {
            ConsoleHelper.ChangeColors(ConsoleColor.Black, ConsoleColor.White);
            SqlFileMerger merger;

            if (tableName == EnumDictionary.Get(DatabaseTables.WpPosts))
            {
                merger = new WpPostsMerger(_dirName, _outputFilePath);
            }
            else if (tableName == EnumDictionary.Get(DatabaseTables.WpPostMeta))
            {
                merger = new WpPostmetaMerger(_dirName, _outputFilePath);
            }
            else
            {
                throw new NotSupportedException($"Table {tableName} is not supported.");
            }
            merger.MergeFiles(tableName);
        }
    }
}
