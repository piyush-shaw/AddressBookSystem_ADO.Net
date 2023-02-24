select * from AddressBook

--UC2 - SP to insert value to table
CREATE or alter PROCEDURE [dbo].[spInsertintoTable]
(
    @FirstName varchar(255),
	@LastName varchar(255),
	@Address varchar(255),
	@City varchar(255),
	@State varchar(255),
	@zip int,
	@PhoneNumber bigint,
	@Email varchar(255),
	@Book_Name varchar(200),
	@Contact_Type  varchar(200)
)
as
begin
	INSERT INTO AddressBook VALUES
	(
	 @FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email, @Book_Name, @Contact_Type
	 )
end
GO

-- SP for Get Contact
CREATE PROCEDURE [dbo].[SpGetContact]
@FirstName varchar(255)
AS
	SELECT  FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, Book_Name, Contact_Type FROM AddressBook WHERE FirstName = @FirstName;
RETURN 0

----UC3 - SP for Edit Contact---
CREATE PROCEDURE [dbo].[SpEditContact]
@name varchar(255),
@FirstName varchar(255),
	@LastName varchar(255),
	@Address varchar(255),
	@City varchar(255),
	@State varchar(255),
	@zip int,
	@PhoneNumber bigint,
	@Email varchar(255),
	@Book_Name varchar(200),
	@Contact_Type  varchar(200)
AS
	UPDATE AddressBook set FirstName = @FirstName, LastName =@LastName , Address = @Address, City =@City , State = @State, Zip =@Zip , PhoneNumber = @PhoneNumber, Email = @Email , Book_Name=@Book_Name , Contact_Type = @Contact_Type 
	Where FirstName = @name;
RETURN 0

-- UC-04 SP for Delete contact
CREATE PROCEDURE [dbo].[SplDeleteContact]
@name varchar(255)
AS
	DELETE FROM AddressBook 
	Where FirstName = @name
RETURN 0

--UC_05 - Retrieve contact using city
CREATE PROCEDURE [dbo].[SpRetrieveContact]
@City varchar(255)
AS
	SELECT FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, Book_Name, Contact_Type FROM AddressBook WHERE City = @City;
RETURN 0