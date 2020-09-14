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
    public partial class assignment : System.Web.UI.Page
    {
        AssignmentDB InsertCourseObejct = new AssignmentDB();

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

        protected void btnassignment_Click(object sender, EventArgs e)
        {
            string courseId = Session["courseId"].ToString();

            var GetAssignment = InsertCourseObejct.sp_assignment_get_name(txtAssignment.Text, courseId);
            if (GetAssignment != null && GetAssignment.Tables[0] != null && GetAssignment.Tables[0].Rows.Count == 0)
            {
                var assignadd = InsertCourseObejct.sp_assignment_master_addupdate(0, txtAssignment.Text, courseId);
                if (assignadd != -1)
                {

                    Server.Transfer("grades.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Assignment Already Exist') </script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Assignment Already Exist with name " + txtAssignment.Text + "') </script>");
            }
        }
    }
}