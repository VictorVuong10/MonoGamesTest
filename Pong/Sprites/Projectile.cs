using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class Projectile : Sprite
    {

        private float timer = 0f;
        private float linearVelocity = 2f;
        public Vector2 direction;


        public Projectile(Texture2D texture) : base(texture) { }


        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > LifeSpan)
                isRemoved = true;

            _position += direction * linearVelocity;
        }
    }
}
