using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        Texture2D ballTexture;
        Vector2 ballPos;
        float ballSpd;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ballPos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            ballSpd = 100f;
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                ballPos.Y -= ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                ballPos.Y += ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                ballPos.X -= ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                ballPos.X += ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (ballPos.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
                ballPos.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            else if (ballPos.X < ballTexture.Width / 2)
                ballPos.X = ballTexture.Width / 2;

            if (ballPos.Y > _graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
                ballPos.Y = _graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            else if (ballPos.Y < ballTexture.Height / 2)
                ballPos.Y = ballTexture.Height / 2;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(ballTexture, ballPos, null, Color.White, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
