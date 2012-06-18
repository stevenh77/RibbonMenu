using System;
using GalaSoft.MvvmLight.Messaging;

namespace SilverlightExampleApp.Messages
{
    public class NavigationMessage : MessageBase
    {
        public Uri NavigateTo { get; set; }
    }
}
