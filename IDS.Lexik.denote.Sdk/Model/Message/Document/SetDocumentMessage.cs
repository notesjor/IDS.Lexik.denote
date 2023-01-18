namespace IDS.Lexik.denote.Sdk.Model.Message.Document;

public class SetDocumentMessage
{
  public Guid DocumentGuid { get; set; }
  public Guid LayerGuid { get; set; }
  public string[][] Payload { get; set; } = Array.Empty<string[]>();
}