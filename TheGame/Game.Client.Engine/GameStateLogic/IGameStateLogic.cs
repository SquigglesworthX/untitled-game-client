using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public interface IGameStateLogic
    {
        GameState State { get; }

        void OnEventReceive(Game gameLogic, EventData eventData);

        void OnOperationReturn(Game gameLogic, OperationResponse operationResponse);

        void OnPeerStatusCallback(Game gameLogic, StatusCode returnCode);

        void OnUpdate(Game gameLogic);

        void SendOperation(Game game, OperationCode operationCode, Dictionary<byte, object> parameter, bool sendReliable, byte channelId);
    }
}
