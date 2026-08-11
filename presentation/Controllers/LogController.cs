using TicketScanner.Domain.IRepositories.LogsRepository;
using TicketScanner.presentation.DTO;
namespace TicketScanner.presentation.Controllers;
using Microsoft.AspNetCore.Mvc;
using Application.Handler;

[Route("api/scan")]
public class LogController(ILogger<LogController> logger, DataHandler handler ) : Controller
{
    private readonly ILogger<LogController> _logger = logger;
    private readonly DataHandler _dataHandler =  handler;

    [HttpPost]
    public async Task<IActionResult> CreateLog([FromBody]LogDTO dto, CancellationToken token)
    {
        try
        {
            var logType = new SaveLog(dto.plane, dto.aircompanyName, dto.IsScanned, dto.time, token);
            await _dataHandler.SaveDataAsync(logType, token);
            return Ok();
        }
        catch(Exception exception)
        {
            _logger.LogInformation(exception.Message);
            throw;
        }
    } 
    
}