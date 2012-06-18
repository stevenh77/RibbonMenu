using System;
using System.Windows;
using System.Windows.Controls;

namespace SilverlightExampleApp.Dialogs
{
    /// <summary>
    ///     Simple dialog
    /// </summary>
    public partial class SimpleDialog : ChildWindow
    {
        /// <summary>
        ///     Close action
        /// </summary>
        public Action<bool> CloseAction { get; set; }

        /// <summary>
        ///     Message
        /// </summary>
        public static readonly DependencyProperty MessageProperty = DependencyProperty.Register(
            "Message",
            typeof(string),
            typeof(SimpleDialog),
            null);


        /// <summary>
        ///     Message
        /// </summary>
        public string Message
        {
            get { return GetValue(MessageProperty).ToString(); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public SimpleDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public SimpleDialog(bool allowCancel)
            : this()
        {
            CancelButton.Visibility = allowCancel ? Visibility.Visible : Visibility.Collapsed;
        }

        /// <summary>
        ///     OK Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;            
        }

        /// <summary>
        ///     cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;           
        }
    }
}