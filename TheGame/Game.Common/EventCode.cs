using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Common
{
    /// <summary>
    /// This enumeration contains all known event codes.
    /// </summary>
    public enum EventCode : byte
    {
        ItemDestroyed = 1,
        ItemMoved,
        WorldExited,
        ItemSubscribed,
        ItemUnsubscribed
    }
}
