using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_extract.Interfaces
{
    internal interface IDatabaseExtractor
    {
        void ExtractData(DatabaseTables table);
    }
}
