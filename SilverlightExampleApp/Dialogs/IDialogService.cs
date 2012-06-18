using System;

namespace SilverlightExampleApp.Dialogs
{
    /// <summary>
    ///     Service to show a dialog
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        ///     Show the dialog
        /// </summary>
        /// <param name="title">Title to show</param>
        /// <param name="message"></param>
        /// <param name="allowCancel">True = show the Cancel button</param>
        /// <param name="response">The user's response</param>
        void ShowDialog(string title, string message, bool allowCancel, Action<bool> response);
    }
}
