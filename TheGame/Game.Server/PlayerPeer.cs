using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheGame.Common;

namespace TheGame.Server
{
    public class PlayerPeer : PeerBase
    {
        public PlayerPeer(IRpcProtocol protocol, IPhotonPeer unmanagedPeer) 
            :base(protocol, unmanagedPeer)
        {        
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            //test
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            switch ((OperationCode)operationRequest.OperationCode)
            {
                case OperationCode.EnterWorld:
                    {
                        OperationEnterWorld(operationRequest, sendParameters);
                        break;
                    }
            }
        }

        public void OperationEnterWorld(OperationRequest request, SendParameters sendParameters)
        {
            // Do important server things

            // Presumably get my character and all myItems from database and add to world.itemCache

            var response = new OperationResponse(request.OperationCode);
            this.SendOperationResponse(response, sendParameters);
        }
    }
}
