using System;

namespace SilverlightExampleApp.Dialogs
{
    /// <summary>
    ///     Dialog service implementation
    /// </summary>
    public class DialogService : IDialogService
    {
        #region IDialogService Members

        /// <summary>
        ///     Show it
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="allowCancel"></param>
        /// <param name="response"></param>
        public void ShowDialog(string title, string message, bool allowCancel, Action<bool> response)
        {
            var dialog = new SimpleDialog(allowCancel) {Title = title, Message = message, CloseAction = response};
            dialog.Closed += DialogClosed;
            dialog.Show();
        }

        /// <summary>
        ///     Closed action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void DialogClosed(object sender, EventArgs e)
        {
            ((SimpleDialog) sender).CloseAction(((SimpleDialog)sender).DialogResult == true);             
        }

        #endregion
    }
}
