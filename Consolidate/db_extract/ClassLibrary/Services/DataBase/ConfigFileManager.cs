namespace ClassLibrary.Services.DataBase
{
    internal class ConfigFileManager
    {
        public static Dictionary<string, string> GetConfigFile(string path)
        {
            Dictionary<string, string> config = new Dictionary<string, string>();

            try
            {
                string[] contents = File.ReadAllLines(path);

                foreach (string line in contents)
                {
                    string[] keyValue = line.Split('=');
                    config.Add(keyValue[0], keyValue[1]);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            return config;
        }
    }
}
