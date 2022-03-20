namespace IGE.TargetPractice.Game;

using IGE.Common.Graphics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class CrosshairSprite : Sprite2D
{
  private MouseState mState;
  private bool isPressed = false;

  public bool IsPressed => isPressed;

  public CrosshairSprite(
    Game game,
    GraphicsDeviceManager graphics,
    string spriteName)
    : base(game, graphics, spriteName)
  {
  }

  public bool Fired => isPressed;

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);

    mState = Mouse.GetState();

    position = mState.Position.ToVector2();

    if (mState.LeftButton == ButtonState.Pressed && !isPressed)
    {
      isPressed = true;
      return;
    }

    isPressed = false;
  }
}
