namespace Notification.Helpers.SendEmail
{
    public interface ISendEmailWithErrorConfiguration
    {
        bool AllowSend { get; set; }
        string ToEmails { get; set; }
    }
}
