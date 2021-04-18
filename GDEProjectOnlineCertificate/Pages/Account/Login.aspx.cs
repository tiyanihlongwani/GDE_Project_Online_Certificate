using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace GDEProjectOnlineCertificate.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JU6GD4E\\SQLEXPRESS;Initial Catalog=dbOnlineCertification;Integrated Security=True");

        protected void btnlogin_Click(object sender, EventArgs e)
        {

            
                string Password = "";
                bool IsExist = false;
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from tblUserRegistration where userIDNumber='" + txtIDNumber.Text + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Password = sdr.GetString(2);  //get the user password from db if the user name is exist in that.  
                    IsExist = true;
                }
                con.Close();
                if (IsExist)  //if record exis in db , it will return true, otherwise it will return false  
                {
                    if (Cryptography.Decrypt(Password).Equals(txtPassword.Text))
                    {
                   
                    Response.Redirect("../OnlineCertificate/HomePage.aspx");
                }
                    else
                    {
                     
                    lblMessage.Text = "Password incorrect!!!";
                    }

                }
                else  //showing the error message if user credential is wrong  
                {
                lblMessage.Text = "Please enter  valid credentials";
                 
                }

            }
        }
    }   