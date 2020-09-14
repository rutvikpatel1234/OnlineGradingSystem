using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Utilities;
using gradingsystem;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System;

namespace gradingsystem
{
    public partial class AssginmentRemove : System.Web.UI.Page
    {
        AssignmentDB InsertCourseObejct = new AssignmentDB();

        DBConnect db = new DBConnect();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CheckForSession())
                    Response.Redirect("Login.aspx");
                else
                {
                    string courseId = "0";
                    if (Session["courseId"] != null)
                    {
                        courseId = Session["courseId"].ToString();
                    }
                    if (courseId == "0")
                    {
                        Response.Redirect("~/course.aspx", false);
                    }
                    else
                    {
                        var Assignmentdeta = InsertCourseObejct.sp_assignment_master_List(courseId);
                        DataTable dataTable = new DataTable();
                        dataTable = Assignmentdeta.Tables[0];
                        gv_assignmentremove.DataSource = dataTable;
                        gv_assignmentremove.DataBind();
                    }
                }
            }
        }
        private bool CheckForSession()
        {
            bool isSession = true;
            if (Session["user_ID"] == null || Session["user_name"] == null || Session["roll_user"] == null)
                isSession = false;
            return isSession;


        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gv_assignmentremove.Rows)
            {
                var checkbox = gvrow.FindControl("remove_assignment") as CheckBox;
                if (checkbox.Checked)
                {
                    var AssignMentId = gvrow.Cells[1].Text;
                    var AssignMentName = gvrow.Cells[1].Text;
                    var ResponseReturned = InsertCourseObejct.sp_assignment_master_delete(AssignMentId);
                    if (ResponseReturned != "-1")

                        Server.Transfer("~/course.aspx", false);
                    else
                    {
                        Response.Write("<script>alert('Assignment not Delete') </script>");
                    }

                }
            }
        }
    }
}