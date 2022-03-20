namespace IGE.TargetPractice.Game;
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

  int score = 0;

  public Game1()
    : base()
  {
    this.graphics = new GraphicsDeviceManager(this);
    this.Content.RootDirectory = "Content";
    this.IsFixedTimeStep = true;
    this.IsMouseVisible = false;

  }

  protected override void Initialize()
  {
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

    target.Update(gameTime);
    crosshair.Update(gameTime);

    if (target.IsHit(crosshair))
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
      Vector2.Zero,
      Color.White);

    this.spriteBatch.End();

    base.Draw(gameTime);
  }
}
