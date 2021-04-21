using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDEProjectOnlineCertificate
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (chkIsActive.Checked)
                btnCreateAccount.Enabled = true;
            else
                btnCreateAccount.Enabled = false;
        }
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Pages/Account/CreateAccount.aspx");
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}