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
    public partial class grades : System.Web.UI.Page
    {
        DBConnect db = new DBConnect();

        Student InsertStudentObejct = new Student();

        AssignmentDB assignmentDB = new AssignmentDB();
        Grade objGrade = new Grade();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (!CheckForSession())
                    Server.Transfer("login.aspx");
                else
                {
                    string courseId = "0";
                    if (Session["courseId"] == null)
                    {
                        courseId = Request.QueryString["_id"];
                        Session["courseId"] = courseId;
                    }
                    else
                    {
                        courseId = Session["courseId"].ToString();
                    }
                    if (courseId == "0")
                    {
                        Server.Transfer("~/course.aspx");
                    }
                    if (!string.IsNullOrWhiteSpace(courseId) || !string.IsNullOrWhiteSpace(Session["courseId"].ToString()))
                    {
                        ReadGrade();
                    }

                    else
                        Server.Transfer("login.aspx");
                }
            }
            else
            {
                gv_gradetable.Columns.Clear();
                ReadGrade();
            }

        }
        private bool CheckForSession()
        {
            bool isSession = true;
            if (Session["user_ID"] == null || Session["user_name"] == null || Session["roll_user"] == null)
                isSession = false;
            return isSession;
        }
        public void ReadGrade()
        {
            string courseId = Session["courseId"].ToString();

            DataTable GradeDataTable = new DataTable();

            DataSet AssginMentResult = assignmentDB.sp_assignment_master_List(courseId);

            DataTable AssginMentdataTable = AssginMentResult.Tables[0];

            AssginMentdataTable.PrimaryKey = new DataColumn[] { AssginMentdataTable.Columns["assignment_id"] };


            var StudentData = InsertStudentObejct.sp_student_course_master_get_and_course(courseId);

            DataTable studentDataTable = StudentData.Tables[0];

            DataColumn dataColumnstudentId = new DataColumn();
            dataColumnstudentId.ColumnName = "student_id";
            GradeDataTable.Columns.Add(dataColumnstudentId);


            BoundField newBoundstudentId = new BoundField();
            newBoundstudentId.DataField = "student_id";
            newBoundstudentId.HeaderText = "Student ID";
            gv_gradetable.Columns.Add(newBoundstudentId);

            DataColumn dataColumnstudentname = new DataColumn();
            dataColumnstudentname.ColumnName = "student_name";
            GradeDataTable.Columns.Add(dataColumnstudentname);

            BoundField newBoundstudentName = new BoundField();
            newBoundstudentName.DataField = "student_name";
            newBoundstudentName.HeaderText = "Student Name";
            gv_gradetable.Columns.Add(newBoundstudentName);


            if (AssginMentResult != null && AssginMentResult.Tables[0] != null && AssginMentResult.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < AssginMentdataTable.Rows.Count; i++)
                {
                    DataColumn dataColumnAss = new DataColumn();
                    dataColumnAss.ColumnName = AssginMentdataTable.Rows[i]["name"].ToString();
                    GradeDataTable.Columns.Add(dataColumnAss);

                    BoundField newBoundAss = new BoundField();
                    newBoundAss.DataField = AssginMentdataTable.Rows[i]["name"].ToString();
                    newBoundAss.HeaderText = AssginMentdataTable.Rows[i]["name"].ToString();
                    gv_gradetable.Columns.Add(newBoundAss);
                }
            }
            DataColumn dataColumnAverage = new DataColumn();
            dataColumnAverage.ColumnName = "Avarage";
            GradeDataTable.Columns.Add(dataColumnAverage);


            BoundField newBounAverage = new BoundField();
            newBounAverage.DataField = "Avarage";
            newBounAverage.HeaderText = "Avarage %";
            gv_gradetable.Columns.Add(newBounAverage);



            if (studentDataTable != null && studentDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < studentDataTable.Rows.Count; i++)
                {
                    int total = 0;
                    DataRow dataRow = GradeDataTable.NewRow();
                    string stud_id = studentDataTable.Rows[i]["student_id"].ToString();
                    dataRow["student_id"] = stud_id;
                    dataRow["student_name"] = studentDataTable.Rows[i]["name"];

                    var GradeDetail = objGrade.sp_Grade_master_Get_By_studnetid(stud_id, courseId);
                    if (GradeDetail.Rows.Count > 0)
                    {
                        for (int j = 0; j < GradeDetail.Rows.Count; j++)
                        {

                            string GradeMarks = GradeDetail.Rows[j]["grade"].ToString();


                            for (int k = 0; k < AssginMentdataTable.Rows.Count; k++)
                            {
                                string assid = AssginMentdataTable.Rows[k]["assignment_id"].ToString();
                                string gradeassid = GradeDetail.Rows[j]["assignment_id"].ToString();

                                if (assid == gradeassid)
                                {
                                    if (!string.IsNullOrWhiteSpace(GradeMarks))
                                    {
                                        int marks = Convert.ToInt32(GradeMarks);
                                        total = total + marks;
                                    }
                                    string assname = AssginMentdataTable.Rows[k]["name"].ToString();
                                    dataRow[assname] = GradeMarks;
                                }
                            }
                        }

                    }
                    if (total != 0)
                    {
                        dataRow["Avarage"] = total / AssginMentdataTable.Rows.Count;
                    }
                    else
                    {
                        dataRow["Avarage"] = 0;
                    }


                    GradeDataTable.Rows.Add(dataRow);
                    GradeDataTable.AcceptChanges();
                }
            }
            gv_gradetable.DataSource = GradeDataTable;
            gv_gradetable.DataBind();

            for (int i = 0; i < gv_gradetable.Rows.Count; i++)
            {
                for (int j = 2; j < (gv_gradetable.Columns.Count - 1); j++)
                {
                    TextBox textBox = new TextBox();
                    textBox.ID = "gradetextbox_" + i.ToString() + "_" + j.ToString();
                    if (string.IsNullOrWhiteSpace(gv_gradetable.Rows[i].Cells[j].Text) || gv_gradetable.Rows[i].Cells[j].Text == "&nbsp;")
                    {
                        textBox.Text = "0";
                    }
                    else
                    {
                        textBox.Text = gv_gradetable.Rows[i].Cells[j].Text;
                    }

                    textBox.AutoPostBack = true;
                    textBox.TextChanged += new EventHandler(gradeUpadted_TextChanged);
                    gv_gradetable.Rows[i].Cells[j].Controls.Add(textBox);
                }
            }


        }
        private void gradeUpadted_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var GreadeTextbox = (TextBox)sender;
                if (GreadeTextbox != null)
                {
                    string GreadeTextboxId = ((TextBox)sender).ID;
                    if (!string.IsNullOrWhiteSpace(GreadeTextboxId))
                    {
                        var ids = GreadeTextboxId.Split('_');
                        if (ids.Count() == 3)
                        {
                            int RowId = Convert.ToInt32(ids[1]);
                            int columnId = Convert.ToInt32(ids[2]);

                            string studentId = gv_gradetable.Rows[RowId].Cells[0].Text;
                            string AssignMentName = gv_gradetable.Columns[columnId].HeaderText;
                            string GradeMarks = GreadeTextbox.Text;
                            string courseid = Session["courseId"].ToString();

                            //

                            var GradeUpdate = objGrade.sp_grade_Update(courseid, AssignMentName, studentId, GradeMarks);
                            if (GradeUpdate != "-1")
                            {
                                gv_gradetable.Columns.Clear();
                                ReadGrade();
                            }
                            else
                            {
                                Response.Write("<script>alert('Grade not updated...!') </script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('Grade not updated...!') </script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('Grade not updated...!') </script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('Grade not updated...!') </script>");
                }
            }
            catch (Exception)
            {

                Response.Write("<script>alert('Grade not updated...!') </script>");
            }
        }
    }
}