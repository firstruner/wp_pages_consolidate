using ClassLibrary.Properties;
using ClassLibrary.Services.Extractor;
using Mysqlx.Crud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary.Services.Common
{
    internal static class DataManager
    {
        public static string GenerateInsertStatements(IEnumerable data, string tableName, string? insertIntoValue)
        {
            const int MAX_INSERT_LENGTH = Constants.MAX_INSERT_LENGTH;

            int currentLength = 0;
            StringBuilder insertStatements = new StringBuilder();

            if (data == null)
            {
                throw new ArgumentException("The DataRow array or the string List must not be empty.", nameof(data));
            }

            if (data is DataRow[] rows)
            {
                ProcessRows(rows, tableName, insertStatements, ref currentLength, MAX_INSERT_LENGTH);
            }
            else if (data is List<string> mergedLines)
            {
                ProcessStrings(mergedLines, insertIntoValue, insertStatements, ref currentLength, MAX_INSERT_LENGTH);
            }
            else
            {
                throw new ArgumentException("Unsupported data type. Expected DataRow[] or List<string>.");
            }

            return insertStatements.ToString();
        }
        private static void ProcessRows(DataRow[] rows, string tableName, StringBuilder insertStatements, ref int currentLength, int maxInsertLength)
        {
            insertStatements.AppendLine(InsertIntoRow(rows, tableName));

            foreach (DataRow row in rows)
            {
                int currentRowIndex = Array.IndexOf(rows, row);
                string rowInsert = GenerateRowInsert(row);
                insertStatements.Append(rowInsert);
                currentLength += rowInsert.Length;

                if (currentLength + rowInsert.Length > maxInsertLength)
                {
                    // End the current INSERT statement and start a new one
                    insertStatements.AppendLine($";");
                    insertStatements.AppendLine(InsertIntoRow(rows, tableName));
                    currentLength = 0;
                }
                else if (currentRowIndex == rows.Length - 1)
                {
                    insertStatements.AppendLine(";");
                }
                else if (currentLength > 0)
                {
                    insertStatements.AppendLine(",");
                }
            }
        }
        private static void ProcessStrings(List<string> mergedLines, string? insertIntoValue, StringBuilder insertStatements, ref int currentLength, int maxInsertLength)
        {
            insertStatements.AppendLine(insertIntoValue);

            for (int i = 0; i < mergedLines.Count; i++)
            {
                currentLength += mergedLines[i].Length;

                if (currentLength + mergedLines[i].Length > maxInsertLength)
                {
                    insertStatements.AppendLine(mergedLines[i] + ";");
                    insertStatements.AppendLine(insertIntoValue);
                    currentLength = 0;
                }
                else if (i == mergedLines.Count - 1)
                {
                    insertStatements.AppendLine(mergedLines[i] + ";");
                }
                else if (currentLength > 0)
                {
                    insertStatements.AppendLine(mergedLines[i] + ",");
                }
            }
        }

        private static string InsertIntoRow(DataRow[] rows, string tableName)
        {
            if (rows.Length == 0)
            {
                throw new ArgumentException("The DataRow array must not be empty.", nameof(rows));
            }
            StringBuilder values = new StringBuilder();

            values.Append($"INSERT INTO {tableName} (");

            // Column names
            DataRow firstRow = rows[0];
            for (int i = 0; i < firstRow.Table.Columns.Count; i++)
                values.Append(
                    firstRow.Table.Columns[i].ColumnName+
                    (i < firstRow.Table.Columns.Count - 1 
                    ?", "
                    : string.Empty
                    ));

            return values + $") VALUES";
        }

        private static string GenerateRowInsert(DataRow row)
        {
            StringBuilder values = new StringBuilder("(");
            for (int i = 0; i < row.ItemArray.Length; i++)
            {
                if (i > 0) values.Append(", ");
                values.Append(FormatValue(row.ItemArray[i]));
            }
            values.Append(')');
            return values.ToString();
        }
        private static string FormatValue(object? value)
        {
            switch (value)
            {
                case null:
                case DBNull _:
                    return "NULL";

                case DateTime dateTimeValue:
                    return "'" + dateTimeValue.ToString("yyyy-MM-dd HH:mm:ss") + "'";

                case string stringValue:
                    string trimedStringValue = stringValue.Trim();
                    return IsNumeric(trimedStringValue) ? trimedStringValue : $"'{EscapeStrings(trimedStringValue)}'";

                default:
                    return value?.ToString() ?? "NULL";
            }
        }
        private static bool IsNumeric(string value)
        {
            return long.TryParse(value, out _) || double.TryParse(value, out _);
        }
        private static string EscapeStrings(string value)
        {
            return value
                .Replace("\\", "\\\\")
                .Replace("'", "\\'")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r");
        }
    }
}
