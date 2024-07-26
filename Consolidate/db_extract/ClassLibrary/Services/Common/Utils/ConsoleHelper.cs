using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Services.Common.Utils
{
    public static class ConsoleHelper
    {
        public static void ChangeColors(ConsoleColor colorTxt, ConsoleColor colorBck)
        {
            Console.ForegroundColor = colorTxt;
            Console.BackgroundColor = colorBck;
        }
        public static void CloseConsole()
        {
            ChangeColors(ConsoleColor.White, ConsoleColor.DarkCyan);
            Console.WriteLine("Operation completed. Press any key to exit or wait for 15 seconds...");

            for (int i = 15; i > 0; i--)
            {
                Console.Write($"\rClosing in  {i} secondes...   ");
                Thread.Sleep(1000);

                if (Console.KeyAvailable)
                {
                    Console.ReadKey(intercept: true);
                    Console.WriteLine("\rExiting on user request.");
                    return;
                }
            }
            Console.WriteLine("\rClosing automatically. Goodbye!");
        }
        public static void ShowMessage(string message, ConsoleColor foreColor, ConsoleColor backgroundColor)
        {
            ChangeColors(foreColor, backgroundColor);
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
