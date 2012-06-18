using System;
using System.Windows.Controls;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Messaging;
using SilverlightExampleApp.Messages;

namespace SilverlightExampleApp.Views
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            Messenger.Default.Register<NavigationMessage>(this, message => UpdateContentPane(message.NavigateTo));
            Messenger.Default.Register<StatusBarMessage>(this, message => UpdateStatusBar(message.Text));
        }

        private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            e.Handled = true;
            ErrorWindow.CreateNew(e.Exception);
        }

        private void UpdateContentPane(Uri navigateTo)
        {
            ContentFrame.Navigate(navigateTo);
        }

        private void UpdateStatusBar(string text)
        {
            txtStatusBar.Text = string.IsNullOrEmpty(text) ? "Ready" : text;
        }


        private void ContentFrame_Navigated(object sender, NavigationEventArgs e)
        {
            //do nothing 
        }
    }
}
