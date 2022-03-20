namespace IGE.Common.Stats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

public class FrameCounter
{
  private Queue<float> samples = new Queue<float>();

  private IntervalTimer timer;

  public FrameCounter()
  {
    this.timer = new IntervalTimer(TimeSpan.FromSeconds(1));
  }

  public long TotalFrames { get; set; }
  public float TotalSeconds { get; set; }
  public float AverageFramesPerSecond { get; set; }
  public float CurrentFramesPerSecond { get; set; }

  public const int MAX_SAMPLES = 100;

  /// <summary>
  /// Calculates the current Frame Rate and Average.
  /// Sould be called From the Draw Method.
  /// </summary>
  /// <param name="gameTime"></param>
  public void Update(GameTime gameTime)
  {
    this.timer.Update(gameTime);

    var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

    CurrentFramesPerSecond = 1.0f / deltaTime;

    samples.Enqueue(CurrentFramesPerSecond);

    if (this.samples.Count > MAX_SAMPLES)
      samples.Dequeue();

    if (this.timer.IsTriggered())
      AverageFramesPerSecond = samples.Average(i => i);

    TotalFrames++;
    TotalSeconds += deltaTime;
  }
}
