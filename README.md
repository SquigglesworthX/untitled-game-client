untitled-game-client
====================

TheGame
  - Doesn't really do anything yet. Mainly just infrastructure code based off the Photon MMO Demo project.

TheGame.sln
  Game.Server
    - Server side game logic. Currently the dlls get copied to the PhotonControl installed locally on your pc.
        -http://doc.exitgames.com/en/onpremise/current/getting-started/photon-server-in-5min
        - You will need to set the build target for coping the dlls to the correct directory (build.targets)
        - You will need to add configuration to the photon control to have it start TheGame as the default application (PhotonServer.config)
        
  Game.Common
    - Class libray used by client and server. Basically just a bunch of enums for OpCodes etc.
    - Gets copied to the Game.Client.Unity3D\Assets\Libs folder (build.targets)
  
  Game.Client.Engine
    - Class library. The main engine of the game to run client side. It facilitates the connection and communication 
      with the server.
    - Gets copied to the Game.Client.Unity3D\Assets\Libs folder (build.targets)

  Game.Client.Unity3D
    - This is the Unity project. It Initializes the Game Engine and does Unity things.

** Removed Infinite World project that used out-of-box photon networking
