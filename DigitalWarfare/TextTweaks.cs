using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class TextTweaks
    {
        // Prints out text one char at a time to simulate being typed out
        public static void TypeOut(string text, ConsoleColor colour, int delay)
        {
            Console.ForegroundColor = colour;

            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Delay in ms
            }

            Console.ResetColor();
        }

        // Returns single line text thats centered
        public static string CentreLine(string text)
        {
            return (string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }

        // Returns multi-line text thats centered
        public static string[] CentreGroup(string text)
        {
            var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            List<string> centredLines = new List<string>();

            foreach (var line in lines)
            {
                int padding = Math.Max((Console.WindowWidth - line.Length) / 2, 0);
                string centredLine = new string(' ', padding) + line;
                centredLines.Add(centredLine);
            }

            return centredLines.ToArray();
        }

        public static string[] BuildButton(string text)
        {
            if (text.Length % 2 == 0) // Even length
            {
                double padding = (16 - text.Length);
                padding = Math.Round(padding / 2);

                string caps = "+----------------+";
                string middle = '|' + new string(' ', (int)padding) + text + new string(' ', (int)padding) + '|';

                return new[] { caps, middle, caps };
            }
            else // Odd length
            {
                double padding = (15 - text.Length);
                padding = Math.Round(padding / 2);

                string caps = "+---------------+";
                string middle = '|' + new string(' ', (int)padding) + text + new string(' ', (int)padding) + '|';

                return new[] { caps, middle, caps };
            }
        }

        public static void PrintButtonAt(string text, int x, int y, ConsoleColor colour)
        {
            Console.ForegroundColor = colour;

            var buttonLines = BuildButton(text);

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(buttonLines[i]);
            }

            Console.ResetColor();
        }
    }
}
