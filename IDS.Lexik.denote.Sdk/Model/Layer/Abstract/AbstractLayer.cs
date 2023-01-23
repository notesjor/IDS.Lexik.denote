namespace IDS.Lexik.denote.Sdk.Model.Layer.Abstract
{
  public abstract class AbstractLayer
  {
    public Guid Guid { get; set; }
    public abstract bool IsReadOnly { get; set; }
    public string DescriptionShort { get; set; }
    public string DescriptionLong { get; set; }
    public string Color { get; set; }
  }
}
