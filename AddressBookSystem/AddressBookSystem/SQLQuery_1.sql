select * from AddressBook

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
