using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Managers;
using Pong.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Sprites
{
    public class Pink : Sprite
    {

        public float speed = 200f;

        private float scale = 1.5f;

        public Input input;

        public SpriteEffects effect = SpriteEffects.None;

        public Pink(Texture2D texture) : base(texture) { }

        public Pink(Dictionary<string, Animation> animations) :base(animations) { }
        public override void Update(GraphicsDeviceManager _graphics, GameTime gameTime, List<Sprite> sprites)
        {
            Move(gameTime);

            setAnimations();

            _animationManager.Update(gameTime);

            Position += velocity;
            //Position = Vector2.Clamp(Position, new Vector2(0, 0), new Vector2(Game1.ScreenWidth - _animations["Idle"].FrameWidth/_animations["Idle"].FrameCount, Game1.ScreenHeight - _animations["Idle"].FrameHeight + 30));
            velocity = Vector2.Zero;
        }

        private void setAnimations()
        {
            if (velocity.X > 0)
            {
                _animationManager.play(_animations["Walk"]);
                effect = SpriteEffects.None;
            }
            else if (velocity.X < 0)
            {
                _animationManager.play(_animations["Walk"]);
                effect = SpriteEffects.FlipHorizontally;
            }
            else _animationManager.play(_animations["Idle"]);
        }

        private void Move(GameTime gameTime)
        {
            if (input == null)
                return;

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(input.Up))
                velocity.Y -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(input.Down))
                velocity.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(input.Left))
                velocity.X -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(input.Right))
                velocity.X += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            if (_texture != null)
                _spriteBatch.Draw(_texture, _position, null, color, rotation, origin, Vector2.One, effect, 0f);
            else if (_animationManager != null)
                _animationManager.Draw(_spriteBatch, effect, scale);
            else throw new Exception("Well");
        }

    }
}
