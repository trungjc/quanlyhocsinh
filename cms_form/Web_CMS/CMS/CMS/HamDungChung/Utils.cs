using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Text;

namespace CMS
{
    public class Utils
    {
        public string GetIpAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }

        public string GetInfoUser()
        {
            return (string)AspNetCache.GetCache(GetIpAddress());
        }

        public void CreateFile(string _path, string _url, string _fileName, out string _tag, RadChart _chart)
        {
            string _file = _path + "/" + _fileName;
            _chart.Save(_file, System.Drawing.Imaging.ImageFormat.Png);

            _tag = "";

            _chart.Visible = false;
            _chart.DataBind();

        }

        public bool CheckFile(string _path, string _url, string _fileName, out string _tag)
        {
            string _file = _path + "/" + _fileName;

            if (System.IO.File.Exists(_file))
            {
                _tag = "<img src='" + _url + "/" + _fileName + "'>";
                return true;
            }
            _tag = "";
            return false;
        }

        public bool DeleteFile(string _path, string _url, string _fileName)
        {
            string _file = _path + "/" + _fileName;

            if (System.IO.File.Exists(_file))
            {
                System.IO.File.Delete(_file);
                return true;
            }

            return false;
        }

        public string Getstring(string _txt)
        {

            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = _txt.Normalize(NormalizationForm.FormD);
            return RemoveExtraSpaces(UCS2Convert(v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').Replace(" ", "-").Replace(":", "")));
        }

        private string RemoveExtraSpaces(string s)
        {
            if (!s.Contains("--")) return s;

            return RemoveExtraSpaces(s.Replace("--", "-"));
        }

        public static String UCS2Convert(String sContent)
        {
            sContent = sContent.Trim();
            String sUTF8Lower = "a|á|à|ả|ã|ạ|ă|ắ|ằ|ẳ|ẵ|ặ|â|ấ|ầ|ẩ|ẫ|ậ|đ|e|é|è|ẻ|ẽ|ẹ|ê|ế|ề|ể|ễ|ệ|i|í|ì|ỉ|ĩ|ị|o|ó|ò|ỏ|õ|ọ|ô|ố|ồ|ổ|ỗ|ộ|ơ|ớ|ờ|ở|ỡ|ợ|u|ú|ù|ủ|ũ|ụ|ư|ứ|ừ|ử|ữ|ự|y|ý|ỳ|ỷ|ỹ|ỵ";

            String sUTF8Upper = "A|Á|À|Ả|Ã|Ạ|Ă|Ắ|Ằ|Ẳ|Ẵ|Ặ|Â|Ấ|Ầ|Ẩ|Ẫ|Ậ|Đ|E|É|È|Ẻ|Ẽ|Ẹ|Ê|Ế|Ề|Ể|Ễ|Ệ|I|Í|Ì|Ỉ|Ĩ|Ị|O|Ó|Ò|Ỏ|Õ|Ọ|Ô|Ố|Ồ|Ổ|Ỗ|Ộ|Ơ|Ớ|Ờ|Ở|Ỡ|Ợ|U|Ú|Ù|Ủ|Ũ|Ụ|Ư|Ứ|Ừ|Ử|Ữ|Ự|Y|Ý|Ỳ|Ỷ|Ỹ|Ỵ";

            String sUCS2Lower = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|d|e|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|i|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|u|y|y|y|y|y|y";

            String sUCS2Upper = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|D|E|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|I|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|U|Y|Y|Y|Y|Y|Y";

            String[] aUTF8Lower = sUTF8Lower.Split(new Char[] { '|' });

            String[] aUTF8Upper = sUTF8Upper.Split(new Char[] { '|' });

            String[] aUCS2Lower = sUCS2Lower.Split(new Char[] { '|' });

            String[] aUCS2Upper = sUCS2Upper.Split(new Char[] { '|' });

            Int32 nLimitChar;

            nLimitChar = aUTF8Lower.GetUpperBound(0);

            for (int i = 1; i <= nLimitChar; i++)
            {

                sContent = sContent.Replace(aUTF8Lower[i], aUCS2Lower[i]);

                sContent = sContent.Replace(aUTF8Upper[i], aUCS2Upper[i]);

            }
            string sUCS2regex = @"[A-Za-z0-9- ]";
            string sEscaped = new Regex(sUCS2regex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
            if (string.IsNullOrEmpty(sEscaped))
                return sContent;
            sEscaped = sEscaped.Replace("[", "\\[");
            sEscaped = sEscaped.Replace("]", "\\]");
            sEscaped = sEscaped.Replace("^", "\\^");
            string sEscapedregex = @"[" + sEscaped + "]";
            return new Regex(sEscapedregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture).Replace(sContent, string.Empty);
        }

        public static string FixHtml(string Html)
        {
            string strOutput = Html;
            //Stripts the <p> tags from the Html
            string pregex = @"<p[^>.]*>&nbsp;</p>";
            System.Text.RegularExpressions.Regex p = new System.Text.RegularExpressions.Regex(pregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
            strOutput = p.Replace(strOutput, "<br>");

            //Stripts the <link> tags from the Html
            string linkregex = @"<link[\s\S]*?>";
            System.Text.RegularExpressions.Regex link = new System.Text.RegularExpressions.Regex(linkregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
            strOutput = link.Replace(strOutput, string.Empty);

            //Stripts the <style> tags from the Html
            string styleregex = @"<style[^>.]*>[\s\S]*?</style>";
            System.Text.RegularExpressions.Regex styles = new System.Text.RegularExpressions.Regex(styleregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
            strOutput = styles.Replace(strOutput, string.Empty);

            //Stripts the [if tags from the Html
            string ifregex = @"<!--[^>.]*>[\s\S]*?<![^>.]*-->";
            System.Text.RegularExpressions.Regex iftag = new System.Text.RegularExpressions.Regex(ifregex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture);
            strOutput = iftag.Replace(strOutput, string.Empty);
            return strOutput;
        }
        public static string SubString(string sSource, int length)
        {
            if (string.IsNullOrEmpty(sSource))
                return string.Empty;
            if (sSource.Length <= length)
                return sSource;

            string mSource = sSource;
            int nLength = length;

            int m = mSource.Length;
            while (nLength > 0 && mSource[nLength].ToString() != " ")
            {
                nLength--;
            }
            mSource = mSource.Substring(0, nLength);
            return mSource + "...";
        }
        public static string FixSubString(string sSource, int length)
        {
            if (string.IsNullOrEmpty(sSource))
                return string.Empty;
            if (sSource.Length <= length)
                return sSource;
            return sSource.Substring(0, length) + "...";
        }

        #region Lấy tin từ url website Linhlv 31/03/2014

        public static string GetHTML(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return "";
                }
                string html = "";
                HttpWebRequest rquest = (HttpWebRequest)HttpWebRequest.Create(url);
                HttpWebResponse respone = (HttpWebResponse)rquest.GetResponse();
                Stream responeStream = respone.GetResponseStream();
                StreamReader reader = new StreamReader(responeStream, Encoding.UTF8);
                html = reader.ReadToEnd();
                respone.Close();
                reader.Close();
                return html;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

    }
}