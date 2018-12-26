namespace SymmetricDS.Admin.Server
{
    public partial class TriggerRouter
    {
        public int TriggerId { get; set; }
        public int RouterId { get; set; }

        public Router Router { get; set; }
        public Trigger Trigger { get; set; }
    }
}