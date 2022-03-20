namespace IGE.TargetPractice.Game;
using System;

using IGE.Common.Graphics;

using Microsoft.Xna.Framework;

internal class TargetSprite : Sprite2D
{
  private int halfWidth;
  private int halfHeight;

  private int radius = 45;

  public TargetSprite(
    Game game,
    GraphicsDeviceManager graphics,
    string spriteName)
    : base(game, graphics, spriteName)
  {

  }

  public override void Initialize()
  {
    base.Initialize();

    ChangePosition();
  }

  public override void LoadContent()
  {
    base.LoadContent();
    halfWidth = Width / 2;
    halfHeight = Height / 2;
  }

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);
  }

  public void ChangePosition()
  {
    var posX =
      Random.Shared.Next(halfWidth, graphics.PreferredBackBufferWidth - halfWidth);

    var posY =
      Random.Shared.Next(halfHeight, graphics.PreferredBackBufferHeight - halfHeight);

    position = new Vector2(posX, posY);
  }

  public bool IsHit(CrosshairSprite crossHair)
  {
    if (!crossHair.IsPressed)
      return false;

    var distance = Vector2.Distance(position, crossHair.Position);

    if (distance <= radius)
      return true;

    return false;
  }
}
