using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public class WaitingForConnect : IGameStateLogic
    {
        public static readonly IGameStateLogic Instance = new WaitingForConnect();

        public GameState State
        {
            get { return GameState.WaitForConnect; }
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
            switch (returnCode)
            {
                case StatusCode.Connect:
                    {      
                        // Do setup
                        game.SetConnected();
                        game.Avatar.EnterWorld();
                        break;
                    }
                case StatusCode.Disconnect:
                case StatusCode.DisconnectByServer:
                case StatusCode.DisconnectByServerLogic:
                case StatusCode.DisconnectByServerUserLimit:
                case StatusCode.TimeoutDisconnect:
                    {
                        game.SetDisconnected();
                        break;
                    }

                default:
                    {
                        game.DebugReturn(DebugLevel.ERROR, returnCode.ToString());
                        break;
                    }
            }
        }

        public void OnUpdate(Game game)
        {
            game.Peer.Service();
        }

        public void SendOperation(Game game, OperationCode operationCode, Dictionary<byte, object> parameter, bool sendReliable, byte channelId)
        {
        }
    }
}
