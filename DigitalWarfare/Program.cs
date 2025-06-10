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

            //SetTitleScreen();

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

            string title = " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n";


            StringText titleTest = new StringText(0, 20, title, "GroupCentered", ConsoleColor.DarkGreen);
            titleTest.DrawText();

            StringText testLine = new StringText(0, 7, "TESTTESTTESTTEST TEST TEST TEST TEST TESTTEST...", "TypeOut", ConsoleColor.Yellow);
            testLine.DrawText();
            Console.WriteLine();

            Button upperButton = new Button(0, 10, "Upper", ConsoleColor.White, true, true);
            Button lowerButton = new Button(75, 15, "Lower", ConsoleColor.White, false, false);

            upperButton.DrawButton();
            lowerButton.DrawButton();

            buttonList.Add(upperButton);
            buttonList.Add(lowerButton);

            upperButton.OnClick = () => { Console.Clear(); Console.WriteLine("Upper btn clicked"); };
            lowerButton.OnClick = () => { Console.Clear(); Console.WriteLine("Lower btn clicked"); };

            currentSelected = upperButton;

            ButtonSelection();

            // Called when button selection is required. Takes control of console
            void ButtonSelection()
            {
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
                            currentSelected.Click();
                            return;
                    }
                }
            }

            // Takes the change in X and Y and finds the nearest button in the changed direction
            void CheckButton(int xChange, int yChange)
            {
                int minDist = int.MaxValue;
                Button closestButton = null;

                foreach (Button button in buttonList)
                {
                    if (button == currentSelected) continue; // If no other button in selected direction

                    if ((xChange != 0 && Math.Sign(button.X - currentSelected.X) != xChange) || (yChange != 0 && Math.Sign(button.Y - currentSelected.Y) != yChange)) continue;

                    int distance = Math.Abs(button.X - currentSelected.X) + Math.Abs(button.Y - currentSelected.Y);
                    if (distance < minDist)
                    {
                        minDist = distance;
                        closestButton = button;
                    }
                }

                // Deselects previously selected button, then selects new one
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