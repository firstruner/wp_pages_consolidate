using ClassLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common
{
    internal static class RessourcesManager
    {
        private static readonly string[] _lineSeparators = new[] { Environment.NewLine, "\r", "\n" };
        public static string GenerateHeaderAndFooter(string tableName, string textPart, bool state)
        {
            switch (textPart.ToLower())
            {
                case "header":

                    string headerContent = GetResourceContent($"{tableName}_header");
                    if (state)
                        return headerContent;

                    StringBuilder result = new StringBuilder();

                    foreach (string line in headerContent.Split(_lineSeparators, StringSplitOptions.None))

                        if (!line.Contains($"DROP TABLE IF EXISTS `{tableName}`;"))
                            result.AppendLine(line);

                    return result.ToString();
                    
                case "footer":
                    return Resources.wp_posts_footer;

                default:
                    throw new ArgumentException($"Partie de texte non reconnue : {textPart}. Utilisez 'header' ou 'footer'.");
            }
        }
        private static string GetResourceContent(string resourceName)
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            return resourceManager.GetString(resourceName) ?? throw new FileNotFoundException($"La ressource {resourceName} n'a pas été trouvée.");
        }
    }
}
