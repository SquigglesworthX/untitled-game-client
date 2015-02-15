using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheGame.Client.Engine
{
    public abstract class Item
    {
        /// <summary>
        /// The item type.
        /// </summary>
        private readonly byte type;
        
        private readonly Game game;
        
        private readonly string id;

        public abstract bool IsMine { get; }

        public float[] Position { get; private set; }

        public float[] Rotation { get; private set; }

        public float[] PreviousPosition { get; private set; }

        public float[] PreviousRotation { get; private set; }

        public Game Game
        {
            get { return this.game; }
        }

        public string Id
        {
            get { return this.id; }
        }

        public byte Type
        {
            get { return this.type; }
        }

        public event Action<Item> Moved;

        protected Item(string id, byte type, Game game)
        {
            this.id = id;
            this.game = game;
            this.type = type;
        }

        public void SetPositions(float[] position, float[] previousPosition, float[] rotation, float[] previousRotation)
        {
            this.Position = position;
            this.PreviousPosition = previousPosition;
            this.Rotation = rotation;
            this.PreviousRotation = previousPosition;

            this.OnMoved();
        }

        private void OnMoved()
        {
            if (this.Moved != null)
            {
                this.Moved(this);
            }
        }
    }
}
