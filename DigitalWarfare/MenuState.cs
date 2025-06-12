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
        public List<ButtonGroup> containedGroups = new List<ButtonGroup>();

        private Button _selected;

        public MenuState(List<Button> containedButtons, List<StringText> containedStrings, List<ButtonGroup> containedGroups, Button selected)
        {
            this.containedButtons = containedButtons;
            this.containedStrings = containedStrings;
            this.containedGroups = containedGroups;
            Selected = selected;
        }

        public Button Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
    }
}
