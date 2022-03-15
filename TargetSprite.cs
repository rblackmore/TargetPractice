namespace Tut.ShootingGallery;
using System;

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

    this.ChangePosition();
  }

  public override void LoadContent()
  {
    base.LoadContent();
    this.halfWidth = this.Width / 2;
    this.halfHeight = this.Height / 2;
  }

  public override void Update(GameTime gameTime)
  {
    base.Update(gameTime);
  }

  public void ChangePosition()
  {
    var posX = 
      Random.Shared.Next(this.halfWidth, this.graphics.PreferredBackBufferWidth - this.halfWidth);

    var posY = 
      Random.Shared.Next(this.halfHeight, this.graphics.PreferredBackBufferHeight - this.halfHeight);

    this.position = new Vector2(posX, posY);
  }

  public bool IsHit(CrosshairSprite crossHair)
  {
    if (!crossHair.IsPressed)
      return false;

    var distance = Vector2.Distance(this.position, crossHair.Position);

    if (distance <= this.radius)
      return true;

    return false;
  }
}
