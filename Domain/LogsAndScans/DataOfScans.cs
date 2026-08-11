using System.Diagnostics.CodeAnalysis;
using TicketScanner.Domain.MainEntity;

namespace TicketScanner.Domain.LogsAndScans;



public class DataOfScans : Entity
{
    public string PlaneName { get; private set; }
    public string AirCompanyName { get; private set; }
    public bool IsValid { get; private set; }
    [NotNull]
    public DateTime ScannedAt { get; private set; } 

   
    
    private DataOfScans(string planeName, string airCompanyName, bool isValid, DateTime createdAt)
    {
        if (string.IsNullOrWhiteSpace(planeName)) throw new ArgumentException(nameof(planeName));
        if(string.IsNullOrWhiteSpace(airCompanyName)) throw new ArgumentException(nameof(airCompanyName));
        PlaneName = planeName;
        AirCompanyName = airCompanyName;
        IsValid = isValid;
        ScannedAt = createdAt;
    }

    public static DataOfScans Create(string planeName, string AircompanyName, bool isvalid, DateTime created)
    {
        var createdAt = DateTime.Now;
        var create = new DataOfScans(planeName, AircompanyName, isvalid, createdAt);
        return create;
    }


    protected DataOfScans()
    {
        
    }
   
}