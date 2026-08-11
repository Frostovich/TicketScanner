using System.Runtime.InteropServices.JavaScript;

namespace TicketScanner.Domain.IRepositories.LogsRepository;

public interface ILogRepository
{
    Task SaveLogAsync(SaveLog method, CancellationToken cancellationToken = default);
}

public record SaveLog(string planeName, string aircompany, bool isScanned,  DateTime date, CancellationToken token = default);