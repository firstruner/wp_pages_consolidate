using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Services.Merger.IdManager
{
    internal class IdManagerWpPosts : IIdManager
    {
        private static IdManagerWpPosts? _instance;
        private static readonly object _lock = new object();
        private List<string[]> _idMapping;
        private int _newId = 0;
        private bool _firstChange = false;
        private IdManagerWpPosts()
        {
            _idMapping = new List<string[]>();
        }

        // Singleton for only one instanciation
        public static IdManagerWpPosts Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new IdManagerWpPosts();
                    }
                    return _instance;
                }
            }
        }
        public string ManageId(string line, string userName)
        {
            string[] idMap;

            // Extract the old ID
            string oldId = ExtractIdFromLine(line);

            // Generate new IDs while keeping the original ID for the original common data
            foreach (string[] idArray in _idMapping)
            {
                if (oldId == idArray[0])
                {
                    if (!_firstChange)
                    {
                        _firstChange = true;
                    }
                    _newId++;
                    idMap = [oldId, userName, _newId.ToString()];
                    _idMapping.Add(idMap);
                    return ReplaceIdInLine(line, _newId.ToString());
                }
            }
            if (!_firstChange)
            {
                _newId = int.Parse(oldId);
                idMap = [oldId, userName, oldId];
                _idMapping.Add(idMap);
                return ReplaceIdInLine(line, _newId.ToString());
            }
            else
            {
                _newId++;
                idMap = [oldId, userName, _newId.ToString()];
                _idMapping.Add(idMap);
                return ReplaceIdInLine(line, _newId.ToString());
            }
        }

        private static string ExtractIdFromLine(string line)
        {
            string trimmedLine = line.Trim('(', ')');
            string[] parts = trimmedLine.Split(',');

            if (parts.Length > 0)
            {
                string id = parts[0].Trim();
                return id;
            }
            return string.Empty;
        }
        private static string ReplaceIdInLine(string line, string newId)
        {
            int firstCommaIndex = line.IndexOf(',');

            if (firstCommaIndex != -1)
            {
                return $"({newId}" + line.Substring(firstCommaIndex);
            }
            return line;
        }

        public List<string[]> GetIdMapping()
        {
            return _idMapping;
        }
    }
}
