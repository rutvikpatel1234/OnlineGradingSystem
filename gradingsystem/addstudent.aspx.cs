using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using gradingsystem;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace gradingsystem
{
    public partial class addstudent : System.Web.UI.Page
    {
        Student InsertStudentObejct = new Student();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool CheckForSession()
        {
            bool isSession = true;
            if (Session["user_ID"] == null || Session["user_name"] == null || Session["roll_user"] == null)
                isSession = false;
            return isSession;
        }
        protected void btnaddstudent_Click(object sender, EventArgs e)
        {
            string courseId = Session["courseId"].ToString();
            var sadd = InsertStudentObejct.sp_student_master_addupdate(0, txtstudent.Text, txtEmail.Text, courseId);
            if (sadd != "-1")
            {
                Server.Transfer("grades.aspx");
            }
            else
            {
                Response.Write("<script>alert('Students Already Exist') </script>");
            }
        }
    }
}