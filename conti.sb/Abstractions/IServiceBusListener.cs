namespace conti.sb;

public interface IServiceBusListener
{
    Task Listen(CancellationToken cancellationToken);
}
