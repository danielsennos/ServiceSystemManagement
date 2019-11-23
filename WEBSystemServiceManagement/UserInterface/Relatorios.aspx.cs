using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WEBSystemServiceManagement.UserInterface
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_authenticated"] != null)
            {
                Session.Timeout = 20;
            }
            else { Response.Redirect("~/UserInterface/SessionExpired", true); }

        }

    }
}