namespace IGE.Common.Stats;

using System.Diagnostics;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public abstract class StatElement<T>
{
  private IntervalTimer timer;
  private SpriteFont font;
  private string prefix;
  protected T value;

  public StatElement(int updateSeconds, SpriteFont font, string prefix)
  {
    this.timer = new IntervalTimer(TimeSpan.FromSeconds(updateSeconds));
    this.font = font;
    this.prefix = prefix;
  }

  public virtual void Update(GameTime gameTime)
  {
    this.timer.Update(gameTime);
    
    if (this.timer.IsTriggered())
      this.Calculate(gameTime);
  }

  public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
  {
    spriteBatch.DrawString(this.font, $"{prefix}: {value.ToString()}", Vector2.Zero, Color.White);
  }

  protected abstract void Calculate(GameTime gameTime);
}
