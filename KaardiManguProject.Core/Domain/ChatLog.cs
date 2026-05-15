namespace KaardiManguProject.KaardiManguProject.Core.Domain
{
    public class ChatLog
    {
        public Guid MessageID { get; set; }
        public Guid AccountID { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}
