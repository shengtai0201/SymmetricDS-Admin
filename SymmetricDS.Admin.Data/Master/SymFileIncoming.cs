namespace SymmetricDS.Admin.Master
{
    public partial class SymFileIncoming
    {
        public string RelativeDir { get; set; }
        public string FileName { get; set; }
        public char LastEventType { get; set; }
        public string NodeId { get; set; }
        public long? FileModifiedTime { get; set; }
    }
}