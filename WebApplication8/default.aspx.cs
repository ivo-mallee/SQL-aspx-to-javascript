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
		public string HTMLDATA = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			SqlConnect server = new SqlConnect();
			server.connectionstring = "MedischeDatabase";
			string [,] DATA = server.ExecuteQuery("select TOP (500) * from [V_Equipment_Contract]");
			int RowCount = DATA.GetLength(0);
			int CollumCount = DATA.GetLength(1);
			for (int Y=0; Y< RowCount; Y++)
			{
				HTMLDATA += "<tr>";
				for (int X =2; X<CollumCount; X++) 
				{
					HTMLDATA += "<td class='" + DATA[Y, X]  + "'> " + DATA[Y, X] + " </td>";
				}
				HTMLDATA += "</tr> \n";
			}









		}
	}
}