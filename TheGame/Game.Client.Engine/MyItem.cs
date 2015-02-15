using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Client.Engine
{
    public class MyItem : Item
    {
        public override bool IsMine
        {
            get { return true; }
        }

        public MyItem(string id, byte type, Game game, string text)
            : base(id, type, game)
        {
        }

        public void EnterWorld()
        {            
            var position = new float[] { 0, 0 };                
            this.SetPositions(position, position, null, null);            
            Operations.EnterWorld(this.Game, this.Id, this.Position, this.Rotation);
        }

        public bool MoveAbsolute(float[] newPosition, float[] rotation)
        {
            // Clamp

            this.SetPositions(newPosition, this.Position, rotation, this.Rotation);
            Operations.Move(this.Game, this.Id, this.Type, newPosition, rotation);
            return true;
        }
       
        public bool MoveRelative(float[] offset, float[] rotation)
        {
            return this.MoveAbsolute(new[] { this.Position[0] + offset[0], this.Position[1] + offset[1] }, rotation);
        }

    }
}
