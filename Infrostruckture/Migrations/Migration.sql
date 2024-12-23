create table Product 
(
    Id serial primary key,
Name varchar(50),
Description varchar(50),
Price decimal,
StockQuantity int,
CategoryName varchar(50),
CreatedDate date
);


insert into Product( Name, Description, Price, StockQuantity, CategoryName, CreatedDate) values ( @Name, @Description, @Price, @StockQuantity, @CategoryName, @CreatedDate);

select * from Product where Id=@Id;
update Product set Name=@Name, Description=@Description, Price=@Price, StockQuantity=@StockQuantity, CategoryName=@CategoryName, CreatedDate=@CreatedDate where Id=@Id;