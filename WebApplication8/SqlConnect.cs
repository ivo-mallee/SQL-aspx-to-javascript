using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace SqlConnections
{
	public class SqlConnect
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

		public string[,] ExecuteQuery(string Querry) 
		{
			System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings[connectionstring].ConnectionString);
			conn.Open();
			int RowAmount = 0;

			SqlCommand cmd = new SqlCommand(Querry, conn);
			System.Data.SqlClient.SqlDataReader SQLDATA = cmd.ExecuteReader();


			int CollumAmount = SQLDATA.FieldCount;


			System.Data.SqlClient.SqlDataReader AmountReader = SQLDATA;
			string COMB = "";
			while (true)
			{
				AmountReader.Read();
				try { AmountReader.GetValue(0); } catch { break; }
				RowAmount++;

				for (int COLLUM = 0; COLLUM < CollumAmount; COLLUM++)
				{
					COMB += SQLDATA.GetValue(COLLUM).ToString(); COMB += "|";
				}


			}

			string[,] OUTPUT = new string[RowAmount, CollumAmount];
			int TX = 0;
			for (int Y = 0; Y < RowAmount; Y++)
			{
				for (int X = 0; X < CollumAmount; X++)
				{
					while (true)
					{
						if (COMB[TX] == '|') { TX++; break; }
						OUTPUT[Y, X] += COMB[TX];

						TX++;
					}
				}
			}
			return OUTPUT;
		}



	}
}