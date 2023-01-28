using IDS.Lexik.denote.Sdk.Model.Layer.Abstract;

namespace IDS.Lexik.denote.Sdk.Model.Layer;

public class LayerFreeText : AbstractLayer
{
  public override string Type { get; } = "text";
  public override bool IsReadOnly { get; set; } = false;
}