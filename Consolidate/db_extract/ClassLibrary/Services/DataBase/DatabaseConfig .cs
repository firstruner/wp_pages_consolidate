using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Services.Common;
using ClassLibrary.Services.Common.Utils;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace ClassLibrary.Services.DataBase
{
    public static class DatabaseConfig
    {
        public static string? ConnectionString { get; private set; }
        public static string? ExtractionDir { get; private set; }

        static DatabaseConfig()
        {
            InitializeConfig();
        }
        private static void InitializeConfig()
        {
            try
            {
                string configFilePath = DirectoryHelper.GetStartupPath() + @"\Consolidate\Config\config.cfg";

                if (!File.Exists(configFilePath))
                {
                    throw new FileNotFoundException($"The configuration file could not be found in '{configFilePath}'.");
                }
                var config = ConfigFileManager.GetConfigFile(configFilePath);

                string server = config["Host"];
                string userId = config["UserId"];
                string password = config["Password"];
                string database = config["Database"];

                ConnectionString = $"server={server};user id={userId};password={password};database={database};Convert Zero Datetime=True";
            }
            catch (Exception ex)
            {
                ConsoleHelper.ChangeColors(ConsoleColor.White, ConsoleColor.Red);
                Console.WriteLine($"An error occurred while initializing configuration: {ex.Message}");
                throw;
            }
        }
        public static string SetExtractionDir(string folderName)
        {
            ExtractionDir = DirectoryHelper.GetStartupPath() + $@"\Consolidate\{folderName}";
            DirectoryHelper.InitializeDirectories(ExtractionDir);
            return ExtractionDir;
        }
    }
}
