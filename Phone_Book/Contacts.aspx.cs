using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Phone_Book
{
    public partial class Contacts : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["contactdatabase"].ConnectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && Request.QueryString["action"] != null)
                {
                    string id = Request.QueryString["id"];
                    string action = Request.QueryString["action"];
                    string name=null;
                    string contact=null;
                    string email=null;
                    string address=null;
                    con.Open();
                    cmd = new SqlCommand("select * from Phone_Book where Id='"+id+"'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        name = dr["Name"].ToString();
                        contact = dr["Contact"].ToString();
                        email = dr["Email"].ToString();
                        address = dr["Address"].ToString();
                    }
                    con.Close();
                    if (action == "1")
                    {
                        con.Open();
                        cmd = new SqlCommand("delete from Phone_Book where id = '" + id + "'", con);
                        int checkD = cmd.ExecuteNonQuery();
                        if (checkD == 1)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "deleted", "<script>alert('Contact deleted!');" +
                                "location='Contacts.aspx';</script>");
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert(Failed!!!);</script>");
                        }
                        con.Close();
                    }
                    else if (action == "2")
                    {
                        btnAdd.Enabled = false;
                        btnUpdate.Enabled = true;
                        Session["id"] = id;
                        txtName.Text = name;
                        txtContact.Text = contact;
                        txtEmail.Text = email;
                        txtAddress.Text = address;
                    }
                    
                }
                con.Open();

                cmd = new SqlCommand("select * from Phone_Book", con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    gridBook.DataSource = dr;
                    gridBook.DataBind();
                }
            }
            con.Close();
            if (Session["username"] == null)
                Response.Redirect("Login.aspx");

            lblUserDetails.Text = "Username : " + Session["username"];

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Phone_Book values(@Name,@Contact,@Email,@Address)", con);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContact.Text);
            cmd.Parameters.Add("@Email", txtEmail.Text);
            cmd.Parameters.Add("@Address", txtAddress.Text);
            int count = cmd.ExecuteNonQuery();
            if (count == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "added", "<script>alert('Contact Added successfully!' );" +
                    "location='Contacts.aspx';</script>");
                txtName.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "failed", "<script>alert('Failed! Please try again...!!!' );</script>");

            }
            con.Close();
        }

        protected void btnEdid_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update Phone_Book set Name=@Name, Contact=@Contact, Email=@Email, Address=@Address where id = '" + Session["id"] + "'", con);
            cmd.Parameters.Add("@Name", txtName.Text);
            cmd.Parameters.Add("@Contact", txtContact.Text);
            cmd.Parameters.Add("@Email", txtEmail.Text);
            cmd.Parameters.Add("@Address", txtAddress.Text);
            int checkD = cmd.ExecuteNonQuery();
            if (checkD == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updated", "<script>alert('Contact updated!');location='Contacts.aspx';</script>");
                txtName.Text = "";
                txtContact.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";
                btnAdd.Enabled = true;
                btnUpdate.Enabled = false;
                Session.Abandon();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "updatefailed", "<script>alert('Failed!!!');</script>");
            }
            con.Close();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}