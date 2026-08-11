
using TicketScanner.Domain.IRepositories.LogsRepository;
using TicketScanner.Domain.LogsAndScans;            
using TicketScanner.Infrastructure;
using TicketScanner.Infrastructure.UnitOfWork.IUnitOfWork;

namespace TicketScanner.Application.Repository;

public class LogRepository(ApplicationDbContext dbContext, IUnitOfWork unitOfWork) : ILogRepository
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ApplicationDbContext _dbContext = dbContext;
    public async Task SaveLogAsync(SaveLog command,
        CancellationToken cancellationToken = default)
    {
        var logs = DataOfScans.Create(command.planeName, command.aircompany, command.isScanned, command.date);
        await _dbContext.Scans.AddAsync(logs, cancellationToken );
        await _unitOfWork.ExecuteCommitAsync(cancellationToken);
    }
}