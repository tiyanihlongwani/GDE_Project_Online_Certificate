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

namespace GDEProjectOnlineCertificate.Pages.Account
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        SqlConnection sqlCon = new SqlConnection("Data Source=DESKTOP-JU6GD4E\\SQLEXPRESS;Initial Catalog=dbOnlineCertification;Integrated Security=True");
     

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string FName = txtFName.Text;
            string LName = txtLName.Text;
            string Email = txtFName.Text;
            // Passing the Password to Encrypt method and the method will return encrypted string and stored in Password variable. 
            string Password = Cryptography.Encrypt(txtPassword.Text.ToString()); 
            string IDNumber = txtIDNumber.Text.ToString();
            string Cell = txtCell.Text.ToString();


            //validating the fields whether the fields are empty or not  
            if (txtFName.Text !="" && txtLName.Text != "" && txtEmail.Text!= "" && txtCell.Text != "" && txtIDNumber.Text != "" && txtPassword.Text != "" && txtConfirmPassword.Text != "")
            {
                //validating Password textbox and confirm password textbox is match or unmatch
                if (txtPassword.Text.ToString().Trim().ToLower() == txtConfirmPassword.Text.ToString().Trim().ToLower())     
                {


                    try
                    {
                        using (sqlCon)
                        {


                            sqlCon.Open();
                            SqlCommand sql_cmnd = new SqlCommand("PROC_Registration", sqlCon);
                            sql_cmnd.CommandType = CommandType.StoredProcedure;
                            sql_cmnd.Parameters.AddWithValue("@userIDNumber", SqlDbType.BigInt).Value = IDNumber;
                            sql_cmnd.Parameters.AddWithValue("@FName", SqlDbType.VarChar).Value = FName;
                            sql_cmnd.Parameters.AddWithValue("@LName", SqlDbType.VarChar).Value = LName;
                            sql_cmnd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = Email;
                            sql_cmnd.Parameters.AddWithValue("@CellNumber", SqlDbType.Int).Value = Cell;
                            sql_cmnd.Parameters.AddWithValue("@userPassword", SqlDbType.NVarChar).Value = Password;
                            sql_cmnd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                    }
                    catch (Exception ee) 
                    {
                        lblMessage.Text = "An error Occured!!! ";
                    }
                    
                    Response.Redirect("../Account/Login.aspx");
                }
                else
                {
                    lblMessage.Text = "Password and Confirm Password doesn't match!";
                  
                }
            }
            else
            {
                 
                lblMessage.Text= "Please Fill all the fields!";
                
            }
        }

        
    }
}