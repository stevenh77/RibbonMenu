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
using SilverlightExampleApp.AuthenticationServiceReference;
using SilverlightExampleApp.Helpers;
using SilverlightExampleApp.Messages;

namespace SilverlightExampleApp.Views
{
    public partial class LogOut : Page
    {
        public LogOut()
        {
            InitializeComponent();
        }

        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AuthenticationServiceClient client;
            client = new AuthenticationServiceClient();
            client.LogOutCompleted += LogOutCompleted;
            client.LogOutAsync();
        }

        private void LogOutCompleted(object sender, LogOutCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null || !e.Result)
            {
                txtStatus.Text = "Logout failed, please try again.";

                if (e.Cancelled)
                {
                    ToolTipService.SetToolTip(txtStatus, "Service call cancelled");
                }
                else if (e.Error != null)
                {
                    string message = string.Format("Service call exception: {0}", e.Error.Message);
                    ToolTipService.SetToolTip(txtStatus, message);
                }
            }
            else if (e.Result)
            {
                SessionManager.Session["user"] = null;

                // messenger service logout
                Messenger.Default.Send(new LogOutMessage());
            }
            else
            {
                // status bar = "Unknown response from service call";
            }
        }
    }
}
