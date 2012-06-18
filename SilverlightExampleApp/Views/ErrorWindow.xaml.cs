using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightExampleApp.Views
{
    public enum StackTracePolicy
    {
        /// <summary>
        ///   Stack trace is shown when running with a debugger attached or when running the app on the local machine.
        ///   Use this to get additional debug information you don't want the end users to see.
        /// </summary>
        OnlyWhenDebuggingOrRunningLocally,

        /// <summary>
        /// Always show the stack trace, even if debugging
        /// </summary>
        Always,

        /// <summary>
        /// Never show the stack trace, even when debugging
        /// </summary>
        Never
    }

    public partial class ErrorWindow : ChildWindow
    {    
        protected ErrorWindow(string message, string errorDetails)
        {
            InitializeComponent();
            IntroductoryText.Text = message;
            ErrorTextBox.Text = errorDetails;
        }

        public static void CreateNew(string message)
        {
            CreateNew(message, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally);
        }

        public static void CreateNew(Exception exception)
        {
            CreateNew(exception, StackTracePolicy.OnlyWhenDebuggingOrRunningLocally);
        }

        public static void CreateNew(Exception exception, StackTracePolicy policy)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            string fullStackTrace = exception.StackTrace;

            // Account for nested exceptions
            Exception innerException = exception.InnerException;
            while (innerException != null)
            {
                fullStackTrace += "\nCaused by: " + exception.Message + "\n\n" + exception.StackTrace;
                innerException = innerException.InnerException;
            }

            CreateNew(exception.Message, fullStackTrace, policy);
        }

        public static void CreateNew(string message, StackTracePolicy policy)
        {
            CreateNew(message, new StackTrace().ToString(), policy);
        }
        
        private static void CreateNew(string message, string stackTrace, StackTracePolicy policy)
        {
            string errorDetails = string.Empty;

            if (policy == StackTracePolicy.Always ||
                policy == StackTracePolicy.OnlyWhenDebuggingOrRunningLocally && IsRunningUnderDebugOrLocalhost)
            {
                errorDetails = stackTrace ?? string.Empty;
            }

            ErrorWindow window = new ErrorWindow(message, errorDetails);
            window.Show();
        }

        private static bool IsRunningUnderDebugOrLocalhost
        {
            get
            {
                if (Debugger.IsAttached)
                {
                    return true;
                }
                else
                {
                    string hostUrl = Application.Current.Host.Source.Host;
                    return hostUrl.Contains("::1") || hostUrl.Contains("localhost") || hostUrl.Contains("127.0.0.1");
                }
            }
        }
         
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}

