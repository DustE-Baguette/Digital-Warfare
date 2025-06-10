using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DigitalWarfare
{
    public class StringText
    {
        private int _x;
        private int _y;
        private string _text;
        private string _type;
        ConsoleColor _colour;

        public StringText(int x, int y, string text, string type, ConsoleColor colour)
        {
            X = x;
            Y = y;
            Text = text;
            Type = type;
            Colour = colour;
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

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public ConsoleColor Colour
        {
            get { return _colour; }
            set { _colour = value; }
        }

        public void DrawText()
        {
            Console.ForegroundColor = Colour;

            if (Type == "Centered") // Regular text centered at a specific y pos
            {
                Console.SetCursorPosition(0, Y);
                Console.WriteLine(TextTweaks.CentreLine(Text));
            }
            else if (Type == "TypeOut") // Typed out text at a specific pos
            {
                Console.SetCursorPosition(X, Y);
                TextTweaks.TypeOut(Text, Colour, 40);
            }
            else if (Type == "Group") // Muli-line text at a specific pos
            {
                var lines = Text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

                for (int i = 0; i < lines.Length; i++)
                {
                    var line = lines[i];

                    Console.SetCursorPosition(X, Y + i);
                    Console.WriteLine(line);
                }

            }
            else if (Type == "GroupCentered")
            {
                string[] textGroup = TextTweaks.CentreGroup(Text);

                for (int i = 0; i < textGroup.Length; i++)
                {
                    var text = textGroup[i];

                    Console.SetCursorPosition(0, Y + i);
                    Console.WriteLine(text);
                }
            }
            else // Regular text at a specific pos
            {
                Console.SetCursorPosition(X, Y);
                Console.WriteLine(Text);
            }

                Console.ResetColor();
        }
    }
}
