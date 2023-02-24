using AddressBookSystem;

namespace AddressBookTestForSQL;

[TestClass]
public class UnitTest1
{
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
}
