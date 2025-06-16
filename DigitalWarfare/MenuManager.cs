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
        private Button _currentSelected;

        public List<MenuState> allMenus = new List<MenuState>();

        public MenuManager()
        {
        }

        public MenuState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; }
        }

        public Button CurrentSelected
        {
            get { return _currentSelected; }
            set { _currentSelected = value; }
        }

        public void CreateStates()
        {
            MenuFactory.CreateMenus(this);
        }

        public void SetState(MenuState settingState)
        {
            Console.Clear();
            CurrentState = settingState;

            DisplayState();
        }

        // Displays all buttons and text elements onto console
        public void DisplayState()
        {
            if (CurrentState != null)
            {
                foreach (Button button in CurrentState.containedButtons)
                {
                    if (button == CurrentState.Selected)
                    {
                        button.Selected = true;
                    }

                    button.DrawButton();
                }

                foreach (StringText text in CurrentState.containedStrings)
                {
                    text.DrawText();
                }

                foreach (ButtonGroup group in CurrentState.containedGroups)
                {
                    foreach (Button button in group.GroupList)
                    {
                        if (button == CurrentState.Selected)
                        {
                            button.Selected = true;
                        }
                    }

                    group.DrawGroup();
                }

                CurrentSelected = CurrentState.Selected;
            }

            ButtonSelection();
        }

        // Called when button selection is required. Takes control of console
        public void ButtonSelection()
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
                        CheckButton(+1, 0);
                        break;
                    case ConsoleKey.A:
                        CheckButton(-1, 0);
                        break;
                    case ConsoleKey.Enter: // Return on enter press
                        Console.Clear();
                        CurrentSelected.Click();
                        return;
                }
            }
        }

        // Takes the change in X and Y and finds the nearest button in the changed direction
        public void CheckButton(int xChange, int yChange)
        {
            int minDist = int.MaxValue;
            Button closestButton = null;

            List<Button> totalButtons = new List<Button>();
            
            foreach (Button button in CurrentState.containedButtons)
            {
                totalButtons.Add(button);
            }

            foreach (ButtonGroup buttonGroup in CurrentState.containedGroups)
            {
                foreach (Button button in buttonGroup.GroupList)
                {
                    totalButtons.Add(button);
                }
            }

            foreach (Button button in totalButtons)
            {
                if (button == CurrentSelected) continue; // If no other button in selected direction

                if (xChange != 0 && (button.Y != CurrentSelected.Y || Math.Sign(button.X - CurrentSelected.X) != xChange))
                    continue;

                if (yChange != 0 && (button.X != CurrentSelected.X || Math.Sign(button.Y - CurrentSelected.Y) != yChange))
                    continue;

                int distance = Math.Abs(button.X - CurrentSelected.X) + Math.Abs(button.Y - CurrentSelected.Y);
                if (distance < minDist)
                {
                    minDist = distance;
                    closestButton = button;
                }
            }

            // Deselects previously selected button, then selects new one
            if (closestButton != null)
            {
                CurrentSelected.Selected = false;
                closestButton.Selected = true;

                closestButton.DrawButton();
                CurrentSelected.DrawButton();

                CurrentSelected = closestButton;
            }
        }
    }
}
