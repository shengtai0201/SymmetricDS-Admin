namespace SymmetricDS.Admin.ConsoleApp
{
    public interface INode
    {
        int ProjectId { get; }
        string ExternalId { get; }
        string GroupId { get; }
        string Password { get; }
        int Version { get; }

        IMaster MasterNode { get; }

        bool CopyTo(string path);

        bool Write(string path);

        void RunOnlyOnce(string path, IInitializationService initialization);
    }
}