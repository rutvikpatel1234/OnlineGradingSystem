using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public class Course
    {
        DBConnect db = new DBConnect();

        public int sp_course_master_addupdate(int course_id, String course_name, string department, string professor_id, String semesters, String image_url, String title)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_course_master_addupdate";

            SqlParameter inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@course_name", course_name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@professor_id", professor_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@department", department);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            dbCommand.Parameters.Add(inputParameter);


            inputParameter = new SqlParameter("@semesters", semesters);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@image_url", image_url);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@title", title);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            dbCommand.Parameters.Add(inputParameter);



            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error;

        }

        public DataSet sp_course_master_get(int course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_course_master_get";

            SqlParameter param;

            param = new SqlParameter("@course_id", course_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            return myDS;

        }

        public DataSet sp_course_master_List(string user_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_course_master_List";

            SqlParameter param;

            param = new SqlParameter("@user_id", user_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;

        }

        public string sp_course_master_Delete(string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_course_master_Delete";

            SqlParameter inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            int response = db.DoUpdateUsingCmdObj(dbCommand);
            return response.ToString();

        }
    }
}