using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public class WorldEntered : IGameStateLogic
    {
        public static readonly IGameStateLogic Instance = new WorldEntered();

        public GameState State
        {
            get { return GameState.WorldEntered; }
        }

        public void OnEventReceive(Game game, EventData eventData)
        {
            switch ((EventCode)eventData.Code)
            {
                case EventCode.ItemMoved:
                    {
                        return;
                    }
                case EventCode.ItemDestroyed:
                    {
                        return;
                    }
                case EventCode.ItemSubscribed:
                    {
                        return;
                    }
                case EventCode.ItemUnsubscribed:
                    {
                        return;
                    }
                case EventCode.WorldExited:
                    {
                        return;
                    }
            }
            // Unexpected
        }

        public void OnOperationReturn(Game game, OperationResponse operationResponse)
        {
            if (operationResponse.ReturnCode == 0)
            {
                switch ((OperationCode)operationResponse.OperationCode)
                {
                    case OperationCode.CreateWorld:
                    case OperationCode.EnterWorld:
                        {
                            return;
                        }
                    case OperationCode.ExitWorld:
                        {
                            return;
                        }
                    case OperationCode.Move:
                    case OperationCode.SpawnItem:
                    case OperationCode.DestroyItem:
                    case OperationCode.SubscribeItem:
                    case OperationCode.UnsubscribeItem:
                        {
                            return;
                        }
                }
            }

            // Unexpected 
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
