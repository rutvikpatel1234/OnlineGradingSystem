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
    public partial class createcourseform : System.Web.UI.Page
    {
        List<String> ValidationInsertCourseErrorArray = new List<String>();
        Course InsertCourseObejct = new Course();

        DBConnect db = new DBConnect();
        SqlCommand dbCommand = new SqlCommand();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        private bool CheckForSession()
        {
            bool isSession = true;
            if (Session["user_ID"] == null || Session["user_name"] == null || Session["roll_user"] == null)
                isSession = false;
            return isSession;
        }
        public int ValidateInsertCourse()
        {

            if (txtDesc.Text == "")
            {
                ValidationInsertCourseErrorArray.Add("Enter Valid Course Number and Description");
            }

            if (CourseDepartmentDropDown.SelectedValue == "default")
            {
                ValidationInsertCourseErrorArray.Add("Select Department For Course");
            }

            if (CourseAddSemesterDropDown.SelectedValue == "default")
            {
                ValidationInsertCourseErrorArray.Add("Select select Semaster");
            }

            if (txttitle.Text == "")
            {
                ValidationInsertCourseErrorArray.Add("Please select image");
            }

            return 1;
        }
        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            string strFolder = Server.MapPath("~/");
            strFolder = strFolder + "img";
            string fileName = FileUpload1.FileName;
            CheckforFolderExists(strFolder);
            string strFilePath = strFolder + "\\" + fileName;

            FileUpload1.SaveAs(strFilePath);

            if (FileUpload1.HasFile)
            { }
            string userid = Session["user_ID"].ToString();
            var courseadd = InsertCourseObejct.sp_course_master_addupdate(0, txtDesc.Text, CourseDepartmentDropDown.SelectedValue, userid, CourseAddSemesterDropDown.SelectedValue, "/img/" + FileUpload1.FileName, txttitle.Text);
            if (courseadd != -1)
            {

                Server.Transfer("course.aspx");
            }
            else
            {
                Response.Write("<script>alert('Course Already Exist') </script>");
            }

        }
        private static void CheckforFolderExists(string strFolder)
        {
            if (!Directory.Exists(strFolder))
            {
                Directory.CreateDirectory(strFolder);
            }
        }
    }
}