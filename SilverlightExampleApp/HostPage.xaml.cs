using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using SilverlightExampleApp.Helpers;
using SilverlightExampleApp.Messages;
using SilverlightExampleApp.Views;

namespace SilverlightExampleApp
{
    public partial class HostPage : Page
    {
        public HostPage()
        {
            InitializeComponent();

            Messenger.Default.Register<LogOutMessage>(this, ReloadLoginPage);
        }
        
        private void ReloadLoginPage(LogOutMessage message)
        {
            ContentFrame.Source = new Uri("/login", UriKind.Relative);
        }

        private void ContentFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.Uri.OriginalString == "/login") return;
            if (SessionManager.Session["user"] != null) return;

            e.Cancel = true;
            ReloadLoginPage(null);
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }
    }
}
