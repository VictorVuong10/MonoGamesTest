using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong
{
    class Sprite
    {

        private Texture2D _texture;
        public Vector2 _position;
        public float speed = 2;

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
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                _position.Y -= speed;

            if (kstate.IsKeyDown(Keys.Down))
                _position.Y += speed;

            if (kstate.IsKeyDown(Keys.Left))
                _position.X -= speed;

            if (kstate.IsKeyDown(Keys.Right))
                _position.X += speed;

            if (_position.X > _graphics.PreferredBackBufferWidth - _texture.Width / 2)
                _position.X = _graphics.PreferredBackBufferWidth - _texture.Width / 2;
            else if (_position.X < _texture.Width / 2)
                _position.X = _texture.Width / 2;

            if (_position.Y > _graphics.PreferredBackBufferHeight - _texture.Height / 2)
                _position.Y = _graphics.PreferredBackBufferHeight - _texture.Height / 2;
            else if (_position.Y < _texture.Height / 2)
                _position.Y = _texture.Height / 2;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(_texture, _position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Width / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
