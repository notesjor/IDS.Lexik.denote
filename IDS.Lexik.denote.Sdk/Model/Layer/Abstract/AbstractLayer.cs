using Newtonsoft.Json;

namespace IDS.Lexik.denote.Sdk.Model.Layer.Abstract
{
  public abstract class AbstractLayer
  {
    [JsonProperty("type")]
    public abstract string Type { get; }
    [JsonProperty("position")]
    public int Position { get; set; } = -1;
    [JsonProperty("isReadOnly")]
    public abstract bool IsReadOnly { get; set; }
    [JsonProperty("descriptionShort")]
    public string DescriptionShort { get; set; }
    [JsonProperty("descriptionLong")]
    public string DescriptionLong { get; set; }
    [JsonProperty("color")]
    public string Color { get; set; }
  }
}
