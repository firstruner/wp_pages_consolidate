using db_extract.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    internal interface IIdManager
    {
        string ManageId(string line, string userName);
        List<string[]> GetIdMapping();
    }
}
