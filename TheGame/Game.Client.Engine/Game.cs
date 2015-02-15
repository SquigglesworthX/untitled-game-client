using ExitGames.Client.Photon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public class Game : IPhotonPeerListener
    {
        private string ServerAddress = "127.0.0.1:4530";
        private string ApplicationName = "GameServer";

        
        private IGameStateLogic _gameStateLogic;

        private PhotonPeer _peer;
        public PhotonPeer Peer
        {
            get { return _peer; }
        }

        private readonly MyItem _avatar;
        public MyItem Avatar
        {
            get
            {
                return _avatar;
            }
        }

        public GameState State
        {
            get { return _gameStateLogic.State; }
        }

        // Temporary logging event to send messages to the unity debug console
        // Replace with GameListener interface
        public event Action<string> Logger;
        private void Log(string msg)
        {
            if (Logger != null)
            {
                Logger(msg);
            }
        }

        public Game()
        {
            // Make this work in UDP
            _peer = new PhotonPeer(this, ConnectionProtocol.Tcp);
            _gameStateLogic = Disconnected.Instance; ;
            _avatar = new MyItem(Guid.NewGuid().ToString(), (byte)ItemType.Avatar, this, "Johnson");            
        }

        public void Initialize()
        {
            _gameStateLogic = WaitingForConnect.Instance;
            _peer.Connect(ServerAddress, ApplicationName);
            Log("Waiting for Connect");   
        }

        public void SetConnected()
        {
            _gameStateLogic = Connected.Instance;
            Log("Connected");
        }

        public void SetDisconnected()
        {
            _gameStateLogic = Disconnected.Instance;
            _peer.Disconnect();
            Log("disconnected");
        }

        public void SetWorldEntered()
        {
            _gameStateLogic = WorldEntered.Instance;
        }
                
        public void Update()
        {
            _gameStateLogic.OnUpdate(this);            
        }

        #region IPhotonPeerListener implementation
        
        // Send operation to the photon server
        public void SendOperation(OperationCode operationCode, Dictionary<byte, object> parameter, bool sendReliable, byte channelId)
        {            
            _gameStateLogic.SendOperation(this, operationCode, parameter, sendReliable, channelId);
        }

        public void DebugReturn(DebugLevel level, string message)
        {
            Log(message);
        }

        // Event received from the server. eg. another character moved
        public void OnEvent(EventData eventData)
        {
            _gameStateLogic.OnEventReceive(this, eventData);
        }

        // The response back from an operation sent to the server. (not every operation needs a response)
        public void OnOperationResponse(OperationResponse operationResponse)
        {
            _gameStateLogic.OnOperationReturn(this, operationResponse);
        }              

        // Fired when the connection status changes
        public void OnStatusChanged(StatusCode statusCode)
        {
            _gameStateLogic.OnPeerStatusCallback(this, statusCode);
        } 
        #endregion
    }

}
