using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class MenuState
    {
        public List<Button> containedButtons = new List<Button>();
        public List<StringText> containedStrings = new List<StringText>();

        public MenuState(List<Button> containedButtons, List<StringText> containedStrings)
        {
            this.containedButtons = containedButtons;
            this.containedStrings = containedStrings;
        }
    }
}
