using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Common
{
    /// <summary>
    /// This enumeration contains the values used for event parameter, operation request parameter and operation response parameter.
    /// </summary>
    public enum ParameterCode : byte
    {
        EventCode = 60,
        OldPosition = 92,
        Position = 93,
        ItemId = 95,
        ItemType = 96,
        Name = 97,
        Rotation = 116,
        OldRotation = 117
    }
}
