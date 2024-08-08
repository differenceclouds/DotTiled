using System;
using System.IO;
using System.Text;
using System.Text.Json;

namespace DotTiled;

public class TmjMapReader : IMapReader
{
  private string _jsonString;
  private bool disposedValue;

  public TmjMapReader(string jsonString)
  {
    _jsonString = jsonString ?? throw new ArgumentNullException(nameof(jsonString));
  }

  public Map ReadMap()
  {
    var jsonDoc = JsonDocument.Parse(_jsonString);
    var rootElement = jsonDoc.RootElement;
    return Tmj.ReadMap(rootElement);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (!disposedValue)
    {
      if (disposing)
      {
        // TODO: dispose managed state (managed objects)
      }

      // TODO: free unmanaged resources (unmanaged objects) and override finalizer
      // TODO: set large fields to null
      disposedValue = true;
    }
  }

  // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
  // ~TmjMapReader()
  // {
  //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
  //     Dispose(disposing: false);
  // }

  public void Dispose()
  {
    // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    Dispose(disposing: true);
    System.GC.SuppressFinalize(this);
  }
}
