namespace TicketScanner.Infrastructure.UnitOfWork;


public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork.IUnitOfWork
{
    private readonly ApplicationDbContext _context = dbContext;
    
    public async Task<int> ExecuteCommitAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}