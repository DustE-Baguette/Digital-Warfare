namespace DigitalWarfare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleTweaks.MoveWindowToCenter();
            Console.Title = "DIGITAL WARFARE";

            // Prints out text one char at a time to simulate being typed out
            void PrintOut(string text, ConsoleColor colour, int delay)
            {
                Console.ForegroundColor = colour;

                foreach (char c in text)
                {
                    Console.Write(c);
                    Thread.Sleep(delay); // Delay in ms
                }

                Console.ResetColor();
            }

            // Prints out text but centred
            void PrintCentreText(string text, ConsoleColor colour, int delay)
            {
                Console.ForegroundColor = colour;

                var lines = text.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                // Simple 1 line strings
                if (lines.Length == 0)
                {
                    Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
                }

                // Complicated mulit-line strings
                foreach (var line in lines)
                {
                    int leftPadding = Math.Max((Console.WindowWidth - line.Length) / 2, 0);
                    Console.Write(new string(' ', leftPadding));

                    foreach (char c in line)
                    {
                        Console.Write(c);
                    }
                    Console.WriteLine();
                }

                Console.ResetColor();
            }

            string title = " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n";
            PrintCentreText(title, ConsoleColor.Blue, 30);

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("=");
            }

        }
    }
}