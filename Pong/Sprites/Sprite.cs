using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    abstract public class Sprite : ICloneable
    {

        private Texture2D _texture;
        public Vector2 _position;
        public Vector2 origin;
        public float rotation;

        public Sprite Parent;

        //do i need it?
        public float LifeSpan = 0f;
        public bool isRemoved = false;

        //public Input input;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public abstract void Update(GraphicsDeviceManager _graphics, GameTime gamtTime, List<Sprite> sprites);



        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, null, Color.White, rotation, origin, Vector2.One, SpriteEffects.None, 0f);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
