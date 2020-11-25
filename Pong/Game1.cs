using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Pong
{
    public class Game1 : Game
    {
        //Texture2D ballTexture;
        //Vector2 ballPos;
        //float ballSpd;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<Sprite> spriteList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            
            //ballPos = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2);
            //ballSpd = 100f;
            // TODO: Add your initialization logic here

           
       

            base.Initialize();
        }

        protected override void LoadContent()
        {
            
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var ballTexture = Content.Load<Texture2D>("ball");

            spriteList = new List<Sprite>()
            {

                new Sprite(ballTexture, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2))
                {
                    input = new Input() {Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right},
                },
                new Sprite(ballTexture, new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3))
                {
                    linearVelocity = 1,
                    input = new Input() {Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D},
                },


        };
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
            foreach (var sprite in spriteList)
                sprite.Update(_graphics);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (var sprite in spriteList)
                sprite.Draw(_spriteBatch);

            //_spriteBatch.Draw(ball, null, Color.White, 0f, new Vector2(ball.getWidth() / 2, ball.getHeight() / 2), Vector2.One, SpriteEffects.None, 0f) ;
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
