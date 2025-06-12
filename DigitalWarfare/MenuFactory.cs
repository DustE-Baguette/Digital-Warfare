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
            List<ButtonGroup> buttonGroups = new List<ButtonGroup>();

            StringText title = new StringText(0, 0, " _____    __   ______   __   ______  ______   __           __     __   ______   ______   ______  ______   ______   ______    \r\n/\\  __-. /\\ \\ /\\  ___\\ /\\ \\ /\\__  _\\/\\  __ \\ /\\ \\         /\\ \\  _ \\ \\ /\\  __ \\ /\\  == \\ /\\  ___\\/\\  __ \\ /\\  == \\ /\\  ___\\   \r\n\\ \\ \\/\\ \\\\ \\ \\\\ \\ \\__ \\\\ \\ \\\\/_/\\ \\/\\ \\  __ \\\\ \\ \\____    \\ \\ \\/ \".\\ \\\\ \\  __ \\\\ \\  __< \\ \\  __\\\\ \\  __ \\\\ \\  __< \\ \\  __\\   \r\n \\ \\____- \\ \\_\\\\ \\_____\\\\ \\_\\  \\ \\_\\ \\ \\_\\ \\_\\\\ \\_____\\    \\ \\__/\".~\\_\\\\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_\\   \\ \\_\\ \\_\\\\ \\_\\ \\_\\\\ \\_____\\ \r\n  \\/____/  \\/_/ \\/_____/ \\/_/   \\/_/  \\/_/\\/_/ \\/_____/     \\/_/   \\/_/ \\/_/\\/_/ \\/_/ /_/ \\/_/    \\/_/\\/_/ \\/_/ /_/ \\/_____/ \r\n                                                                                                                             ", "GroupCentered", ConsoleColor.White);
            stringTexts.Add(title);

            Button startBTN = new Button(0, 15, "Start", ConsoleColor.White, true, true);
            buttons.Add(startBTN);
            startBTN.OnClick = () => { menuManager.SetState(SelectionMenu(menuManager)); };

            Button quitBTN = new Button(0, 20, "Exit", ConsoleColor.White, false, true);
            buttons.Add(quitBTN);
            quitBTN.OnClick = () => { menuManager.SetState(ConfirmationMenu(menuManager)); };

            MenuState launchMenu = new MenuState(buttons, stringTexts, buttonGroups, startBTN);
            return launchMenu;
        }

        public static MenuState ConfirmationMenu(MenuManager menuManager)
        {
            List<Button> buttons = new List<Button>();
            List<StringText> stringTexts = new List<StringText>();
            List<ButtonGroup> buttonGroups = new List<ButtonGroup>();

            StringText confirmaionText = new StringText(0, 5, "Are you sure you want to quit?", "Centered", ConsoleColor.White);
            stringTexts.Add(confirmaionText);

            Button yesBTN = new Button(0, 10, "Oui", ConsoleColor.White, false, false);
            //buttons.Add(yesBTN);
            yesBTN.OnClick = () => { Environment.Exit(0); };

            Button noBTN = new Button(0, 10, "Non", ConsoleColor.White, true, false);
            //buttons.Add(noBTN);
            noBTN.OnClick = () => { menuManager.SetState(LaunchMenu(menuManager)); };
 
            ButtonGroup selectionGroup = new ButtonGroup(new List<Button> { yesBTN, noBTN }, 10);
            buttonGroups.Add(selectionGroup);

            MenuState confirmationMenu = new MenuState(buttons, stringTexts, buttonGroups, noBTN);
            return confirmationMenu;
        }

        public static MenuState SelectionMenu(MenuManager menuManager)
        {
            List<Button> buttons = new List<Button>();
            List<StringText> stringTexts = new List<StringText>();
            List<ButtonGroup> buttonGroups = new List<ButtonGroup>();

            Button beginBTN = new Button(0, 15, "Begin", ConsoleColor.White, true, true);
            buttons.Add(beginBTN);
            beginBTN.OnClick = () => { menuManager.SetState(LaunchMenu(menuManager)); };

            MenuState selectionMenu = new MenuState(buttons, stringTexts, buttonGroups, beginBTN);
            return selectionMenu;
        }
    }
}
