namespace IGE.Common;
using System;

using Microsoft.Xna.Framework;

public sealed class IntervalTimer
{
  private TimeSpan interval;

  private TimeSpan current = TimeSpan.Zero;

  private bool isTriggered;

  public IntervalTimer(TimeSpan interval)
  {
    this.interval = interval;
  }

  public bool IsTriggered()
  {
    if (this.isTriggered)
    {
      this.isTriggered = false;
      return true;
    }

    return false;
  }

  public void Update(GameTime gameTime)
  {
    this.current += gameTime.ElapsedGameTime;

    if (this.current >= this.interval)
    {
      this.isTriggered = true;
      this.current = TimeSpan.Zero;
    }
  }
}
