CREATE TABLE CustomerTable (
      CustomerId INT IDENTITY(1,1) PRIMARY KEY,
	 CustomerName VARCHAR(50),
	 TeleUserId VARCHAR(50),
     PhoneNumber VARCHAR(20),
    
);

CREATE TABLE AirtimePurchase(
   PurchaseId  INT ,
   CustomerId INT IDENTITY(1,1) ,
   TeleUserId VARCHAR (50), 
   PhoneNumber  VARCHAR(50),
   Amount Decimal(10,2),
   PurchaseDate DateTime,
   CONSTRAINT FK_AirtimePurchase_CustomerTable FOREIGN KEY (CustomerId) REFERENCES CustomerTable(CustomerId)
);
 DROP Table AirtimePurchase