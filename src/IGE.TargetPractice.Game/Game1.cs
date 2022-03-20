namespace IGE.TargetPractice.Game;

using IGE.Common;
using IGE.Common.Stats;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Game1 : Game
{
  private GraphicsDeviceManager graphics;
  private SpriteBatch spriteBatch;

  TargetSprite target;
  CrosshairSprite crosshair;

  Texture2D backgroundSprite;
  SpriteFont gameFont;

  IntervalTimer timer;

  FrameRateStat fpsCounter;

  int score = 0;

  public Game1()
    : base()
  {
    this.graphics = new GraphicsDeviceManager(this);
    this.Content.RootDirectory = "Content";
    this.IsFixedTimeStep = false;
    this.IsMouseVisible = false;

  }

  protected override void Initialize()
  {
    this.fpsCounter = new FrameRateStat(1, this.gameFont);
    this.timer = new IntervalTimer(TimeSpan.FromSeconds(5));
    target = new TargetSprite(this, this.graphics, "target");
    crosshair = new CrosshairSprite(this, this.graphics, "crosshairs");

    target.Initialize();
    crosshair.Initialize();

    base.Initialize();
  }

  protected override void LoadContent()
  {
    this.spriteBatch = new SpriteBatch(this.GraphicsDevice);

    target.LoadContent();
    crosshair.LoadContent();

    backgroundSprite = Content.Load<Texture2D>("sky");
    gameFont = Content.Load<SpriteFont>("galleryFont");

    this.fpsCounter = new FrameRateStat(1, this.gameFont);
    this.timer = new IntervalTimer(TimeSpan.FromSeconds(5));

    base.LoadContent();
  }

  protected override void UnloadContent()
  {
    base.UnloadContent();
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
      || Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    this.fpsCounter.Update(gameTime);
    this.timer.Update(gameTime);

    target.Update(gameTime);
    crosshair.Update(gameTime);

    if (target.IsHit(crosshair) || timer.IsTriggered())
    {
      score++;
      target.ChangePosition();
    }

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    this.GraphicsDevice.Clear(Color.CornflowerBlue);

    this.spriteBatch.Begin();

    this.spriteBatch.Draw(backgroundSprite, new Vector2(0,0), Color.White);


    this.target.Draw(gameTime, this.spriteBatch);

    this.crosshair.Draw(gameTime, this.spriteBatch);

    this.spriteBatch.DrawString(
      this.gameFont,
      $"Score: {score}",
      new Vector2(30,30),
      Color.White);

    this.fpsCounter.Draw(gameTime, spriteBatch);

    this.spriteBatch.End();

    base.Draw(gameTime);
  }
}
