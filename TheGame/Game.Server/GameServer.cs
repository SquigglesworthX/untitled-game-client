using Photon.SocketServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGame.Server
{
    public class GameServer : ApplicationBase
    {
        protected override Photon.SocketServer.PeerBase CreatePeer(Photon.SocketServer.InitRequest initRequest)
        {
            return new PlayerPeer(initRequest.Protocol, initRequest.PhotonPeer);
        }

        protected override void Setup()
        {
        }

        protected override void TearDown()
        {
        }
    }
}
