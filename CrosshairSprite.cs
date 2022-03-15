namespace Tut.ShootingGallery;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class CrosshairSprite : Sprite2D
{
  private MouseState mState;
  private bool isPressed= false;

  public bool IsPressed => this.isPressed;

  public CrosshairSprite(
    Game game,
    GraphicsDeviceManager graphics,
    string spriteName)
    : base(game, graphics, spriteName)
  {
  }

  public bool Fired => this.isPressed;

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);

    this.mState = Mouse.GetState();

    this.position = this.mState.Position.ToVector2();

    if (this.mState.LeftButton == ButtonState.Pressed && !this.isPressed)
    {
      this.isPressed = true;
      return;
    }

    this.isPressed = false;
  }
}
