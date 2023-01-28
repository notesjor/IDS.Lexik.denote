using Newtonsoft.Json;

namespace IDS.Lexik.denote.Sdk.Helper
{
  public static class SerializationHelper
  {
    private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings
    {
      TypeNameHandling = TypeNameHandling.None,
      Formatting = Formatting.Indented,
      NullValueHandling = NullValueHandling.Ignore,
      DefaultValueHandling = DefaultValueHandling.Ignore,
      MissingMemberHandling = MissingMemberHandling.Ignore,
      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    };

    public static string Serialize(object obj) 
      => JsonConvert.SerializeObject(obj, _settings);

    public static T Deserialize<T>(string obj) 
      => JsonConvert.DeserializeObject<T>(obj, _settings);
  }
}
