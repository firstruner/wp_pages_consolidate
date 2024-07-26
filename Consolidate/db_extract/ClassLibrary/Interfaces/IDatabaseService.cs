using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace db_extract.Interfaces
{
    internal interface IDatabaseService
    {
        void OpenConnection(string connectionString);
        void CloseConnection();
        bool IsConnectionOpen { get; }
    }
}
