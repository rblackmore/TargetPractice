namespace Tut.ShootingGallery;

using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


// TODO: Add Collection of Targets, Spawn new target after X seconds
// TODO: Track Count of Targets, if count reaches Y, game over, if count reachers 0 Win.
// TODO: Change Score to track Number of Targets
// TODO: Change Number colour to reflect % of Y (Green low, Orange Mid, Red High)


public class Game1 : Game
{
  private GraphicsDeviceManager _graphics;
  private SpriteBatch _spriteBatch;

  TargetSprite target;
  CrosshairSprite crosshair;

  Texture2D backgroundSprite;
  SpriteFont gameFont;

  int score = 0;

  public Game1()
  {
    _graphics = new GraphicsDeviceManager(this);
    Content.RootDirectory = "Content";
    IsMouseVisible = false;
  }

  protected override void Initialize()
  {
    this.target = new TargetSprite(this, this._graphics, "target");
    this.crosshair = new CrosshairSprite(this, this._graphics, "crosshairs");

    this.target.Initialize();
    this.crosshair.Initialize();

    base.Initialize();
  }

  protected override void LoadContent()
  {
    _spriteBatch = new SpriteBatch(GraphicsDevice);

    this.target.LoadContent();
    this.crosshair.LoadContent();

    this.backgroundSprite = this.Content.Load<Texture2D>("sky");
    this.gameFont = this.Content.Load<SpriteFont>("galleryFont");
  }

  protected override void Update(GameTime gameTime)
  {
    if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
      || Keyboard.GetState().IsKeyDown(Keys.Escape))
      Exit();

    this.target.Update(gameTime);
    this.crosshair.Update(gameTime);

    if (this.target.IsHit(this.crosshair))
    {
      this.score++;
      this.target.ChangePosition();
    }

    base.Update(gameTime);
  }

  protected override void Draw(GameTime gameTime)
  {
    GraphicsDevice.Clear(Color.CornflowerBlue);

    this._spriteBatch.Begin();

    this._spriteBatch.Draw(backgroundSprite, new Vector2(0, 0), Color.White);
    
    this.target.Draw(gameTime, this._spriteBatch);

    this.crosshair.Draw(gameTime, this._spriteBatch);

    this._spriteBatch.DrawString(
      gameFont,
      string.Format("Score: {0}", this.score),
      new Vector2(100, 100),
      Color.White);


    this._spriteBatch.End();

    base.Draw(gameTime);
  }
}
