namespace IDS.Lexik.denote.Sdk.Model.Message.Document;

public class SetDocumentMetaMessage
{
  public Guid DocumentGuid { get; set; }
  public Dictionary<string, string> Payload { get; set; } = new();
}