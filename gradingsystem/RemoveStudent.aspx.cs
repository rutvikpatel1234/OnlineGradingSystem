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
using System.Text;


namespace gradingsystem
{
    public partial class RemoveStudent : System.Web.UI.Page
    {
        Student InsertCourseObejct = new Student();

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
                        Response.Redirect("~/CourseView.aspx", false);
                    }
                    else
                    {
                        var Deletestudent = InsertCourseObejct.sp_student_course_master_get_and_course(courseId);
                        DataTable dataTable = new DataTable();
                        dataTable = Deletestudent.Tables[0];
                        gv_removestudent.DataSource = dataTable;
                        gv_removestudent.DataBind();
                        gv_removestudent.Columns[1].Visible = false;
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
        protected void Button_deletestudent(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gv_removestudent.Rows)
            {
                var checkbox = gvrow.FindControl("remove_student") as CheckBox;
                if (checkbox.Checked)
                {
                    var studentid = gvrow.Cells[2].Text;
                    var studentcourseid = gvrow.Cells[1].Text;
                    var studentName = gvrow.Cells[3].Text;
                    var deletestu = InsertCourseObejct.sp_student_course_master_remove(studentcourseid, studentid);
                    if (deletestu != "-1")
                        Response.Redirect("~/grades.aspx", false);
                    else
                        Response.Write("<script>alert('Student not Delete') </script>");
                }
            }
        }
    }
}