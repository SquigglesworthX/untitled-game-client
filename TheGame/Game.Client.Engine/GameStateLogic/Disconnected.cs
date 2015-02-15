using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public class Disconnected : IGameStateLogic
    {
        public static readonly IGameStateLogic Instance = new Disconnected();

        public GameState State
        {
            get { return GameState.Disconnected; }
        }

        public void OnEventReceive(Game game, EventData eventData)
        {
            // Unexpected
        }

        public void OnOperationReturn(Game game, OperationResponse operationResponse)
        {
            // Unexpected
        }

        public void OnPeerStatusCallback(Game game, StatusCode returnCode)
        {
            game.DebugReturn(DebugLevel.ERROR, returnCode.ToString());
        }

        public void OnUpdate(Game game)
        {
        }

        public void SendOperation(Game game, OperationCode operationCode, Dictionary<byte, object> parameter, bool sendReliable, byte channelId)
        {            
        }
    }
}
