using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Common
{
    /// <summary>
    /// This enumeration contains known operation codes.
    /// </summary>
    public enum OperationCode : byte
    {        
        Nil = 0,       
        CreateWorld = 90,       
        EnterWorld = 91,
        ExitWorld = 92,
        Move = 93,  
        SpawnItem = 94,
        DestroyItem = 95,
        SubscribeItem = 96,
        UnsubscribeItem = 97     
    }
}
