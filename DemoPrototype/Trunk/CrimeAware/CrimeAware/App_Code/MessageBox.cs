using System;
using System.Web;
using System.Linq;
using System.Web.UI;
using System.Collections.Generic;

/// <summary>
/// Summary description for MessageBox
/// </summary>
public class MessageBox
{
	public MessageBox()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void ShowMessageBox(string _message)
    {
        Type cstype = this.GetType();
        String csname1 = "PopupScript";

        Page page = HttpContext.Current.Handler as Page;

        // Get a ClientScriptManager reference from the Page class.
        ClientScriptManager cs = page.ClientScript;

        cs.RegisterStartupScript(cstype, csname1, "<script>alert('" + _message + "');</script>");
    }

    // for async postback events
    public void ShowMessageBoxForAsync(string _message)
    {
        Page page = HttpContext.Current.Handler as Page;
        ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "key2", "alert('" + _message + "');", true);
    }
}