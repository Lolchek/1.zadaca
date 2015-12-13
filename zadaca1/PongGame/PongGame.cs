using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using zadatak2;
namespace PongGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class PongGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public PongGame()
        {
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferHeight = 900,
                PreferredBackBufferWidth = 500
            };
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            // Initialize new SpriteBatch object which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            // Ask graphics device about screen bounds we are using.
            var screenBounds = GraphicsDevice.Viewport.Bounds;
            // Load paddle texture using Content.Load static method
            Texture2D paddleTexture = Content.Load<Texture2D>("paddle");
            // Create bottom and top paddles and set their initial position
            PaddleBottom = new Paddle(paddleTexture);
            PaddleTop = new Paddle(paddleTexture);
            // Position both paddles with help screenBounds object
            PaddleBottom.Position = new Vector2(150, 870);//ovo sam ja stavio random vidjet cemo kasnije kako ce izgledat.
            PaddleTop.Position = new Vector2(150, 0);
            // Load ball texture
            Texture2D ballTexture = Content.Load<Texture2D>("ball");

            // Create new ball object and set its initial position
            Ball = new Ball(ballTexture);
            Ball.Position = screenBounds.Center.ToVector2();
            // Load background texture and create a new background object.
            Texture2D backgroundTexture = Content.Load<Texture2D>("background");
            Background = new Background(backgroundTexture, screenBounds.Width,
             screenBounds.Height);
            // Load sounds
            HitSound = Content.Load<SoundEffect>("hit");
            //Music = Content.Load<Song>("music");
            MediaPlayer.IsRepeating = true;
            // Start playing background music
            //MediaPlayer.Play(Music);
            SpritesForDrawList.Add(Background);
            SpritesForDrawList.Add(PaddleBottom);
            SpritesForDrawList.Add(PaddleTop);
            SpritesForDrawList.Add(Ball);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            PaddleBottom.Position.X = MathHelper.Clamp(PaddleBottom.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleBottom.Size.Width);
            PaddleTop.Position.X = MathHelper.Clamp(PaddleTop.Position.X, graphics.GraphicsDevice.Viewport.Bounds.Left, graphics.GraphicsDevice.Viewport.Bounds.Right - PaddleTop.Size.Width);
            var touchState = Keyboard.GetState();
            if (touchState.IsKeyDown(Keys.Left))
            {
                PaddleBottom.Position.X -= (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.Right))
            {
                //if ((PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds)) < 500 || (PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds)) > 0)
                PaddleBottom.Position.X += (float)(PaddleBottom.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);

            }
            if (touchState.IsKeyDown(Keys.Up))
            {
                PaddleTop.Position.X -= (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            if (touchState.IsKeyDown(Keys.Down))
            {
                PaddleTop.Position.X += (float)(PaddleTop.Speed * gameTime.ElapsedGameTime.TotalMilliseconds);
            }
            Ball.Position += Ball.Direction * (float)(gameTime.ElapsedGameTime.TotalMilliseconds * Ball.Speed);
            //Ball left and right boundaries 
            var bounds = graphics.GraphicsDevice.Viewport.Bounds;
            if (Ball.Position.X < bounds.Left || Ball.Position.X > bounds.Right -
            Ball.Size.Width)
            {
                Ball.Direction.X = -Ball.Direction.X;
                Ball.Speed = Ball.Speed * Ball.BumpSpeedIncreaseFactor;
                HitSound.Play();
            }
            // Reset ball
            if (Ball.Position.Y > bounds.Bottom || Ball.Position.Y < bounds.Top)
            {
                Ball.Position = bounds.Center.ToVector2();
                Ball.Speed = Ball.InitialSpeed;
            }
            // Collision of paddles with a ball
            if (CollisionDetector.Overlaps(Ball, PaddleTop) && Ball.Direction.Y < 0 || (CollisionDetector.Overlaps(Ball, PaddleBottom) && Ball.Direction.Y > 0))
            {
                Ball.Direction.Y = -Ball.Direction.Y;
                Ball.Speed *= Ball.BumpSpeedIncreaseFactor;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Start drawing.
            spriteBatch.Begin();
            for (int i = 0; i < SpritesForDrawList.Count; i++)
            {
                SpritesForDrawList.GetElement(i).Draw(spriteBatch);
            }
            // End drawing.
            // Send all gathered details to the graphic card in one batch.
            spriteBatch.End();

            base.Draw(gameTime);
        }
        /// <summary>
        /// Bottom paddle object
        /// </summary>
        public Paddle PaddleBottom { get; private set; }
        /// <summary>
        /// Top paddle object
        /// </summary>
        public Paddle PaddleTop { get; private set; }
        /// <summary>
        /// Ball object
        /// </summary>
        public Ball Ball { get; private set; }
        /// <summary>
        /// Background image
        /// </summary>
        public Background Background { get; private set; }
        /// <summary>
        /// Sound when ball hits an obstacle.
        /// SoundEffect is a type defined in Monogame framework
        /// </summary>
        public SoundEffect HitSound { get; private set; }
        /// <summary>
        /// Background music. Song is a type defined in Monogame framework
        /// </summary>
        public Song Music { get; private set; }
        /// <summary>
        /// Generic list that holds Sprites that should be drawn on screen
        /// </summary>
        private IGenericList<Sprite> SpritesForDrawList = new GenericList<Sprite>();

    }
}
