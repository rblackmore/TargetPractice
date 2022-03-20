namespace IGE.Common.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class Sprite2D
{
  protected Texture2D texture;

  protected Vector2 position = Vector2.Zero;
  protected Vector2 origin;
  protected Color color = Color.White;
  protected Vector2 scale = Vector2.One;
  protected float rotation = 0f;

  protected readonly Game game;
  protected readonly GraphicsDeviceManager graphics;
  protected readonly string assetName;

  public Sprite2D(
    Game game,
    GraphicsDeviceManager graphics,
    string assetName)
  {
    this.game = game;
    this.graphics = graphics;
    this.assetName = assetName;
  }

  public Vector2 Position { get => position; init => position = value; }
  public Vector2 Origin { get => origin; private set => origin = value; }
  public Color Color { get => color; init => color = value; }
  public Vector2 Scale { get => scale; init => scale = value; }
  public float Rotation { get => rotation; init => rotation = value; }

  public int Width => texture.Width * (int)Scale.X;
  public int Height => texture.Height * (int)Scale.Y;

  public virtual void Initialize()
  {
  }

  public virtual void LoadContent()
  {
    texture = game.Content.Load<Texture2D>(assetName);

    CalculateAndSetOrigin();
  }

  private void CalculateAndSetOrigin()
  {
    origin = new Vector2(texture.Width / 2, texture.Height / 2);
  }

  public virtual void UnloadContent()
  {
    texture.Dispose();
  }

  public virtual void Update(GameTime gameTime)
  {

  }

  public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    spriteBatch.Draw(
      texture,
      Position,
      null,
      Color.White,
      Rotation,
      Origin,
      Scale,
      SpriteEffects.None,
      0);
  }
}
