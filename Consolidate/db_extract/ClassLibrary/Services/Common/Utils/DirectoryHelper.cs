using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common.Utils
{
    public static class DirectoryHelper
    {
        public static string GetStartupPath()
        {
#pragma warning disable CS8602
            DirectoryInfo directoryInfo = new DirectoryInfo(Environment.CurrentDirectory);
            string targetDirectory = directoryInfo.Parent.Parent.Parent.Parent.Parent.Parent.FullName;
            return targetDirectory;
#pragma warning restore CS8602
        }
        public static void InitializeDirectories(string directory)
        {
            try
            {
                if (directory == null)
                    throw new InvalidOperationException("Directory is not set. Call InitializeDirectories with a valid folder name.");

                Directory.CreateDirectory(directory);

                // Clean the extraction folder 
                foreach (string file in Directory.GetFiles(directory))
                    File.Delete(file);
            }
            catch (Exception ex)
            {
                ConsoleHelper.ChangeColors(ConsoleColor.White, ConsoleColor.Red);
                Console.WriteLine($"An error occurred while initializing directories: {ex.Message}");
                throw;
            }

        }
        public static string SetDirectoryPath(string dirName) => GetStartupPath() + $@"\Consolidate\{dirName}";

    }
}
