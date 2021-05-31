using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication8
{
	public partial class _default : System.Web.UI.Page
	{
		public string EUROPE;
		public string AMERICA;
		public string DATES;

		static string[] europa;
		static string[] america;
		static string[] dates;
		protected void Page_Load(object sender, EventArgs e)
		{
			europa = GetSqlData(22, "DATA2", "Counter","data");
			america = GetSqlData(22, "DATA1", "Counter","data");
			dates =  GetSqlData(22, "Date", "Counter", "data");

			EUROPE = ConvertToJava(europa);
			AMERICA = ConvertToJava(america);
			DATES = ConvertToJava(dates);
		}


		String ConvertToJava(string[] ARRAY) 
		{
			string OUT = "[";
			for (int i=0; i< ARRAY.Length;i++) 
			{
				OUT += ARRAY[i].ToString();
				if (i != ARRAY.Length) { OUT += ','; }
			}
			OUT += "]";
			return OUT;
		}

		static string[] GetSqlData(int length,string CollumName, string CounterName, string TableName)
		{
			string[] DATA = new string[length];
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["RegiConnectionString"].ConnectionString);
			conn.Open();

			for (int i = 0; i < DATA.Length; i++)
			{
				string quarycommand = "select " + CollumName + " from [dbo].["+ TableName + "] where " + CounterName + "=" + (i + 1).ToString();
				SqlCommand cmd = new SqlCommand(quarycommand, conn);
				DATA[i] = cmd.ExecuteScalar().ToString();
			}

			return DATA;
		}

	}
}