using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Phone_Book
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblErrorMessage.Visible = false;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["contactdatabase"].ConnectionString);
            con.Open();
                string query = "select count(1) from tblUser where username=@username and password=@password";
            SqlCommand sqlCmd = new SqlCommand(query, con);
            sqlCmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
            int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
            if(count == 1)
            {
                Session["username"] = txtUsername.Text.Trim();
                Response.Redirect("Contacts.aspx");
            }
            else { lblErrorMessage.Visible = true; }
        }
    }
}