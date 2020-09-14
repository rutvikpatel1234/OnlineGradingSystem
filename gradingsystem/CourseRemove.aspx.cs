using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using gradingsystem;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Utilities;

namespace gradingsystem
{
    public partial class CourseRemove : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();

        Course InsertStudentObejct = new Course();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!CheckForSession())
                    Server.Transfer("login.aspx");
                else
                {
                    string userId = Session["User_id"].ToString();
                    var CourseData = InsertStudentObejct.sp_course_master_List(userId);
                    DataTable dataTable = new DataTable();
                    dataTable = CourseData.Tables[0];
                    gv_courseremove.DataSource = dataTable;
                    gv_courseremove.DataBind();
                }
            }
        }
        protected void CourseDelete(object sender, EventArgs e)
        {
            foreach (GridViewRow gvrow in gv_courseremove.Rows)
            {
                var checkbox = gvrow.FindControl("remove_course") as CheckBox;
                if (checkbox.Checked)
                {
                    var courseId = gvrow.Cells[1].Text;
                    var courseName = gvrow.Cells[2].Text;
                    var deleteCourse = InsertStudentObejct.sp_course_master_Delete(courseId);
                    if (deleteCourse != "-1")
                    {

                        Server.Transfer("course.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('Course Not Delete Please Try Agin!') </script>");
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
    }
}