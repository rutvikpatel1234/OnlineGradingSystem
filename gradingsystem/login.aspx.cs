using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public partial class login : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();
        SqlCommand commandObject = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            commandObject.CommandType = CommandType.StoredProcedure;
            commandObject.CommandText = "sp_login_master";
            commandObject.Parameters.AddWithValue("@user_name", txtUser.Text);
            commandObject.Parameters.AddWithValue("@password", txtPassword.Text);

            DataSet userDetails = db.GetDataSetUsingCmdObj(commandObject);

            DataTable dataTable = new DataTable();

            if (userDetails != null)
            {
                dataTable = userDetails.Tables[0];
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string user_ID = dataTable.Rows[0]["user_ID"].ToString();
                    string user_name = dataTable.Rows[0]["user_name"].ToString();
                    string roll_user = dataTable.Rows[0]["roll_user"].ToString();

                    if (!string.IsNullOrWhiteSpace(roll_user) && roll_user.ToLower() == "professor")
                    {
                        Session["user_ID"] = user_ID;
                        Session["user_name"] = user_name;
                        Session["roll_user"] = roll_user;
                        Server.Transfer("course.aspx");
                    }
                    else
                        Response.Write("<script>alert('Login Password Does Not Much...!!!')</script>");

                }
                else
                {
                    Response.Write("<script>alert('login failed!!!')</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('login failed')</script>");
            }

        }
    }
}