using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class Button
    {
        private int _x;
        private int _y;
        private string _text;
        ConsoleColor _colour;
        private bool _selected;

        public Button(int x, int y, string text, ConsoleColor colour, bool selected)
        {
            X = x;
            Y = y;
            Text = text;
            Colour = colour;

            Selected = selected;
            DrawButton();
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public ConsoleColor Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        private void DrawButton()
        {
            if (Selected)
            {
                TextTweaks.PrintButtonAt(Text, X, Y, ConsoleColor.Green);
            }
            else
            {
                TextTweaks.PrintButtonAt(Text, X, Y, Colour);
            }
            
        }

        // Change selection value and depending colour
        public void CheckSelection()
        {
            Selected = !Selected;

            ConsoleColor changeColour = Selected ? ConsoleColor.Green : ConsoleColor.White;

            TextTweaks.PrintButtonAt(Text, X, Y, changeColour);
        }
    }
}
