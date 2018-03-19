namespace DutyFramework.Interfaces
{
    public interface IDutyConnection
    {
        IDuty DutyA { get; set; }
        IDuty DutyB { get; set; }
        ConnectionDirection Direction { get; set; }
        string Description { get; set; }
    }

    public enum ConnectionDirection
    {
        Neutral = 1,
        BLogicallyFollowsA = 2,
        BChronologicallyFollowsB = 4,
        BNeedsAFinished = 8
    }
}