using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class SpriteRotate : Sprite
    {
        public float linearVelocity = 2f;
        public float rotationVelocity = 4f;


        public Input input;

        public SpriteRotate(Texture2D texture) : base(texture){}

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

            if (kstate.IsKeyDown(input.Left))
                rotation -= MathHelper.ToRadians(rotationVelocity);
            else if (kstate.IsKeyDown(input.Right))
                rotation += MathHelper.ToRadians(rotationVelocity);

            var direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));

            if (kstate.IsKeyDown(input.Up))
                _position += direction * linearVelocity;
            else if (kstate.IsKeyDown(input.Down))
                _position -= direction * linearVelocity;
        }
    }
}
