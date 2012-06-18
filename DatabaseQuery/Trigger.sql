USE thanglongsport_VietGap
GO
SET dateformat dmy
go


--Trigger thêm vào tblDangkyhoatdongchungnhan khi them bản ghi vào tblTochucchungnhan
if(OBJECT_ID('tg_tblTochucchungnhan_InsertTblDangkyhoatdongchungnhan','TR') is not null)
begin
	drop trigger tg_tblTochucchungnhan_InsertTblDangkyhoatdongchungnhan
end
GO
CREATE trigger tg_tblTochucchungnhan_InsertTblDangkyhoatdongchungnhan
on tblTochucchungnhan
for insert
as
	declare @PK_iTochucchungnhanID int
	begin
		select @PK_iTochucchungnhanID=PK_iTochucchungnhanID FROM INSERTED
		insert INTO tblDangkyHoatdongchungnhan(FK_iTochucchungnhanID,iTrangthaidangky)
		VALUES(@PK_iTochucchungnhanID, 0)
	end