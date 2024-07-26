using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    internal interface ISqlFileMerger
    {
        void MergeFiles(string tableName);
        List<string> GrabSqlFiles(string tableName);
        List<string> MergeInsertStatements(List<string[]> allFileLines, string tableName);
    }
}
