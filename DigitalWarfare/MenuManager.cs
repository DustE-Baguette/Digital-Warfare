using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class MenuManager
    {
        private MenuState _currentState;
        public static List<MenuState> allMenus = new List<MenuState>();

        public MenuManager(MenuState currentState)
        {
            CurrentState = currentState;
        }

        public MenuState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public void SetState(MenuState settingState)
        {
            Console.Clear();
            CurrentState = settingState;
        }

        public void DisplayState()
        {
            while (true)
            {
                if (CurrentState == null) continue;

                foreach (Button button in CurrentState.containedButtons)
                {
                    button.DrawButton();
                }

                foreach (StringText text in CurrentState.containedStrings)
                {
                    text.DrawText();
                }
            }
        }
    }
}
