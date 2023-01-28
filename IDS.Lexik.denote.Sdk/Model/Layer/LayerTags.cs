using IDS.Lexik.denote.Sdk.Model.Layer.Abstract;
using Newtonsoft.Json;

namespace IDS.Lexik.denote.Sdk.Model.Layer;

public class LayerTags : AbstractLayer
{
  public override string Type { get; } = "tags";
  public override bool IsReadOnly { get; set; } = false;
  [JsonProperty("values")]
  public List<string> Values { get; set; } = new List<string>();
  

  public static LayerTags GetSttsLayer(string name = "POS")
  {
    return new LayerTags
    {
      Values = new List<string>
      {
        "NN", "NE", "ADJA", "ADJD", "CARD", "VMFIN", "VAFIN", 
        "VVFIN", "VAIMP", "VVIMP", "VVINF", "VAINF", "VMINF", 
        "VVIZU", "VVPP", "VMPP", "VAPP", "ART", "PPER", "PRF", 
        "PPOSAT", "PPOSS", "PDAT", "PDS", "PIAT", "PIDAT", 
        "PIS", "PRELAT", "PRELS", "PWAT", "PWS", "PWAV", "PAV", 
        "ADV", "KOUI", "KOUS", "KON", "KOKOM", "APPR", "APPRART", 
        "APPO", "APZR", "PTKZU", "PTKNEG", "PTKVZ", "PTKA", "PTKANT", 
        "ITJ", "TRUNC", "XY", "FM", "$,", "$.", "$("
      }, IsReadOnly = false
    };
  }
}