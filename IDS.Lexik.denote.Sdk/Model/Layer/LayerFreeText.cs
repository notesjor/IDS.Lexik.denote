using IDS.Lexik.denote.Sdk.Model.Layer.Abstract;

namespace IDS.Lexik.denote.Sdk.Model.Layer;

public class LayerFreeText : AbstractLayer
{
  public override bool IsReadOnly { get; set; } = false;
}