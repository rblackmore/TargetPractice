namespace IGE.Common.Stats;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FrameRateStat : StatElement<int>
{
  private FrameCounter frameCounter;

  public FrameRateStat(Game game, int updateSeconds, string fontName) 
    : base(game, updateSeconds, fontName, "FPS")
  {
    this.frameCounter = new FrameCounter();
  }

  public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    this.frameCounter.Update(gameTime);
    spriteBatch.DrawString(this.font, $"{prefix}: {this.frameCounter.AverageFramesPerSecond}", Vector2.Zero, Color.White);
  }

  protected override void Calculate(GameTime gameTime)
  {
    //this.value = 1000 / gameTime.ElapsedGameTime.Milliseconds;
  }
}
