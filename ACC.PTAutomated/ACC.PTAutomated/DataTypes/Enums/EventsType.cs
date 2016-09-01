using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ACC.PTAutomated.DataTypes.Enums
{
    public enum EventsType
    {
        [Description("Mouse Move")]
        MouseMove = 1,
        [Description("Right Click")]
        RightClick = 2,
        [Description("Left Click")]
        LeftClick = 3,
        [Description("Key Press")]
        KeyPress = 4
    }
}
