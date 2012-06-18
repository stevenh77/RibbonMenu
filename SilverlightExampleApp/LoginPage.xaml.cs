using System;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using SilverlightExampleApp.AuthenticationServiceReference;
using SilverlightExampleApp.Helpers;
using SilverlightExampleApp.Models;

namespace SilverlightExampleApp
{
    public partial class LoginPage : Page
    {
        private readonly AuthenticationServiceClient _service;
        //public ICommand EnterKeyCommand;

        public LoginPage()
        {
            InitializeComponent();
            SessionManager.Session["user"] = null; 
            
            HtmlPage.Plugin.Focus();
            this.txtUsername.Focus();

            _service = new AuthenticationServiceClient();
            _service.AuthenticateCompleted += AuthenticateCompleted;

            //EnterKeyCommand = new RelayCommand<KeyEventArgs>(EnterKeyCommand_Execute);
        }

        //private void EnterKeyCommand_Execute(KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //        Login();
        //}

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void Login()
        {
            _service.AuthenticateAsync(txtUsername.Text, txtPassword.Password);
            btnLogin.IsEnabled = false;
        }

        private void AuthenticateCompleted(object sender, AuthenticateCompletedEventArgs e)
        {
            if (e.Cancelled || e.Error != null || !e.Result)
            {
                txtError.Text = "Login failed, please try again.";

                if (e.Cancelled)
                {
                    ToolTipService.SetToolTip(txtError, "Service call cancelled");
                }
                else if (e.Error != null)
                {
                    string message = string.Format("Service call exception: {0}", e.Error.Message); 
                    ToolTipService.SetToolTip(txtError, message);
                }
            }
            else if (e.Result)
            {
                SessionManager.Session["user"] = new User() {Username = txtUsername.Text};
                NavigationService.Navigate(new Uri("/main", UriKind.Relative));
            }
            else
            {
                txtError.Text = "Unknown response from service call";
            }

            btnLogin.IsEnabled = true;
        }

        private void LayoutRoot_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                Login();
        }
    }
}
