using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public static class MenuFactory
    {
        public static void CreateMenus(MenuManager menuManager)
        {
            menuManager.CurrentState = LaunchMenu(menuManager);
        }

        public static MenuState LaunchMenu(MenuManager menuManager)
        {
            List<Button> buttons = new List<Button>();
            List<StringText> stringTexts = new List<StringText>();

            StringText title = new StringText(0, 0, " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n                                                                                                                             ", "GroupCentered", ConsoleColor.White);
            stringTexts.Add(title);

            Button startBTN = new Button(0, 15, "Start", ConsoleColor.White, true, true);
            buttons.Add(startBTN);
            startBTN.OnClick = () => { menuManager.SetState(SelectionMenu(menuManager)); };

            Button quitBTN = new Button(0, 20, "Exit", ConsoleColor.White, false, true);
            buttons.Add(quitBTN);
            quitBTN.OnClick = () => { Environment.Exit(0); };

            MenuState launchMenu = new MenuState(buttons, stringTexts);
            return launchMenu;
        }

        public static MenuState SelectionMenu(MenuManager menuManager)
        {
            List<Button> buttons = new List<Button>();
            List<StringText> stringTexts = new List<StringText>();

            Button beginBTN = new Button(0, 15, "Begin", ConsoleColor.White, true, true);
            buttons.Add(beginBTN);
            beginBTN.OnClick = () => { menuManager.SetState(LaunchMenu(menuManager)); };

            MenuState selectionMenu = new MenuState(buttons, stringTexts);
            return selectionMenu;
        }
    }
}
