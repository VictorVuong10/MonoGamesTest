using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Pong.Sprites
{
    public class SpriteRotateTarget : Sprite
    {
        public float linearVelocity = 2f;
        public float rotationVelocity = 4f;


        public Input input;

        public SpriteRotateTarget(Texture2D texture) : base(texture){}

        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            

            Move();

            foreach (var sprite in sprites)
            {
                if (sprite is Projectile)
                {
                    if(sprite.rectangle.Intersects(this.rectangle))
                    {
                        Debug.WriteLine(this._position);
                        this.isRemoved = true;
                        sprite.isRemoved = true;
                    }
                }
            }
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
