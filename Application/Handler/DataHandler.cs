using TicketScanner.Application.Repository;
using TicketScanner.Domain.IRepositories.LogsRepository;


namespace TicketScanner.Application.Handler;

public class DataHandler(ILogRepository repository)

{
    private readonly ILogRepository _logRepository = repository;

    public async Task SaveDataAsync(SaveLog command,  CancellationToken token)
    {
        await _logRepository.SaveLogAsync(command, token);
    }
}