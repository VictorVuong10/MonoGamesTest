using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Sprites;
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
            var ball2Texture = Content.Load<Texture2D>("frontball");
            var bullet = Content.Load<Texture2D>("bullet");

            spriteList = new List<Sprite>()
            {

                //new SpriteLinear(ballTexture)
                //{
                //    input = new Input() {Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right},
                //     origin = new Vector2(ball2Texture.Width / 2, ball2Texture.Width / 2),
                //    _position = new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2),
                //},
                new SpriteShoot(ball2Texture)
                {
                    linearVelocity = 1f,
                    input = new Input() {Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D, Shoot = Keys.Space},
                    origin = new Vector2(ball2Texture.Width / 2, ball2Texture.Width / 2),
                    _position = new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3),
                    projectile = new Projectile(bullet),
                },


        };
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in spriteList.ToArray())
                sprite.Update(_graphics, gameTime, spriteList);

            postUpdate();

            base.Update(gameTime);
        }

        private void postUpdate()
        {
            for (int i = 0; i < spriteList.Count; i++)
            {
                if (spriteList[i].isRemoved)
                {
                    spriteList.RemoveAt(i);
                    i--;
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            foreach (var sprite in spriteList)
                sprite.Draw(_spriteBatch);

            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
