using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Models;
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
        public static int ScreenWidth;

        public static int ScreenHeight;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

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
            var animations = new Dictionary<string, Animation>()
            {
                {"Idle", new Animation(Content.Load<Texture2D>("Players/Pink_Monster_Idle_4"), 4) {FrameSpeed = 0.2f } },
                {"Walk", new Animation(Content.Load<Texture2D>("Players/Pink_Monster_Run_6"), 6) {FrameSpeed = 0.1f} }
            };
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var ballTexture = Content.Load<Texture2D>("ball");
            var ball2Texture = Content.Load<Texture2D>("frontball");
            var square = Content.Load<Texture2D>("Square");
            var bullet = Content.Load<Texture2D>("bullet");

            spriteList = new List<Sprite>()
            {
                new Pink(animations)
                {
                    input = new Input() {Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right},
                    _position = new Vector2(400, 240),
                    speed = 267f
                }
                //new Square(square)
                //{
                //    input = new Input() {Up = Keys.Up, Down = Keys.Down, Left = Keys.Left, Right = Keys.Right},
                //    _position = new Vector2(400, 240),
                //    color = Color.Green,
                //    speed = 267f
                //},
                //new Square(square)
                //{
                //    input = new Input() {Up = Keys.W, Down = Keys.S, Left = Keys.A, Right = Keys.D, Shoot = Keys.Space},
                //    _position = new Vector2(_graphics.PreferredBackBufferWidth / 3, _graphics.PreferredBackBufferHeight / 3),
                //    color = Color.Yellow
                //},


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
