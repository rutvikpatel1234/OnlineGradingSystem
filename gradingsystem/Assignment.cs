using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public class AssignmentDB
    {
        DBConnect db = new DBConnect();

        public int sp_assignment_master_addupdate(int assignment_id, String name, string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_assignment_master_addupdate";

            SqlParameter inputParameter = new SqlParameter("@assignment_id", assignment_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@name", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error;

        }

        public DataSet sp_assignment_master_get(string assignment_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_assignment_master_get";

            SqlParameter param;

            param = new SqlParameter("@assignment_id", assignment_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            return myDS;

        }

        public DataSet sp_assignment_master_List(string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_assignment_master_List";

            SqlParameter inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }

        public string sp_assignment_master_delete(string assignment_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_assignment_master_delete";

            SqlParameter inputParameter = new SqlParameter("@assignment_id", assignment_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            int response = db.DoUpdateUsingCmdObj(dbCommand);
            return response.ToString();

        }

        public DataSet sp_assignment_get_name(string assignemnt_name, string course_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_assignment_get_name";


            SqlParameter inputParameter = new SqlParameter("@assignemnt_name", assignemnt_name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@course_id", course_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(inputParameter);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;
        }
    }
}