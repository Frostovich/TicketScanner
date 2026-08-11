namespace TicketScanner.Infrastructure.UnitOfWork.IUnitOfWork;

public interface IUnitOfWork
{
     Task<int> ExecuteCommitAsync(CancellationToken cancellationToken = default);
}