using MassTransit;

namespace rabbit_mq_pub_sub.Bus;

internal interface IPublishBus
{
    Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class;
}

internal class PublishBus : IPublishBus
{
    private readonly IPublishEndpoint _busEndpoint;

    public PublishBus(IPublishEndpoint publish)
    {
        _busEndpoint = publish;
    }
    public Task PublishAsync<T>(T message, CancellationToken ct = default) where T : class
    {
        return _busEndpoint.Publish(message, ct);
    }
}