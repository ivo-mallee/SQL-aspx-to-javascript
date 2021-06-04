using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlConnections
{
	public class SqlConnection
	{
		public string connectionstring = "";
		public String ConvertToJava(string[] ARRAY)
		{
			string OUT = "[";
			for (int i = 0; i < ARRAY.Length; i++)
			{
				OUT += ARRAY[i].ToString();
				if (i != ARRAY.Length) { OUT += ','; }
			}
			OUT += "]";
			return OUT;
		}

		public string executequery(string Query, bool expectingreturn)
		{
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString);
			SqlCommand cmd = new SqlCommand(Query, conn);
			conn.Open();
			String returnedData = "NULL";
			if (expectingreturn == false) { cmd.ExecuteScalar(); } else { returnedData = cmd.ExecuteScalar().ToString(); }
			conn.Close();
			return returnedData;
		}

		public string[] GetSqlData(int length, string CollumName, string CounterName, string TableName)
		{
			string[] DATA = new string[length];
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString);
			conn.Open();

			for (int i = 0; i < DATA.Length; i++)
			{
				string quarycommand = "select " + CollumName + " from [dbo].[" + TableName + "] where " + CounterName + "=" + (i + 1).ToString();
				SqlCommand cmd = new SqlCommand(quarycommand, conn);
				DATA[i] = cmd.ExecuteScalar().ToString();
			}

			return DATA;
		}


	}
}