using System;
using System.Data.SqlClient;

namespace AddressBookSystem
{
	public class AddressRepo
	{
        public static string connectionString = "Server=127.0.0.1,1433;Database=Payroll;User Id=sa;Password=Valuetech@123";
        SqlConnection connection = new SqlConnection(connectionString);
    }
}

