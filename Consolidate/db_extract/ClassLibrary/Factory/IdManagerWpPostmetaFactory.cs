using ClassLibrary.Interfaces;
using ClassLibrary.Services.Merger.IdManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Factory
{
    internal class IdManagerWpPostmetaFactory
    {
        public static IdManagerWpPostmeta Create()
        {
            IIdManager idManager = IdManagerWpPosts.Instance;
            return new IdManagerWpPostmeta(idManager);
        }
    }
}
