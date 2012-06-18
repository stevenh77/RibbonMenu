using System;
using System.Windows.Browser;

namespace SilverlightExampleApp.Helpers
{
    public enum NavigationDestination
    {
        Unknown = 0,
        ClientSearch,
        ClientAddEdit
    }

    public class NavigationMap
    {
        public static Uri ResolveDestination(NavigationDestination request, string queryString = null)
        {
            Uri destination = null;

            switch (request)
            {
                case NavigationDestination.ClientAddEdit:
                    destination = new Uri(string.Format("Views/ClientDetails?{0}", HttpUtility.HtmlEncode(queryString)), UriKind.Relative);
                    break;

                default:
                    throw new Exception("Destination unknown");
            }

            return destination;

        }
    }
}
