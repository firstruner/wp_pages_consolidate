using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using ClassLibrary.Services.DataBase;
using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Merger
{
    public class PullOperations
    {
        private readonly Action<string> _handlePush;
        public PullOperations(Action<string> handlePush)
        {
            _handlePush = handlePush;
        }

        public void BackupDatabase()
        {
            MessageHelper.BackupMessage("start");
            _handlePush(EnumDictionary.Get(ExtractDir.DbBackup));
            MessageHelper.BackupMessage("end");
        }

        public void MergeSqlFiles()
        {
            string dbExtractionDir = EnumDictionary.Get(ExtractDir.DbExtraction);
            string sqlMergedDir = EnumDictionary.Get(ExtractDir.SqlMerged);

            string wpPostsTable = EnumDictionary.Get(DatabaseTables.WpPosts);
            string wpPostMetaTable = EnumDictionary.Get(DatabaseTables.WpPostMeta);

            SqlFileMergeCoordinator coordinator = new(dbExtractionDir, sqlMergedDir);
            coordinator.ProcessMerge(wpPostsTable, wpPostMetaTable);
        }

        public void ImportMergedFiles()
        {
            string sqlMergedDir = EnumDictionary.Get(ExtractDir.SqlMerged);
            ImportFiles.ImportMergedFiles(sqlMergedDir);
        }
    }
}
