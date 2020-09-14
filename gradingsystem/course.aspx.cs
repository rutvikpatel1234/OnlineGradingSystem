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
    public partial class course : System.Web.UI.Page
    {
        List<String> ValidationInsertCourseErrorArray = new List<String>();
        Course InsertCourseObejct = new Course();


        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["courseId"] = null;
            string InnerHtml = string.Empty;
            string userId = Session["User_id"].ToString();
            DataSet CourseDataSet = InsertCourseObejct.sp_course_master_List(userId);
            if (CourseDataSet != null)
            {
                DataTable dataTable = new DataTable();
                dataTable = CourseDataSet.Tables[0];
                if (dataTable.Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder("");

                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {


                        sb.Append("<div class=\"card bg-light text-dark border-primary mb-3 details\" style=\"width: 18rem;\">");
                        sb.Append("<img class=\"card-img-top imgheight\" src=\"" + dataTable.Rows[i]["image_url"] + "\" alt=\"Card image cap\">");
                        sb.Append("<div class=\"card-body\">");
                        sb.Append("<h6 class=\"card-title\">" + dataTable.Rows[i]["title"] + "</h6> <span class=\"card-title\">");
                        sb.Append("<h6 class=\"card-title\">" + dataTable.Rows[i]["Course_Name"] + "</h6> <span class=\"card-title\"> Department:" + dataTable.Rows[i]["department"] + "</span> <br/> <span class=\"card-title\"> Semester:" + dataTable.Rows[i]["semesters"] + "</span>");
                        sb.Append("</div>");
                        sb.Append("<div class=\"card-body\">");
                        sb.Append("<a href=\"Grades.aspx?_id=" + dataTable.Rows[i]["course_id"] + "\"class=\"btn btn-outline-primary\">Grade Book</a>");
                        sb.Append("</div></div>");

                    }
                    InnerHtml = sb.ToString();
                }
                else
                {
                    Response.Write("<script>alert('Add course first from AddCourse')</script>");
                }
            }
            details.InnerHtml = InnerHtml;

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