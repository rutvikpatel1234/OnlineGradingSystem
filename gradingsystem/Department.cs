using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace gradingsystem
{
    public class Department
    {
        DBConnect db = new DBConnect();
        public int sp_department_master_addupdate(int department_id, String name)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_department_master_addupdate";

            SqlParameter inputParameter = new SqlParameter("@department_id", department_id);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.BigInt;
            //inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            inputParameter = new SqlParameter("@name", name);
            inputParameter.Direction = ParameterDirection.Input;
            inputParameter.SqlDbType = SqlDbType.NVarChar;
            inputParameter.Size = 50;
            dbCommand.Parameters.Add(inputParameter);

            var error = db.DoUpdateUsingCmdObj(dbCommand);
            return error;
        }

        public DataSet sp_department_master_get(int department_id)
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_department_master_get";

            SqlParameter param;
            //SqlDataAdapter adapter;

            param = new SqlParameter("@department_id", department_id);
            param.Direction = ParameterDirection.Input;
            param.SqlDbType = SqlDbType.BigInt;
            dbCommand.Parameters.Add(param);

            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);
            return myDS;

        }

        public DataSet sp_department_master_List()
        {
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            dbCommand.CommandText = "sp_department_master_List";


            DataSet myDS = db.GetDataSetUsingCmdObj(dbCommand);

            return myDS;

        }
    }
}