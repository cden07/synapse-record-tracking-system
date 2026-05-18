using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;


namespace synapse_record_tracking_system
{
	public static class DbConnectionHelper
	{
		public static string ConnectionString =>
			ConfigurationManager.ConnectionStrings["SynapseDB"].ConnectionString;

		public static MySqlConnection GetConnection() =>
			new MySqlConnection(ConnectionString);
	}
}
