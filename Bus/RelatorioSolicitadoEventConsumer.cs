using MassTransit;
using rabbit_mq_pub_sub.Relatorios;

namespace rabbit_mq_pub_sub.Bus;

internal sealed class RelatorioSolicitadoEventConsumer: IConsumer<RelatorioSolicitadoEvent>
{
    public readonly ILogger<RelatorioSolicitadoEventConsumer> _logger;

    public RelatorioSolicitadoEventConsumer(ILogger<RelatorioSolicitadoEventConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<RelatorioSolicitadoEvent> context)
    {
        var message = context.Message;
        _logger.LogInformation("Processando Relatório Id:{Id}, Nome:{Nome}", message.Id, message.Nome);

        await Task.Delay(10000);

        var relatorio = Lista.Relatorios.FirstOrDefault(x => x.Id == message.Id);

        if (relatorio != null)
        {
            relatorio.Status = "Completado!";
            relatorio.ProcessedTime = DateTime.Now;
        }

        _logger.LogInformation("Relatório Processado Id:{Id}, Nome:{Nome}", message.Id, message.Nome);
    }
}