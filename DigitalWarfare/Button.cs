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
        private bool _centered;

        public Action OnClick;

        public Button(int x, int y, string text, ConsoleColor colour, bool centered)
        {
            X = x;
            Y = y;
            Text = text;
            Colour = colour;
            Centered = centered;

            Selected = false;
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

        private bool Centered
        {
            get { return _centered; }
            set { _centered = value; }
        }

        public void DrawButton()
        {
            if (Centered)
            {
                Console.ForegroundColor = Selected ? ConsoleColor.Green : Colour;

                var button = TextTweaks.BuildButton(Text);

                for (int i = 0; i < 3; i++)
                {
                    int padding = Math.Max((Console.WindowWidth - button[i].Length) / 2, 0);

                    Console.SetCursorPosition(0, Y + i);

                    string centeredButton = new string(' ', padding) + button[i];
                    Console.WriteLine(centeredButton);
                }

                Console.ResetColor();
            }
            else
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
        }

        // Event thats called when a button is... clicked!
        public void Click()
        {
            OnClick?.Invoke();
        }
    }
}
