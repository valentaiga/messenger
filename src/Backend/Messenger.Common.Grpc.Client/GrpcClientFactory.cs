using System.Collections.Concurrent;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace Messenger.Common.Grpc.Client;

internal sealed class GrpcClientFactory : IDisposable
{
    private readonly ConcurrentDictionary<string, GrpcChannel> _channels = new(concurrencyLevel: 2, capacity: 4);

    public TGrpcService Get<TGrpcService>(string endpoint) where TGrpcService : class
    {
        var channel = GetChannel(endpoint);
        return channel.CreateGrpcService<TGrpcService>(); // заменить потому что не nativeAOT friendly
    }

    private GrpcChannel GetChannel(string endpoint) =>
        _channels.GetOrAdd(endpoint, s => GrpcChannel.ForAddress(s, new GrpcChannelOptions
        {
            HttpHandler = new SocketsHttpHandler // for best performance
            {
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                EnableMultipleHttp2Connections = true
            }
        }));

    public void Dispose()
    {
        var channels = _channels.Values;
        foreach (var channel in channels)
            channel.Dispose();
    }
}
