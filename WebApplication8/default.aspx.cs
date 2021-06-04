using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SqlConnections;

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
			SqlConnections.SqlConnection SERVER1 = new SqlConnections.SqlConnection();
			SERVER1.connectionstring = "RegiConnectionString";

			for (int i=0; i<1000; i++) {
				int DATE = 2000 + (i * 10);
				SERVER1.executequery("INSERT INTO DATA(DATA1, Date,DATA2)VALUES(" + i +", " + DATE.ToString() + "," + (1000-i) +");",false); 
			}

			europa = SERVER1.GetSqlData(500, "DATA2", "Counter","data");
			america = SERVER1.GetSqlData(500, "DATA1", "Counter","data");
			dates = SERVER1.GetSqlData(500, "Date", "Counter", "data");
			EUROPE = SERVER1.ConvertToJava(europa);
			AMERICA = SERVER1.ConvertToJava(america);
			DATES = SERVER1.ConvertToJava(dates);
			











		}
	}
}