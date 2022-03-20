namespace IGE.Common.Stats;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class FrameRateStat : StatElement<int>
{
  public FrameRateStat(int updateSeconds, SpriteFont font) 
    : base(updateSeconds, font, "FPS")
  {
  }

  protected override void Calculate(GameTime gameTime)
  {
    this.value = 1000 / gameTime.ElapsedGameTime.Milliseconds;
  }
}
