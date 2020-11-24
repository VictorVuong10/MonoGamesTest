using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Game1 : Game
    {
        //Texture2D ballTexture;
        //Vector2 ballPos;
        //float ballSpd;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Sprite ball;
        private Sprite ball2;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            ball = new Sprite(Content.Load<Texture2D>("ball"), new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2));
            //ballPos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            //ballSpd = 100f;
            // TODO: Add your initialization logic here

            ball2 = new Sprite(Content.Load<Texture2D>("ball"), new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3));
            ball2.speed = 1;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            //ballTexture = Content.Load<Texture2D>("ball");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //var kstate = Keyboard.GetState();

            //if (kstate.IsKeyDown(Keys.Up))
            //    ballPos.Y -= ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Down))
            //    ballPos.Y += ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Left))
            //    ballPos.X -= ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //if (kstate.IsKeyDown(Keys.Right))
            //    ballPos.X += ballSpd * (float)gameTime.ElapsedGameTime.TotalSeconds;

            ////if (ballPos.X > _graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            ////    ballPos.X = _graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            ////else if (ballPos.X < ballTexture.Width / 2)
            ////    ballPos.X = ballTexture.Width / 2;

            //if (ballpos.y > _graphics.preferredbackbufferheight - balltexture.height / 2)
            //    ballpos.y = _graphics.preferredbackbufferheight - balltexture.height / 2;
            //else if (ballpos.y < balltexture.height / 2)
            //    ballpos.y = balltexture.height / 2;
            ball.Update(_graphics);
            ball2.Update(_graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            ball.Draw(_spriteBatch);
            ball2.Draw(_spriteBatch);

            //_spriteBatch.Draw(ball, null, Color.White, 0f, new Vector2(ball.getWidth() / 2, ball.getHeight() / 2), Vector2.One, SpriteEffects.None, 0f) ;
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
