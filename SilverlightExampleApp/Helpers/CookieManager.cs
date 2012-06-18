using System;
using System.Net;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SilverlightExampleApp.Helpers
{
    public class CookieManager
    {
        private void SetCookie(string key, string value, int expirationDays)
        {
            DateTime expireDate = DateTime.Now + TimeSpan.FromDays(expirationDays);

            string newCookie = key + "=" + value + ";expires=" + expireDate.ToString("R");
            HtmlPage.Document.SetProperty("cookie", newCookie);
        }

        private string GetCookie(string key)
        {
            string[] cookies = HtmlPage.Document.Cookies.Split(';');

            foreach (string cookie in cookies)
            {
                string[] keyValue = cookie.Split('=');
                if (keyValue.Length != 2) continue;

                if (keyValue[0] == key)
                    return keyValue[1];
            }
            return null;
        }
    }
}
