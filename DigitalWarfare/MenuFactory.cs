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

            Button startBTN = new Button(0, 15, "Start", ConsoleColor.White, true);
            buttons.Add(startBTN);
            startBTN.OnClick = () => { menuManager.SetState(SelectionMenu(menuManager)); };

            Button quitBTN = new Button(0, 20, "Exit", ConsoleColor.White, true);
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

            Button yesBTN = new Button(0, 10, "Oui", ConsoleColor.White, false);
            yesBTN.OnClick = () => { Environment.Exit(0); };

            Button noBTN = new Button(0, 10, "Non", ConsoleColor.White, false);
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

            StringText soldierTXT = new StringText(0, 5, "-- SOLDIER --", "TypeOut", ConsoleColor.Cyan);
            stringTexts.Add(soldierTXT);

            Button soldierBTN = new Button(120, 5, "Select", ConsoleColor.White, false);
            buttons.Add(soldierBTN);
            soldierBTN.OnClick = () => { menuManager.SetState(SoldierMenu(menuManager)); };

            Button pilotBTN = new Button(120, 10, "Select", ConsoleColor.White, false);
            buttons.Add(pilotBTN);
            pilotBTN.OnClick = () => { menuManager.SetState(PilotMenu(menuManager)); };

            Button generalBTN = new Button(120, 15, "Select", ConsoleColor.White, false);
            buttons.Add(generalBTN);
            generalBTN.OnClick = () => { menuManager.SetState(GeneralMenu(menuManager)); };

            MenuState selectionMenu = new MenuState(buttons, stringTexts, buttonGroups, soldierBTN);
            return selectionMenu;
        }

        public static MenuState SoldierMenu(MenuManager menuManager)
        {
            return null;
        }

        public static MenuState PilotMenu(MenuManager menuManager)
        {
            return null;
        }

        public static MenuState GeneralMenu(MenuManager menuManager)
        {
            return null;
        }
    }
}
