using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Data.SqlClient;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace GDEProjectOnlineCertificate.Pages.Account
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

         SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-JU6GD4E\SQLEXPRESS;Initial Catalog=DefaultConnection;Integrated Security=True");
       

        protected void btnCreate_Click(object sender, EventArgs e)
        { // Default UserStore constructor uses the default connection string named: DefaultConnection
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);

            var user = new IdentityUser() { UserName = txtIDNumber.Text};
           
         
            IdentityResult result = manager.Create(user, txtPassword.Text);
         
            if (result.Succeeded)
            {

                

                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);
                using (sqlCon)
                {
                    sqlCon.Open();
                    SqlCommand sql_cmnd = new SqlCommand("PROC_Registration", sqlCon);
                    sql_cmnd.CommandType = CommandType.StoredProcedure;
                    sql_cmnd.Parameters.AddWithValue("@userIDNumber", SqlDbType.BigInt).Value = txtIDNumber.Text;
                    sql_cmnd.Parameters.AddWithValue("@FName", SqlDbType.VarChar).Value = txtFName.Text;
                    sql_cmnd.Parameters.AddWithValue("@LName", SqlDbType.VarChar).Value = txtLName.Text;
                    sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                    sql_cmnd.Parameters.AddWithValue("@Cell", SqlDbType.VarChar).Value = txtCell.Text;
                   
                    Response.Redirect("../Account/Login.aspx");
                    sql_cmnd.ExecuteNonQuery();
                    sqlCon.Close();
                }
                  
            }
            else
            {
               lblMessage.Text = result.Errors.FirstOrDefault();
            }
            

        }

        
    }
}