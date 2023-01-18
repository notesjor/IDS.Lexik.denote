using IDS.Lexik.denote.Sdk.Model.Layer.Abstract;

namespace IDS.Lexik.denote.Sdk.Model.Layer;

public class LayerTags : AbstractLayer
{
  public override bool IsReadOnly { get; set; } = false;
  public List<string> Values { get; set; } = new List<string>();
}