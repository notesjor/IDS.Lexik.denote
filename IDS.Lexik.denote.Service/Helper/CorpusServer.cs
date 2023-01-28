using IDS.Lexik.denote.Sdk.Helper;
using IDS.Lexik.denote.Sdk.Model.Layer;
using Newtonsoft.Json;

namespace IDS.Lexik.denote.Service.Helper;

public static class CorpusServer
{
  public static bool IsReady()
  {
    if (!Directory.Exists("data"))
    {
      Directory.CreateDirectory("data");
      Console.WriteLine("No data-directory found. Directory created but empty - please insert corpus.");
      return false;
    }

    if (!File.Exists("data/doc.index.json"))
    {
      Console.WriteLine("No data/doc.index.json found. please insert corpus in data-directory.");
      return false;
    }

    if (!Directory.Exists("data/layer"))
    {
      Directory.CreateDirectory("data/layer");

      var layers = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("data/layer.index.json"));
      foreach (var layer in layers)
      {
        var guid = Guid.Parse(layer.Key);
        switch (layer.Value)
        {
          case "Wort":
            File.WriteAllText($"data/layer/{layer.Key}.json", SerializationHelper.Serialize(new LayerFreeText()));
            break;
          case "Lemma":
            File.WriteAllText($"data/layer/{layer.Key}.json", SerializationHelper.Serialize(new LayerFreeText()));
            break;
          case "POS":
            File.WriteAllText($"data/layer/{layer.Key}.json", SerializationHelper.Serialize(LayerTags.GetSttsLayer()));
            break;
          case "TAG":
            File.WriteAllText($"data/layer/{layer.Key}.json", SerializationHelper.Serialize(new LayerTags()));
            break;
          case "ORIGINAL":
            File.WriteAllText($"data/layer/{layer.Key}.json", SerializationHelper.Serialize(new LayerOriginal()));
            break;
        }
      }
    }

    return true;
  }
}