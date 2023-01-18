namespace IDS.Lexik.denote.Sdk.Model.Layer.Abstract
{
  public abstract class AbstractLayer
  {
    public Guid Guid { get; set; }
    public string Name { get; set; }
    public abstract bool IsReadOnly { get; set; }
    public string Source { get; set; }
  }
}
