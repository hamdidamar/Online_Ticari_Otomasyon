create trigger UpdateStockOnSale
on Orders
after insert
as
declare @productId int
declare @amount int 
select @productId = ProductId,@amount =Amount from inserted
update Products set Stock-=@amount where ProductId = @productId