using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common
{
    public static class EnumDictionary
    {
        private static readonly Dictionary<Enum, string> EnumToStringMap = new Dictionary<Enum, string>
        {
            // Database table names
            { DatabaseTables.WpPosts, "wp_posts" },
            { DatabaseTables.WpPostMeta, "wp_postmeta" },

            // Extraction directory names
            { ExtractDir.DbExtraction, "db_extraction" },
            { ExtractDir.SqlMerged, "sql_merged" },
            { ExtractDir.DbBackup, "db_backup" },
        };

        public static string Get<TEnum>(TEnum enumValue) where TEnum : Enum
        {

            if (EnumToStringMap.TryGetValue(enumValue, out string? stringValue))

                return stringValue ?? throw new InvalidOperationException($"The value for {enumValue} should not be null."); ;

                throw new ArgumentException($"Value not defined for {enumValue}");
        }
    }
}
