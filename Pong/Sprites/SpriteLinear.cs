using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class SpriteLinear : Sprite
    {

        public float linearVelocity = 2f;


        public Input input;

        public SpriteLinear(Texture2D texture) : base(texture) { }

        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            

            Move();

            //if (_position.X > _graphics.PreferredBackBufferWidth - _texture.Width / 2)
            //    _position.X = _graphics.PreferredBackBufferWidth - _texture.Width / 2;
            //else if (_position.X < _texture.Width / 2)
            //    _position.X = _texture.Width / 2;

            //if (_position.Y > _graphics.PreferredBackBufferHeight - _texture.Height / 2)
            //    _position.Y = _graphics.PreferredBackBufferHeight - _texture.Height / 2;
            //else if (_position.Y < _texture.Height / 2)
            //    _position.Y = _texture.Height / 2;
        }

        private void Move()
        {
            if (input == null)
                return;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(input.Up))
                _position.Y -= linearVelocity;

            if (kstate.IsKeyDown(input.Down))
                _position.Y += linearVelocity;

            if (kstate.IsKeyDown(input.Left))
                _position.X -= linearVelocity;

            if (kstate.IsKeyDown(input.Right))
                _position.X += linearVelocity;

        }
    }
}
