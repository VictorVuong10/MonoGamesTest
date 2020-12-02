using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class Square : Sprite
    {
        public float speed = 100f;


        public Input input;

        public Square(Texture2D texture) : base(texture) { }

        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            Move(gameTime);

            foreach(var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if (this.velocity.X > 0 && this.isTouchingLeft(sprite)) {
                    this.velocity.X = 0;
                    this._position.X = sprite.rectangle.Left - this._texture.Width;
                } else if (this.velocity.X < 0 && this.isTouchingRight(sprite))
                {
                    this.velocity.X = 0;
                    this._position.X = sprite.rectangle.Right;
                }

                if (this.velocity.Y > 0 && this.isTouchingTop(sprite)) {
                    this.velocity.Y = 0;
                    this._position.Y = sprite.rectangle.Top - this._texture.Height;
                }
                else if (this.velocity.Y < 0 && this.isTouchingBottom(sprite))
                {
                    this.velocity.Y = 0;
                    this._position.Y = sprite.rectangle.Bottom;
                }


            }

            _position += velocity;
            velocity = Vector2.Zero;
        }

        private void Move(GameTime gameTime)
        {
            if (input == null)
            {
                throw new Exception("need to set input");
            }

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(input.Left))
                velocity.X = -speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kstate.IsKeyDown(input.Right))
                velocity.X = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(input.Up))
                velocity.Y = -speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            else if (kstate.IsKeyDown(input.Down))
                velocity.Y = speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }
    }
}
