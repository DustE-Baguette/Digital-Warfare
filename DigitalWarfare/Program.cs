namespace DigitalWarfare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int consoleWidth = 150;
            int consoleHeight = 32;

            List<Button> buttonList = new List<Button>();
            Button currentSelected;

            // Set console tweaks in place
            try
            {
                Console.Title = "DIGITAL WARFARE";

                Console.SetWindowSize(consoleWidth, consoleHeight);
                Console.SetBufferSize(consoleWidth, consoleHeight);

                ConsoleTweaks.MoveWindowToCenter();
                ConsoleTweaks.DisableResize();
                Console.CursorVisible = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            SetTitleScreen();

            void SetTitleScreen()
            {
                string title = " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n";
                string[] centeredTitle = TextTweaks.CentreGroup(title);

                foreach (string line in centeredTitle)
                {
                    Console.WriteLine(line);
                }

                Console.WriteLine(new string('=', Console.WindowWidth));
            }

            TextTweaks.TypeOut("lognbk asdjklasd aqwieoiqwbn hjasllas", ConsoleColor.Magenta, 35);
            Console.WriteLine();

            Button upperButton = new Button(75, 10, "Upper", ConsoleColor.White, true);
            Button lowerButton = new Button(75, 15, "Lower", ConsoleColor.White, false);

            buttonList.Add(upperButton);
            buttonList.Add(lowerButton);

            currentSelected = upperButton;

            while (true)
            {
                var key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.W:
                        CheckButton(0, -1);
                        break;
                    case ConsoleKey.S:
                        CheckButton(0, +1);
                        break;
                    case ConsoleKey.D:
                        CheckButton(-1, 0);
                        break;
                    case ConsoleKey.A:
                        CheckButton(+1, 0);
                        break;
                    case ConsoleKey.Enter: // Return on enter press
                        Console.Clear();
                        // Check what button is pressed.
                        return;
                }
            }

            void CheckButton(int xChange, int yChange)
            {
                int minDist = int.MaxValue;
                Button closestButton = null;

                foreach (Button button in buttonList)
                {
                    if (button == currentSelected) continue;

                    if ((xChange != 0 && Math.Sign(button.X - currentSelected.X) != xChange) || (yChange != 0 && Math.Sign(button.Y - currentSelected.Y) != yChange)) continue;

                    int distance = Math.Abs(button.X - currentSelected.X) + Math.Abs(button.Y - currentSelected.Y);
                    if (distance < minDist)
                    {
                        minDist = distance;
                        closestButton = button;
                    }
                }

                if (closestButton != null)
                {
                    currentSelected.CheckSelection();
                    currentSelected = closestButton;
                    currentSelected.CheckSelection();
                }
            }

            Console.ReadLine();
        }
    }
}