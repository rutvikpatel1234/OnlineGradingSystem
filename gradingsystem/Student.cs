using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public class Student
    {
        DBConnect db = new DBConnect();
        public String sp_student_master_addupdate(int student_id, String name, String email, string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_master_addupdate";

            SqlParameter inputParameter = new SqlParameter("@student_id", student_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@name", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@email", email);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error.ToString();


        }
        public DataSet sp_student_master_get(int student_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_master_get";

            SqlParameter param;

            param = new SqlParameter("@student_id", student_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            return myDS;
        }
        public DataSet sp_student_master_List()
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_master_List";


            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }
        public DataSet sp_student_course_master_get_and_course(string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_course_master_get_and_course";
            SqlParameter inputParameter = new SqlParameter();

            inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }
        public string sp_student_course_master_remove(string student_course_id, string student_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_course_master_remove";
            SqlParameter inputParameter = new SqlParameter();

            inputParameter = new SqlParameter("@student_course_id", student_course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@student_id", student_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            int response = db.DoUpdateUsingCmdObj(dbCommand);
            return response.ToString();

        }
        public DataSet sp_student_master_student_course_grade_master_get(string SMSCGM_ID)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_student_master_student_course_grade_master_get";
            SqlParameter inputParameter = new SqlParameter();

            inputParameter = new SqlParameter("@course_id", SMSCGM_ID);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }
    }
}