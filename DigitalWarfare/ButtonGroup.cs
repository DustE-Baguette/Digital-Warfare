using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWarfare
{
    public class ButtonGroup
    {
        private List<Button> _groupList = new List<Button>();
        private int _y;

        public ButtonGroup(List<Button> groupList, int y)
        {
            GroupList = groupList;
            Y = y;
        }

        public List<Button> GroupList
        {
            get { return _groupList; }
            set { _groupList = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public void DrawGroup()
        {
            TextTweaks.PrintGroupedButtons(GroupList, Y);
        }
    }
}
