using MassTransit;
using rabbit_mq_pub_sub.Bus;

namespace rabbit_mq_pub_sub.Extensions;

internal static class AppExtensions
{
    public static void AddRabbitMQService(this IServiceCollection services)
    {

        services.AddTransient<IPublishBus, PublishBus>();
        
        services.AddMassTransit(busConfigurator =>
        {
            busConfigurator.AddConsumer<RelatorioSolicitadoEventConsumer>();

            busConfigurator.UsingRabbitMq((context, configurator) => 
            {
                configurator.Host(new Uri("amqp://localhost:5672"), host => 
                {
                    host.Username("guest");
                    host.Password("guest");
                });

                configurator.ConfigureEndpoints(context);
            });
        });
    }
}