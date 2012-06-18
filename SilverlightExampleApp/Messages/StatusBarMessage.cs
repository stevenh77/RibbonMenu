using GalaSoft.MvvmLight.Messaging;

namespace SilverlightExampleApp.Messages
{
    public class StatusBarMessage : MessageBase
    {
        public StatusBarMessage(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
    }
}
