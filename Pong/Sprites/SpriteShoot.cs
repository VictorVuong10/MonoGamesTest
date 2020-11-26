using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class SpriteShoot : Sprite
    {
        public float linearVelocity = 2f;
        public float rotationVelocity = 4f;

        public Projectile projectile;

        private KeyboardState currentKey;
        private KeyboardState previousKey;
        private Vector2 direction;

        public Input input;

        public SpriteShoot(Texture2D texture) : base(texture){}

        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            if (input == null)
                return;

            previousKey = currentKey;
            currentKey = Keyboard.GetState();

                Rotate();

                Move();
  
                if(previousKey.IsKeyDown(input.Shoot) && currentKey.IsKeyUp(input.Shoot))
                Shoot(sprites);
        }

        private void Rotate()
        {
            if (currentKey.IsKeyDown(input.Left))
            {
                rotation -= MathHelper.ToRadians(rotationVelocity);
                direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            }


            else if (currentKey.IsKeyDown(input.Right))
            {
                rotation += MathHelper.ToRadians(rotationVelocity);
                direction = new Vector2((float)Math.Cos(rotation), (float)Math.Sin(rotation));
            }



        }
        private void Move()
        {

            if (currentKey.IsKeyDown(input.Up))
                _position += direction * linearVelocity;
            else if (currentKey.IsKeyDown(input.Down))
                _position -= direction * linearVelocity;
        }
        private void Shoot(List<Sprite> sprites)
        {
            var bullet = projectile.Clone() as Projectile;

            bullet.direction = this.direction;
            bullet._position = this._position;
            bullet.LifeSpan = 2f;
            bullet.Parent = this;

            sprites.Add(bullet);
        }
    }
}
