using System;
using System.Windows.Controls;
using Divelements.SandRibbon;
using GalaSoft.MvvmLight.Messaging;
using SilverlightExampleApp.Messages;

namespace SilverbladeDemo.Views
{
    public partial class Ribbon : UserControl
    {
        public Ribbon()
        {
            InitializeComponent();
        }

        private void Navigate(object sender, ActivateEventArgs e)
        {
            object uri = ((ContentControl) sender).Tag;
            
            if (uri == null)
                return;
            
            Messenger.Default.Send(
                new NavigationMessage() 
                    { NavigateTo = new Uri(uri.ToString(), UriKind.Relative)}
                );
        }
    }
}
