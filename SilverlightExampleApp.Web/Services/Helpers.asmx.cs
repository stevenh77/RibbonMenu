using System;
using System.Globalization;
using System.Web.Services;
using System.Windows;
using System.Windows.Media;

namespace SilverlightExampleApp.Web.Services
{
    [WebService(Namespace = "http://silverbladetechnology.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Helpers : WebService
    {
        [WebMethod]
        public string Text2Path(String strText, string strCulture, bool LtoR, string strTypeFace, int nSize)
        {
            if (strCulture == "")
                strCulture = "en-us";

            CultureInfo ci = new CultureInfo(strCulture);
            FlowDirection fd = LtoR ? FlowDirection.LeftToRight : FlowDirection.RightToLeft;
            FontFamily ff = new FontFamily(strTypeFace);
            Typeface tf = new Typeface(ff, FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
            FormattedText t = new FormattedText(strText, ci, fd, tf, nSize, Brushes.Black);
            Geometry g = t.BuildGeometry(new Point(0, 0));
            PathGeometry p = g.GetFlattenedPathGeometry();

            return p.ToString();
        }
    }
}
