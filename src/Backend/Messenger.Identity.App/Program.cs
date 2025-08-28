namespace Messenger.Identity.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.AddGrpc();

        var app = builder.Build();

        app.MapGrpcService<IdentityAppService>();
        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

        app.Run();
    }
}
