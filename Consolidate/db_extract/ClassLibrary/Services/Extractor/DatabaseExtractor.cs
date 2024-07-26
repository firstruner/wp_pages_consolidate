using db_extract.Enumerations;
using db_extract.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Properties;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;

namespace ClassLibrary.Services.Extractor
{
    public class DatabaseExtractor : IDatabaseExtractor
    {
        private readonly string _connectionString;
        private readonly string _extractionDir;
        private readonly int _rowPerFile;

        public DatabaseExtractor(string? connectionString, string? extractionDir)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            _extractionDir = extractionDir ?? throw new ArgumentNullException(nameof(extractionDir));
            _rowPerFile = Constants.ROWS_PER_FILE;
        }

        public void ExtractData(DatabaseTables table)
        {
            MessageHelper.ExtractionMessage(EnumDictionary.Get(table));

            string tableName = EnumDictionary.Get(table);

            MySqlDataAdapter mDA = new MySqlDataAdapter(
                new MySqlCommand($"SELECT * FROM {tableName}",
                new MySqlConnection(_connectionString))
            );

            DataTable dataTable = new();
            mDA.Fill(dataTable);

            // Limit the extraction to 300 rows per file
            FileSplitter.SplitIntoFiles(dataTable.AsEnumerable(), _rowPerFile, tableName, null, _extractionDir);     
        }
    }
}
