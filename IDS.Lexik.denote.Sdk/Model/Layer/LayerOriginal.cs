using IDS.Lexik.denote.Sdk.Model.Layer.Abstract;

namespace IDS.Lexik.denote.Sdk.Model.Layer
{
  public class LayerOriginal : AbstractLayer
  {
    public override string Type { get; } = "ORIGINAL";
    public override bool IsReadOnly { get; set; } = true;
  }
}
