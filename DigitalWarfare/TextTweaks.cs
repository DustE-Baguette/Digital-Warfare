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
            const int totalWidth = 17;
            const int innerWidth = totalWidth - 2;

            int totalPadding = innerWidth - text.Length;
            int leftPadding = totalPadding / 2;
            int rightPadding = totalPadding - leftPadding;

            string caps = "+" + new string('-', innerWidth) + "+";
            string middle = "|" + new string(' ', leftPadding) + text + new string(' ', rightPadding) + "|";

            return new[] { caps, middle, caps };
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

        public static void PrintGroupedButtons(List<Button> groupedButtons, int y)
        {
            const int buttonWidth = 17;
            const int spacing = 3;

            int totalWidth = buttonWidth * groupedButtons.Count + (groupedButtons.Count - 1) * spacing;
            int startX = (Console.WindowWidth - totalWidth) / 2;

            for (int i = 0; i < groupedButtons.Count; i++)
            {
                int x = startX + i * (spacing + buttonWidth);
                var button = groupedButtons[i];

                ConsoleColor buttonColour = groupedButtons[i].Selected ? ConsoleColor.Green : ConsoleColor.White;

                groupedButtons[i].X = x;
                groupedButtons[i].Y = y;

                PrintButtonAt(groupedButtons[i].Text, x, y, buttonColour);
            }
        }
    }
}
