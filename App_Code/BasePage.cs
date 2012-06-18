using System;
using System.Data;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public class BasePage :Page
{
    public const string SESSION_KEY_LANGUAGE = "Lang";

    protected override void InitializeCulture()
    {
        base.InitializeCulture();
        if (Session[SESSION_KEY_LANGUAGE] == null)
        {
            Session[SESSION_KEY_LANGUAGE] = "vi-VN";
        }
        //If you would like to have DefaultLanguage changes to effect all users,
        // or when the session expires, the DefaultLanguage will be chosen, do this:
        // (better put in somewhere more GLOBAL so it will be called once)
        //LanguageManager.DefaultCulture = ...

        //Change language setting to user-chosen one
        if (Session[SESSION_KEY_LANGUAGE] != null)
        {
            
            ApplyNewLanguage(new System.Globalization.CultureInfo(Session[SESSION_KEY_LANGUAGE].ToString()));
        }
    }

    private void ApplyNewLanguage(CultureInfo culture)
    {
        LanguageManager.CurrentCulture = culture;
        //Keep current language in session
        Session.Add(SESSION_KEY_LANGUAGE, LanguageManager.CurrentCulture);
    }

    protected void ApplyNewLanguageAndRefreshPage(CultureInfo culture)
    {
        ApplyNewLanguage(culture);
        //Refresh the current page to make all control-texts take effect
        Response.Redirect(Request.Url.AbsoluteUri);
    }
    private void thu() {
        LanguageManager.CurrentCulture = (new System.Globalization.CultureInfo(Session[SESSION_KEY_LANGUAGE].ToString()));
        Session.Add("Lang", LanguageManager.CurrentCulture);
        Response.Redirect(Request.Url.AbsoluteUri);
    }
}