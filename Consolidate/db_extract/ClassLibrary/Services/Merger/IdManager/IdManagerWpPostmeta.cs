using ClassLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Merger.IdManager
{
    internal class IdManagerWpPostmeta
    {
        private readonly List<string[]> _idMapping;
        private int _startId;

        private readonly IIdManager _idManager;

        public IdManagerWpPostmeta(IIdManager idManager)
        {
            _idManager = idManager;
            _idMapping = idManager.GetIdMapping();
            _startId = 1;
        }
        public string ManageId(string line, string userName)
        {
            string newId = _startId++.ToString();
            string newLine = ReplaceIdInLine(line, newId, userName);

            return newLine;
        }

        private string ReplaceIdInLine(string line, string newId, string userName)
        {
            string[] parts = line.Split(',');

            if (parts.Length < 2)
            {
                Console.WriteLine($"Warning: Line has fewer than 2 parts: {line}");
                return line; // Return the original line instead of throwing an exception
            }

            string oldPostId = parts[1].Trim();

            // Select all the mappings where postId = id and compare the username to grab the good id
            var selection = _idMapping.Where(array => array[0].ToString() == oldPostId).ToList();

            foreach (string[] idEntry in selection)
            {
                if (idEntry[1] == userName)
                {
                    // Use the corresponding newId found in idMap
                    string postId = idEntry[2]; // new postId = newId
                    return $"({newId}, {postId}," + string.Join(",", parts.Skip(2));
                }
            }

            // For the rest only check the matching id in _idMapping
            foreach (string[] idEntry in _idMapping)
            {
                if (idEntry.Length == 3 && idEntry[0] == oldPostId)
                {
                    // Use the corresponding newId found in idMap
                    string postId = idEntry[2]; // new postId = newId
                    return $"({newId}, {postId}," + string.Join(",", parts.Skip(2));
                }
            }

            throw new InvalidOperationException("The line does not contain enough parts to process.");
        }
    }
}
