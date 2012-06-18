USE thanglongsport_VietGap
GO
SET dateformat dmy
go


--/*sp lấy danh sách chỉ tiêu
if(OBJECT_ID('sp_tblCoconuoitrong_GetAllByUserID','p') is not null)
begin
	drop proc sp_tblCoconuoitrong_GetAllByUserID
end
GO
CREATE proc sp_tblCoconuoitrong_GetAllByUserID
	@FK_iUserID int
as
begin
	select * FROM dbo.tblCosonuoitrong WHERE FK_iUserID = @FK_iUserID
END
GO

--EXEC sp_tblCoconuoitrong_GetAllByUserID 4
--go


--/*sp kiểm tra sự tồn tại của dánh giá kết quả theo ID cơ sở nuôi trồng
if(OBJECT_ID('sp_tblDanhgiaketqua_CheckAvaiableByFK_Csnt','p') is not null)
begin
	drop proc sp_tblDanhgiaketqua_CheckAvaiableByFK_Csnt
end
GO
CREATE proc sp_tblDanhgiaketqua_CheckAvaiableByFK_Csnt
	@FK_iCosonuoitrongID int
as
begin
	select top 1 * FROM tblDanhgiaketqua WHERE FK_iCosonuoiID = @FK_iCosonuoitrongID
END
GO

--EXEC sp_tblDanhgiaketqua_CheckAvaiableByFK_Csnt 2
--go

--/*sp đếm số kết quả đạt
if(OBJECT_ID('sp_tblDanhgiaketqua_CountTrue','p') is not null)
begin
	drop proc sp_tblDanhgiaketqua_CountTrue
end
GO
CREATE proc sp_tblDanhgiaketqua_CountTrue
	@FK_iCosonuoitrongID int
as
begin
	select *
	FROM tblDanhgiaketqua 
	WHERE FK_iCosonuoiID = @FK_iCosonuoitrongID AND iKetqua = 1
END
GO

--EXEC sp_tblDanhgiaketqua_CountTrue 2
--go

--/*sp xóa toàn bộ kết quả đánh giá theo ID cơ sở nuôi trồng
if(OBJECT_ID('sp_tblDanhgiaketqua_DellByCosonuoitrong','p') is not null)
begin
	drop proc sp_tblDanhgiaketqua_DellByCosonuoitrong
end
GO
CREATE proc sp_tblDanhgiaketqua_DellByCosonuoitrong
	@FK_iCosonuoitrongID int
as
begin
	delete FROM tblDanhgiaketqua WHERE FK_iCosonuoiID = @FK_iCosonuoitrongID
END
GO

--EXEC sp_tblDanhgiaketqua_DellByCosonuoitrong 2
--go



--/*sp tìm Danhgiaketqua theo ID cơ sở nuôi trồng và ID chỉ tiêu
if(OBJECT_ID('sp_tblDanhgiaketqua_GetOneByCosoAndChitieu','p') is not null)
begin
	drop proc sp_tblDanhgiaketqua_GetOneByCosoAndChitieu
end
GO
CREATE proc sp_tblDanhgiaketqua_GetOneByCosoAndChitieu
	@FK_iCosonuoitrongID int, @FK_iChitieuID int
as
begin
	select * FROM tblDanhgiaketqua
	WHERE FK_iCosonuoiID = @FK_iCosonuoitrongID AND FK_iChitieuID = @FK_iChitieuID
END
GO

--EXEC sp_tblDanhgiaketqua_GetOneByCosoAndChitieu 2, 3
--go



--/*sp Kiểm tra user hiện tại đã đăng ký Tổ chức chứng nhận chưa
if(OBJECT_ID('sp_tblTochucchungnhan_CheckByUserID','p') is not null)
begin
	drop proc sp_tblTochucchungnhan_CheckByUserID
end
GO
CREATE proc sp_tblTochucchungnhan_CheckByUserID
	@PK_iUserID int
as
begin
	select * FROM tblTochucchungnhan
	WHERE FK_iUserID = @PK_iUserID
END
GO

--EXEC sp_tblTochucchungnhan_CheckByUserID 2
--go

--/*sp Lấy  danh sách hồ sơ kèm theo theo người dùng
if(OBJECT_ID('sp_tblHosokemtheoTochucchungnhan_GetAllByUserID','p') is not null)
begin
	drop proc sp_tblHosokemtheoTochucchungnhan_GetAllByUserID
end
GO
CREATE proc sp_tblHosokemtheoTochucchungnhan_GetAllByUserID
	@PK_iUserID int
as
begin
	select * FROM tblHosokemtheoTochucchungnhan 
	WHERE FK_iDangkyChungnhanVietGapID IN(SELECT PK_iDangkyChungnhanVietGapID as FK_iDangkyChungnhanVietGapID FROM tblDangkyHoatdongchungnhan 
	WHERE FK_iTochucchungnhanID IN(SELECT PK_iTochucchungnhanID as FK_iTochucchungnhanID FROM tblTochucchungnhan
	WHERE FK_iUserID = @PK_iUserID))
END
GO

--EXEC sp_tblHosokemtheoTochucchungnhan_GetAllByUserID 7
--go


--/*sp Lấy tọa độ cơ sở nuôi trồng theo huyện
if(OBJECT_ID('sp_tblToadoCosonuoitrong_GetTheoHuyen','p') is not null)
begin
	drop proc sp_tblToadoCosonuoitrong_GetTheoHuyen
end
GO
CREATE proc sp_tblToadoCosonuoitrong_GetTheoHuyen
	@PK_iQuanHuyenID int
as
begin
	SELECT     dbo.tblCosonuoitrong.PK_iCosonuoitrongID, tblToadoCosonuoi.sLat, tblToadoCosonuoi.sLon, dbo.tblCosonuoitrong.sMaso_vietgap, dbo.tblCosonuoitrong.sTencoso, 
                      dbo.tblCosonuoitrong.fTongdientich, dbo.tblDoituongnuoi.sTendoituong, CONVERT(VARCHAR(10), tblMasovietgap.dNgaycap, 103) as dNgaycap, dbo.tblCosonuoitrong.sSodoaonuoi
FROM         dbo.tblCosonuoitrong INNER JOIN
                      tblToadoCosonuoi ON dbo.tblCosonuoitrong.PK_iCosonuoitrongID = tblToadoCosonuoi.FK_iCosonuoiID LEFT JOIN
                      tblMasovietgap ON dbo.tblCosonuoitrong.PK_iCosonuoitrongID = tblMasovietgap.FK_iCosonuoitrongID LEFT JOIN
                      dbo.tblDoituongnuoi ON dbo.tblCosonuoitrong.FK_iDoituongnuoiID = dbo.tblDoituongnuoi.PK_iDoituongnuoiID
             WHERE dbo.tblCosonuoitrong.FK_iQuanHuyenID = @PK_iQuanHuyenID
    ORDER BY dbo.tblCosonuoitrong.PK_iCosonuoitrongID
END
GO

--EXEC sp_tblToadoCosonuoitrong_GetTheoHuyen 108
SELECT * FROM dbo.tblCosonuoitrong
SELECT * FROM dbo.tblCosonuoitrong
SELECT * FROM tblMasovietgap

--/*sp Lấy tọa độ cơ sở nuôi trồng cả nước
if(OBJECT_ID('sp_tblToadoCosonuoitrong_Getall','p') is not null)
begin
	drop proc sp_tblToadoCosonuoitrong_Getall
end
GO
CREATE proc sp_tblToadoCosonuoitrong_Getall
as
begin
	SELECT     dbo.tblCosonuoitrong.PK_iCosonuoitrongID, tblToadoCosonuoi.sLat, tblToadoCosonuoi.sLon, dbo.tblCosonuoitrong.sMaso_vietgap, dbo.tblCosonuoitrong.sTencoso, 
                      dbo.tblCosonuoitrong.fTongdientich, dbo.tblDoituongnuoi.sTendoituong, CONVERT(VARCHAR(10), tblMasovietgap.dNgaycap, 103) as dNgaycap, dbo.tblCosonuoitrong.sSodoaonuoi
FROM         dbo.tblCosonuoitrong INNER JOIN
                      tblToadoCosonuoi ON dbo.tblCosonuoitrong.PK_iCosonuoitrongID = tblToadoCosonuoi.FK_iCosonuoiID LEFT JOIN
                      tblMasovietgap ON dbo.tblCosonuoitrong.PK_iCosonuoitrongID = tblMasovietgap.FK_iCosonuoitrongID INNER JOIN
                      dbo.tblDoituongnuoi ON dbo.tblCosonuoitrong.FK_iDoituongnuoiID = dbo.tblDoituongnuoi.PK_iDoituongnuoiID AND 
                      dbo.tblCosonuoitrong.FK_iDoituongnuoiID = dbo.tblDoituongnuoi.PK_iDoituongnuoiID
    ORDER BY dbo.tblCosonuoitrong.PK_iCosonuoitrongID
END
GO

EXEC sp_tblToadoCosonuoitrong_Getall