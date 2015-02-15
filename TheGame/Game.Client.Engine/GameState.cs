using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Client.Engine
{
    public enum GameState
    {
        Connected,
        Disconnected,
        WaitForConnect,
        WorldEntered
    }
}
