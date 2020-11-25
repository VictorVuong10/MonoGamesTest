using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    public class Sprite
    {

        private Texture2D _texture;
        public Vector2 _position;
        public float linearVelocity = 2f;


        public Input input;

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }
        public Sprite(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public void Update(GraphicsDeviceManager _graphics)
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



        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Width / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
