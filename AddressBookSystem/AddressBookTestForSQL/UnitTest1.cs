using System.Net;
using AddressBookSystem;
using Microsoft.IdentityModel.Tokens;

namespace AddressBookTestForSQL;

[TestClass]
public class UnitTest1
{
   //UC 2: To insert value in table
    [TestMethod]
    public void TestMethod1()
    {
        AddressRepo repo = new AddressRepo();
        AddressModel address = new AddressModel();
        address.FirstName = "Shubham";
        address.LastName = "Shaw";
        address.Address = "13 MG Road"; 
        address.City = "Kolkata";
        address.State = "WestBengal";
        address.zip = 769872;
        address.PhoneNumber = 9090876789;
        address.Email = "shubham@gmail.com";
        address.Book_Name = "Lawyer";
        address.Contact_Type = "Profession";
        var result = repo.InsertIntoTable(address);
        Assert.IsTrue(result);
    }

    //UC 3: Modify Existing Contact using their name
    [TestMethod]
    public void GivenUpdateQueryReturnOne()
    {
        AddressRepo repo = new AddressRepo();    
        AddressModel contact = new AddressModel();
        bool result = repo.EditContact("Piyush",contact);
        Assert.IsTrue(result);
    }

    //UC 4: Delete person based on Name
    [TestMethod]
    public void DeletePersonBasedonName()
    {
        AddressRepo repo = new AddressRepo();
        var result = repo.DeletePersonBasedonName();
        Assert.IsTrue(result);
    }

    //UC 5: To Retrieve Person belonging to a City or State from the Address Book
    [TestMethod]
    public void GivenRetrieveQuery_ReturnString()
    {
        AddressRepo repo = new AddressRepo();
        string expected = "";
        string actual = repo.PrintDataBasedOnCity("Raipur", "Chattisgarh");
        Assert.AreEqual(expected, actual);
    }

    //UC 6 : Retrieve Count Person By City Or State
    [TestMethod]
    [DataRow("Found The Record SuccessFully")]
    public void GivenCountQuery_ReturnString(string expected)
    {
        var actual = AddressRepo.PrintCountByCityandState();
        Assert.AreEqual(expected, actual);
    }

    //UC 7: Testing the sort contact by persons name to check if data is found or not
    [TestMethod]
    [DataRow("WestBengal", "Found The Record SuccessFully")]
    [DataRow("Jharkhand", "Found The Record SuccessFully")]
    [DataRow("Pondicherry", "No Record Found")]
    public void GivenOrderByQueryReturnResult(string city, string expected)
    {
        var actual = AddressRepo.GetSortedCityContactByName(city);
        Assert.AreEqual(expected, actual);
    }

    //UC 8: Testing the count contact by contact type to check if data is found or not
    [TestMethod]
    [DataRow("Found The Record SuccessFully")]
    public void GivenCountByTypeQueryReturnResult(string expected)
    {
        var actual = AddressRepo.GetCountByContactType();
        Assert.AreEqual(expected, actual);
    }
}
