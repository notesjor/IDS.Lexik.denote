using IDS.Lexik.denote.Sdk.Model.Message.Document;
using Newtonsoft.Json;
using Tfres;

namespace IDS.Lexik.denote.Service
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var server = new Server("*", 48818, (ctx)=>ctx.Response.Send(200));
      server.AddEndpoint(HttpMethod.Post, "/getDocuments", GetDocumentList);
      server.AddEndpoint(HttpMethod.Post, "/getLayers", GetLayerList);
      server.AddEndpoint(HttpMethod.Post, "/getLayer", GetLayerInfo);
      server.AddEndpoint(HttpMethod.Post, "/setLayer", SetLayerInfo);
      server.AddEndpoint(HttpMethod.Post, "/getDocument", GetDocument);
      server.AddEndpoint(HttpMethod.Post, "/setDocument", SetDocument);
      server.AddEndpoint(HttpMethod.Post, "/getDocumentMeta", GetDocumentMeta);
      server.AddEndpoint(HttpMethod.Post, "/setDocumentMeta", SetDocumentMeta);

      while(true)
        Thread.Sleep(29000);
    }

    private static void GetDocumentMeta(HttpContext ctx)
      => ctx.Response.Send(
        File.ReadAllText($"data/{ctx.Request.PostData<GetDocumentMetaMessage>().DocumentGuid:N}/doc.meta.json"));

    private static void SetDocumentMeta(HttpContext ctx)
    {
      var data = ctx.Request.PostData<SetDocumentMetaMessage>();
      File.WriteAllText(
        $"data/{data.DocumentGuid:N}/doc.meta.json", 
        JsonConvert.SerializeObject(data.Payload));
    }

    private static void SetDocument(HttpContext ctx)
    {
      var data = ctx.Request.PostData<SetDocumentMessage>();
      File.WriteAllText(
        $"data/{data.DocumentGuid:N}/{data.LayerGuid:N}/doc.data.json",
        JsonConvert.SerializeObject(data.Payload));
    }

    private static void GetDocument(HttpContext ctx)
    {
      var data = ctx.Request.PostData<GetDocumentMessage>();
      ctx.Response.Send(
        File.ReadAllText($"data/{data.DocumentGuid:N}/{data.LayerGuid:N}/doc.data.json"));
    }

    private static void SetLayerInfo(HttpContext ctx)
    {
      
    }

    private static void GetLayerInfo(HttpContext ctx)
    {
      
    }

    private static void GetDocumentList(HttpContext ctx) 
      => ctx.Response.Send(File.ReadAllText("data/doc.index.json"));

    private static void GetLayerList(HttpContext ctx)
      => ctx.Response.Send(File.ReadAllText("data/layer.index.json"));
  }
}