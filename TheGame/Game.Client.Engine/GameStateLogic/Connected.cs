using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public class Connected : IGameStateLogic
    {
        public static readonly IGameStateLogic Instance = new Connected();

        public GameState State
        {
            get { return GameState.Connected;  }
        }

        public void OnEventReceive(Game game, EventData eventData)
        {
            // unexpected
        }

        public void OnOperationReturn(Game game, OperationResponse operationResponse)
        {
            // Enter world was sent when the waiting for connect connected

            // by default, a return of 0 is "successfully done"
            if (operationResponse.ReturnCode == 0)
            {
                switch ((OperationCode)operationResponse.OperationCode)
                {
                    case OperationCode.CreateWorld:
                        {        
                            // Create a new world
                            // Send Op to enter the world
                            return;
                        }

                    case OperationCode.EnterWorld:
                        {                            
                            game.SetWorldEntered();
                            return;
                        }
                }
            }
        }

        public void OnPeerStatusCallback(Game game, StatusCode returnCode)
        {
            switch (returnCode)
            {
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
            game.Peer.OpCustom((byte)operationCode, parameter, sendReliable, channelId);
        }
    }
}
