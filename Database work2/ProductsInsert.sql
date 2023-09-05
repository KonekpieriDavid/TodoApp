


	INSERT INTO Products (ProductId, Picture, Title, Price, Description, InsertedBy, InsertDate)
VALUES (
    9,
    (SELECT BulkColumn FROM Openrowset( Bulk 'C:\Users\PCES\Desktop\Footer\img\apple.jpg', Single_Blob) as x),
    'Apple',
    5.00,
    'Apple Description',
    'David',
    '2023-08-21'
)