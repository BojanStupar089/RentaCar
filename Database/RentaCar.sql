

use RentaCar;


Create Table Cars(

CarId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Manufacturer nvarchar(50) NOT NULL,
Model nvarchar(50) NOT NULL,
LicensePlate nvarchar(9) NOT NULL,
Year int ,
Available bit


)


Create Table Customers(

   CustomerId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
   Name nvarchar(50) NOT NULL,
   DriverLicNo int NOT NULL
)


Create Table Rentals(

RentalId int IDENTITY(1,1) NOT NULL PRIMARY KEY,
CustomerId int FOREIGN KEY REFERENCES Customers(CustomerId) ON DELETE NO ACTION ON UPDATE NO ACTION,
CarId int FOREIGN KEY REFERENCES Cars(CarId) ON DELETE NO ACTION ON UPDATE NO ACTION,
DateRented datetime,
DateReturned datetime
)



Create Index IX_FK_Rentals_Cars on Rentals(CarId);
Create Index IX_FK_Rentals_Customers on Rentals(CustomerId);