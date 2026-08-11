namespace TicketScanner.presentation.DTO;

public record LogDTO(string plane, string aircompanyName, bool IsScanned, DateTime time, CancellationToken token);