using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class Sprite : ICloneable
    {

        protected Texture2D _texture;
        public Vector2 _position;
        public Vector2 velocity;
        public Vector2 origin;
        public float rotation;
        public Color color =  Color.White;

        public Sprite Parent;

        //do i need it?
        public float LifeSpan = 0f;
        public bool isRemoved = false;

        //public Input input;
        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        public virtual void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites) { }



        public virtual void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, null, color, rotation, origin, Vector2.One, SpriteEffects.None, 0f);
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #region Collision
        protected bool isTouchingLeft(Sprite sprite)
        {
            return this.rectangle.Right + this.velocity.X > sprite.rectangle.Left &&
                   this.rectangle.Left < sprite.rectangle.Left &&
                   this.rectangle.Top < sprite.rectangle.Bottom &&
                   this.rectangle.Bottom > sprite.rectangle.Top;
        }

        protected bool isTouchingRight(Sprite sprite)
        {
            return this.rectangle.Left + this.velocity.X < sprite.rectangle.Right &&
                   this.rectangle.Right > sprite.rectangle.Right &&
                   this.rectangle.Top < sprite.rectangle.Bottom &&
                   this.rectangle.Bottom > sprite.rectangle.Top;
        }

        protected bool isTouchingBottom(Sprite sprite)
        {
            return this.rectangle.Top + this.velocity.Y < sprite.rectangle.Bottom &&
                   this.rectangle.Bottom > sprite.rectangle.Bottom &&
                   this.rectangle.Right > sprite.rectangle.Left &&
                   this.rectangle.Left < sprite.rectangle.Right;
        }

        protected bool isTouchingTop(Sprite sprite)
        {
            return this.rectangle.Bottom + this.velocity.Y > sprite.rectangle.Top &&
                   this.rectangle.Top < sprite.rectangle.Top &&
                   this.rectangle.Right > sprite.rectangle.Left &&
                   this.rectangle.Left < sprite.rectangle.Right;
        }

        #endregion
    }
}
