using System.Collections.Generic;
using DotTiled.Model.Properties;

namespace DotTiled.Model.Tilesets;

public class Wangset
{
  // Attributes
  public required string Name { get; set; }
  public string Class { get; set; } = "";
  public required int Tile { get; set; }

  // Elements
  // At most one of
  public Dictionary<string, IProperty>? Properties { get; set; }

  // Up to 254 Wang colors
  public List<WangColor>? WangColors { get; set; } = [];

  // Any number of
  public List<WangTile> WangTiles { get; set; } = [];
}