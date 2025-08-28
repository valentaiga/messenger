using Messenger.Identity.App.Grpc.Client;
using Messenger.Web.Api;
using Messenger.Web.Api.WebSockets;

namespace Messenger.Web;

public class Program
{
    public static void Main(string[] args)
    {
        // todo: add exception middleware
        var builder = WebApplication.CreateSlimBuilder(args);

        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
        });

        builder.Services.AddWebSocketHandler();
        builder.Services.AddIdentityGrpcClient("Grpc:Identity.App");

        // builder.Services.AddCors(options =>
        // {
        //     options.AddPolicy("AllowFrontend", policy =>
        //     {
        //         policy
        //             .WithOrigins("http://localhost:5000")
        //             .AllowAnyHeader()
        //             .AllowAnyMethod()
        //             .AllowCredentials();
        //     });
        // });

        var app = builder.Build();

        app.UseWebSocketHandler();

        // app.UseCors("AllowFrontend");

        app.AddIdentityEndpoints();

        app.Run();
    }
}
