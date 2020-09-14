using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public class Grade
    {
        DBConnect db = new DBConnect();

        public String sp_grade_master_addupdate(int grade_id, int assignment_id, int student_course_id, int grade)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_grade_master_addupdate";

            SqlParameter inputParameter = new SqlParameter("@grade_id", grade_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@assignment_id", assignment_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@student_course_id", student_course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@grade", grade);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.Decimal;
            dbCommand.Parameters.Add(inputParameter);

            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error.ToString();
        }

        public DataSet sp_grade_master_get(int grade_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_grade_master_get";

            SqlParameter param;

            param = new SqlParameter("@grade_id", grade_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            return myDS;
        }

        public DataSet sp_grade_master_List()
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_grade_master_List";


            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }

        public DataTable sp_Grade_master_Get_By_studnetid(string studentId, string course_id)
        {
            DataTable dataTable = new DataTable();
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_Grade_master_Get_By_studnetid";

            SqlParameter param;
            SqlParameter inputParameter = new SqlParameter("@studentId", studentId);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);
            param = new SqlParameter("@course_id", course_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);
            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            dataTable = myDS.Tables[0];
            return dataTable;
        }

        public String sp_grade_Update(string courseid, string assignment_name, string student__id, string grade)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_grade_Update";

            SqlParameter inputParameter = new SqlParameter("@stu_id", student__id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@ass_name", assignment_name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@course_id", courseid);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@grade", grade);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);



            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error.ToString();
        }
    }
}