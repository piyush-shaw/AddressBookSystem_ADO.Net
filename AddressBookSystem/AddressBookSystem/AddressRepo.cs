using System;
using System.Data.SqlClient;

namespace AddressBookSystem
{
	public class AddressRepo
	{
        //Give path for database connection
        public static string connectionString = "Server=127.0.0.1,1433;Database=AddressBookService;User Id=sa;Password=Valuetech@123";
        SqlConnection connection = new SqlConnection(connectionString);
        public bool InsertIntoTable(AddressModel addressBook)
        {
            try
            {
                using (this.connection)
                {
                    SqlCommand sqlCommand = new SqlCommand("spInsertintoTable", this.connection);
                    //setting command type as stored procedure
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@FirstName", addressBook.FirstName);
                    sqlCommand.Parameters.AddWithValue("@LastName", addressBook.LastName);
                    sqlCommand.Parameters.AddWithValue("@Address", addressBook.Address);
                    sqlCommand.Parameters.AddWithValue("@City", addressBook.City);
                    sqlCommand.Parameters.AddWithValue("@State", addressBook.State);
                    sqlCommand.Parameters.AddWithValue("@zip", addressBook.zip);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", addressBook.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Email", addressBook.Email);
                    sqlCommand.Parameters.AddWithValue("@Book_Name", addressBook.Book_Name);
                    sqlCommand.Parameters.AddWithValue("Contact_Type", addressBook.Contact_Type);
                    this.connection.Open();
                    //Return the number of rows updated
                    var result = sqlCommand.ExecuteNonQuery();
                    this.connection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.connection.Close();
            }
            return false;
        }
    }
}

