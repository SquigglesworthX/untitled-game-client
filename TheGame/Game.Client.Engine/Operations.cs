using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheGame.Common;

namespace TheGame.Client.Engine
{
    public static class Operations
    {
        private static byte OperationChannel = 0;
        private static byte ItemChannel = 1;

        public static void EnterWorld(Game game, string name, float[] position, float[] rotation)
        {
            var data = new Dictionary<byte, object>
                {
                    { (byte)ParameterCode.Name, name }, 
                    { (byte)ParameterCode.Position, position },                 
                };            

            if (rotation != null)
            {
                data.Add((byte)ParameterCode.Rotation, rotation);
            }

            game.SendOperation(OperationCode.EnterWorld, data, true, OperationChannel);
        }

        
        public static void ExitWorld(Game game)
        {
            game.SendOperation(OperationCode.ExitWorld, new Dictionary<byte, object>(), true, OperationChannel);
        }

        public static void Move(Game game, string itemId, byte? itemType, float[] position, float[] rotation)
        {
            var data = new Dictionary<byte, object> { { (byte)ParameterCode.Position, position } };
            if (itemId != null)
            {
                data.Add((byte)ParameterCode.ItemId, itemId);
            }

            if (itemType.HasValue)
            {
                data.Add((byte)ParameterCode.ItemType, itemType.Value);
            }

            if (rotation != null)
            {
                data.Add((byte)ParameterCode.Rotation, rotation);
            }

            game.SendOperation(OperationCode.Move, data, true, ItemChannel);
        }

    }
}
