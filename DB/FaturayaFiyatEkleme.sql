create trigger AddPriceToInvoice 
on InvoiceRows after insert 
as
declare @invoiceId int 
declare @total decimal(18,2)
select @invoiceId=InvoiceId,@total=Total from inserted
update Invoices set Total +=@total where InvoiceId = @invoiceId