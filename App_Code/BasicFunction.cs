using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

/// <summary>
/// Summary description for BasicFunction
/// </summary>
public class BasicFunction
{
    struct MyObj
    {
        public static string message { get; set; }
    }
   
    public BasicFunction()
    {	//
        // TODO: Add constructor logic here
        //
    }
    public static void Show1(string message)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        // string script = "<script type=\"text/javascript\">" + cleanMessage + "</script>";
        Page page = (Page)HttpContext.Current.CurrentHandler;
        string keyy = "key1";
        if (!page.IsStartupScriptRegistered(keyy))
        {

            page.RegisterStartupScript(keyy, script);
        }

    }

    public static void ShowAndRedirect(string message, string URL)
    {
        // Cleans the message to allow single quotation marks 
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');window.location.href='" + URL + "'</script>";
        // string script = "<script type=\"text/javascript\">" + cleanMessage + "</script>";
        Page page = (Page)HttpContext.Current.CurrentHandler;
        string keyy = "key1";
        if (!page.IsStartupScriptRegistered(keyy))
        {

            page.RegisterStartupScript(keyy, script);
        }
    }

    public static DataTable GetDetailsByDatatable(string Query)
    {
        SqlConnection conn;

        SqlDataAdapter adp;
        DataTable dTable = new DataTable("DataTable1");
        conn = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["VanityURLConn"].ToString());

        adp = new SqlDataAdapter(Query, conn);
        adp.Fill(dTable);
        return dTable;
    }

    public static void Show(string message, UpdatePanel panel)
    {
        string cleanMessage = message.Replace("'", "\\'");
        string script = "<script type=\"text/javascript\">alert('" + cleanMessage + "');</script>";
        Page page = (Page)HttpContext.Current.CurrentHandler;
        string key = "alertshow";
        if (!page.ClientScript.IsStartupScriptRegistered(key))
        {
            ScriptManager.RegisterStartupScript(panel, panel.GetType(), key, script, false);
        }
    }
    //checking image file extension e.g .jpg,.bmp etc.
    public static bool CheckImageFileType(string FileName)
    {
        //string tmp = FileUpload1.PostedFile.FileName.ToString();
        string tmp = FileName;
        string f1 = System.IO.Path.GetExtension(tmp);
        string Ext = f1.ToString().Trim().ToLower();
        if ((Ext.ToString() == ".jpg" || Ext.ToString() == ".gif" || Ext.ToString() == ".jpeg" || Ext.ToString() == ".bmp" || Ext.ToString() == ".png"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckPdfFileType(string FileName)
    {
        //string tmp = FileUpload1.PostedFile.FileName.ToString();
        string tmp = FileName;
        string f1 = System.IO.Path.GetExtension(tmp);
        string Ext = f1.ToString().Trim().ToLower();
        if ((Ext.ToString() == ".pdf"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static string TitleCase(string value)
    {

        return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);

    }

    //public static Stream DataTableToJSONWithJSONNet(DataTable table, string valid, string message)
    //{
    //    string JSONString = string.Empty;
    //    dynamic collectionWrapper;

    //    if (table.Rows.Count > 0)
    //    {
    //        collectionWrapper = new
    //        {
    //            login = valid,
    //            data = table,
    //            message = message
    //        };
    //    }
    //    else
    //    {
    //        collectionWrapper = new
    //        {
    //            login = valid,
    //            message = message
    //        };
    //    }

    //    JSONString = JsonConvert.SerializeObject(collectionWrapper);
    //    //return JSONString;
    //    return new MemoryStream(Encoding.UTF8.GetBytes(JSONString.Replace("[", "").Replace("]", "")));
    //}


    public static bool ValidateName(string sName)
    {
        string strRegex = @"^[a-zA-Z ]*$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sName))
            return (true);
        else
            return (false);
    }

    public static bool ValidateEmail(string sEmailId)
    {
        string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sEmailId))
        {


            return (true);
        }
        else
        {
            return (false);
        }
    }

    //public static bool ValidateMobile(string sMobile)
    //{
    //    string strRegex = @"^([7-9]{1})([0-9]{9})$";
    //    Regex re = new Regex(strRegex);
    //    if (re.IsMatch(sMobile))
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}

    public static bool ValidateMobile(string sMobile)
    {
        string strRegex = @"^\d{10}$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sMobile))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ValidateLandline(string sLandline)
    {
        string strRegex = @"^[0-9]{8,11}$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sLandline))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool ValidateCity(string sCity)
    {
        string strRegex = @"^[a-zA-Z. ]*$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sCity))
            return (true);
        else
            return (false);
    }

    public static bool ValidateDate(string sDate)
    {
        string strRegex = @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sDate))
            return (true);
        else
            return (false);
    }

    public static bool ValidateZipCode(string sZipCode)
    {
        string strRegex = @"^[0-9]{6}$";
        Regex re = new Regex(strRegex);
        if (re.IsMatch(sZipCode))
            return (true);
        else
            return (false);
    }

    public static string Encrypt(string clearText)
    {
        string EncryptionKey = "VANITYURL12";
        byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                clearText = Convert.ToBase64String(ms.ToArray());
            }
        }
        return clearText;
    }

    public static string Decrypt(string cipherText)
    {
        string EncryptionKey = "VANITYURL12";
        cipherText = cipherText.Replace(" ", "+");
        byte[] cipherBytes = Convert.FromBase64String(cipherText);
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                cipherText = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return cipherText;
    }

    public static bool IsSQLCharPresent(string txt)
    {
        if (string.IsNullOrEmpty(txt) == false)
        {
            if (Regex.IsMatch(txt, @"[^A-Za-z0-9-_ .&/'-@]"))
            {
                //Show("Special characters not allowed.only (-_ .@&) are allowed.");
                return true;
            }
        }

        return false;
    }

    public static string replacesplchar(string value)
    {
        string strval = value;
        strval = strval.Replace(" ", "_");
        strval = strval.Replace("/", "_");

        return strval;

    }


    public static string GetConnectionstring()
    {
        return ConfigurationManager.ConnectionStrings["VanityURLConn"].ToString();
    }
}
