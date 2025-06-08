namespace DigitalWarfare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selectedOption = 0; 

            ConsoleTweaks.MoveWindowToCenter();
            Console.Title = "DIGITAL WARFARE";

            

            

            string title = " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n";

            Console.WriteLine(new string('=', Console.WindowWidth)); 

            TextTweaks.TypeOut("lognbk asdjklasd aqwieoiqwbn hjasllas", ConsoleColor.Magenta, 35);
            Console.WriteLine();

            var buttonEven = TextTweaks.BuildButton("What");
            var buttonOdd = TextTweaks.BuildButton("whatr");

            Console.WriteLine();

            foreach (var line in buttonOdd)
            {
                Console.WriteLine(TextTweaks.CentreLine(line));
            }

            TextTweaks.PrintButtonAt("WoahMan", 35, 35, ConsoleColor.DarkGreen);



            Console.ReadLine();
        }
    }
}