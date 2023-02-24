using System;
using System.Data;
using System.Data.SqlClient;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlDataReader = System.Data.SqlClient.SqlDataReader;

namespace AddressBookSystem
{
    public class AddressRepo
    {
        //Give path for database connection
        public static string connectionString = "Server=127.0.0.1,1433;Database=AddressBookService;User Id=sa;Password=Valuetech@123";
        SqlConnection connection = new SqlConnection(connectionString);

        //UC02 - To insert value in table
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

        public bool GetContact(string name)
        {
            try
            {
                AddressModel addressBook = new AddressModel();
                using (this.connection)
                {
                    string query = @"Select * from AddressBook;";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            addressBook.FirstName = Convert.ToString(dr["FirstName"]);
                            addressBook.LastName = Convert.ToString(dr["LastName"]);
                            addressBook.Address = Convert.ToString(dr["Address"] + " " + dr["City"] + " " + dr["State"] + " " + dr["zip"]);
                            addressBook.PhoneNumber = Convert.ToInt64(dr["PhoneNumber"]);
                            addressBook.Email = Convert.ToString(dr["Email"]);
                            addressBook.Book_Name = Convert.ToString(dr["Book_Name"]);
                            addressBook.Contact_Type = Convert.ToString(dr["ContactType"]);
                            Console.WriteLine("{0} | {1} | {2} | {3} | {4} | {5} | {6}", addressBook.FirstName, addressBook.LastName, addressBook.Address, addressBook.PhoneNumber, addressBook.Email, addressBook.Book_Name, addressBook.Contact_Type);
                            System.Console.WriteLine("\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        //UC03-edit contact of particular person
        public bool EditContact(string name, AddressModel contact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                int result;
                using (this.connection)
                {
                    string spName = "dbo.SpEditContact";
                    SqlCommand command = new SqlCommand(spName, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    command.Parameters.AddWithValue("@LastName", contact.LastName);
                    command.Parameters.AddWithValue("@Address", contact.Address);
                    command.Parameters.AddWithValue("@City", contact.City);
                    command.Parameters.AddWithValue("@State", contact.State);
                    command.Parameters.AddWithValue("@Zip", contact.zip);
                    command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@Book_Name", contact.Book_Name);
                    command.Parameters.AddWithValue("@Contact_Type", contact.Contact_Type);
                    connection.Open();
                    result = command.ExecuteNonQuery();
                }
                return result == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        //UC4 - Delete Contact using their name
        public bool DeletePersonBasedonName()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (this.connection)
                {
                    string query = "delete from AddressBook where FirstName = 'Shubham' and LastName = 'Shaw'";
                    //Pass query to TSql
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.StoredProcedure;
                    string spName = "dbo.SplDeleteContact";
                    SqlCommand command1 = new SqlCommand(spName, connection);
                    int result = command.ExecuteNonQuery();
                    if (result != 0)
                    {
                        Console.WriteLine("Updated!");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated!");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        //UC 5 - To Retrieve Person belonging to a City or State from the Address Book
        public string PrintDataBasedOnCity(string city, string State)
        {
            string nameList = "";
            //query to be executed
            string query = @"select * from AddressBook where City =" + "'" + city + "' or State=" + "'" + State + "'";
            SqlCommand command = new SqlCommand(query, this.connection);
            connection.Open();
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    nameList += sqlDataReader["FirstName"].ToString() + " ";
                }
            }
            return nameList;
        }
    }
}

