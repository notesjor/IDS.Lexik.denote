using System.Net;
using IDS.Lexik.denote.Service.Helper;
using Newtonsoft.Json;
using Tfres;

namespace IDS.Lexik.denote.Service
{
  internal class Program
  {
    static void Main(string[] args)
    {
      if (!CorpusServer.IsReady())
        return;

      var server = new Server("*", 48818, (ctx) => ctx.Response.Send(200));
      server.AddEndpoint(HttpMethod.Get, "/document", GetDocument);
      server.AddEndpoint(HttpMethod.Post, "/document", SetDocument);
      server.AddEndpoint(HttpMethod.Get, "/layer", GetLayer);
      server.AddEndpoint(HttpMethod.Post, "/layer", SetLayer);
      server.AddEndpoint(HttpMethod.Get, "/meta", GetDocumentMeta);
      server.AddEndpoint(HttpMethod.Post, "/meta", SetDocumentMeta);

      while (true)
        Thread.Sleep(29000);
    }

    private static void GetDocument(HttpContext ctx)
    {
      var data = ctx.Request.GetData();

      switch (data.Count)
      {
        // GET ohne Parameter
        case 0:
          ctx.Response.Send(File.ReadAllText("data/doc.index.json"));
          return;
        // GET mit Parameter Document
        case 1:
          {
            var document = Guid.Parse(data["id"]);

            var res = new Dictionary<string, string[][]>();
            var files = Directory.GetFiles($"data/{document:N}/", "doc.data.json", SearchOption.AllDirectories);
            foreach(var file in files)
            {
              var layer = Path.GetFileName(Path.GetDirectoryName(file));
              var content = JsonConvert.DeserializeObject<string[][]>(File.ReadAllText(file));
              res.Add(layer, content);
            }

            ctx.Response.Send(res);
            return;
          }
        default:
          ctx.Response.Send(HttpStatusCode.BadRequest);
          break;
      }
    }

    private static void SetDocument(HttpContext ctx)
    {
      var data = ctx.Request.GetData();
      var document = Guid.Parse(data["id"]);

      var content = JsonConvert.DeserializeObject<Dictionary<string, string[][]>>(ctx.Request.PostDataAsString);
      if(content == null)
      {
        ctx.Response.Send(HttpStatusCode.BadRequest);
        return;
      }

      foreach (var layer in content)
      {
        var path = $"data/{document:N}/{layer.Key}";
        if (!Directory.Exists(path))
          Directory.CreateDirectory(path);

        File.WriteAllText($"{path}/doc.data.json", JsonConvert.SerializeObject(layer.Value));
      }

      ctx.Response.Send(HttpStatusCode.OK);
    }

    private static void GetLayer(HttpContext ctx)
    {
      var data = ctx.Request.GetData();

      switch (data.Count)
      {
        // GET ohne Parameter
        case 0:
          ctx.Response.Send(File.ReadAllText("data/layer.index.json"));
          return;
        // GET mit Parameter Layer
        case 1:
          {
            var layer = Guid.Parse(data["id"]);

            ctx.Response.Send(File.ReadAllText($"data/layer/{layer:N}.json"));
            return;
          }
        default:
          ctx.Response.Send(HttpStatusCode.BadRequest);
          break;
      }
    }

    private static void SetLayer(HttpContext ctx)
    {
      var data = ctx.Request.GetData();
      var layer = Guid.Parse(data["id"]);

      File.WriteAllText(
        $"data/layer/{layer:N}.json",
        JsonConvert.SerializeObject(ctx.Request.PostDataAsString));
      
      ctx.Response.Send(HttpStatusCode.OK);
    }

    private static void GetDocumentMeta(HttpContext ctx)
    {
      var data = ctx.Request.GetData();

      switch (data.Count)
      {
        // POST mit Parameter Document
        case 1:
          {
            var document = Guid.Parse(data["id"]);

            ctx.Response.Send(File.ReadAllText($"data/{document:N}/doc.meta.json"));
            return;
          }
        default:
          ctx.Response.Send(HttpStatusCode.BadRequest);
          break;
      }
    }

    private static void SetDocumentMeta(HttpContext ctx)
    {
      var data = ctx.Request.GetData();
      var document = Guid.Parse(data["id"]);

      File.WriteAllText(
        $"data/{document:N}/doc.meta.json",
        ctx.Request.PostDataAsString);

      ctx.Response.Send(HttpStatusCode.OK);
    }
  }
}