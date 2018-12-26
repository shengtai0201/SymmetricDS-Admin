namespace SymmetricDS.Admin.ConsoleApp
{
    public interface IConfiguration
    {
        string EngineName { get; }
        string DbDriver { get; }
        string DbUrl { get; }
        string DbUser { get; }
        string DbPassword { get; }
        string RegistrationUrl { get; }
        string SyncUrl { get; }
        string GroupId { get; }
        string ExternalId { get; }
        int JobPurgePeriodTimeMs { get; }
        int JobRoutingPeriodTimeMs { get; }
        int JobPushPeriodTimeMs { get; }
        int JobPullPeriodTimeMs { get; }
        bool InitialLoadCreateFirst { get; }
    }
}