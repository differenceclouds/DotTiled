using System.Collections.Generic;

namespace DotTiled;

public abstract class BaseLayer
{
  // Attributes
  public required uint ID { get; set; }
  public string Name { get; set; } = "";
  public string Class { get; set; } = "";
  public uint X { get; set; } = 0;
  public uint Y { get; set; } = 0;
  public float Opacity { get; set; } = 1.0f;
  public bool Visible { get; set; } = true;
  public Color? TintColor { get; set; }
  public float OffsetX { get; set; } = 0.0f;
  public float OffsetY { get; set; } = 0.0f;
  public float ParallaxX { get; set; } = 1.0f;
  public float ParallaxY { get; set; } = 1.0f;

  // Elements
  public Dictionary<string, IProperty>? Properties { get; set; }
}