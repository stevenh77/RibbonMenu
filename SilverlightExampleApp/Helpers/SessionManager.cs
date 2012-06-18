using System.Collections.Generic;

namespace SilverlightExampleApp.Helpers
{
    public static class SessionManager
    {
        private static Dictionary<string, object> _session = new Dictionary<string, object>();

        public static Dictionary<string, object> Session
        {
            get { return _session; }
            set { _session = value; }
        }
    }
}

// SETTING: SessionManager.Session["key"] = "value";
// GETTING: txtSessionData.Text = SessionManager.Session["key"].ToString();
