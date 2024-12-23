create table Products
(
    Id serial primary key,
Name varchar(50),
Description varchar(50),
Price decimal,
StockQuantity int,
CategoryName varchar(50),
CreatedDate date
);


insert into Products( Name, Description, Price, StockQuantity, CategoryName, CreatedDate) values ( @Name, @Description, @Price, @StockQuantity, @CategoryName, @CreatedDate);

select * from Products where Id=@Id;
update Products set Name=@Name, Description=@Description, Price=@Price, StockQuantity=@StockQuantity, CategoryName=@CategoryName, CreatedDate=@CreatedDate where Id=@Id;