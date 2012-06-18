use thanglongsport_VietGap
go
-- =============================================
-- Tao bang
-- =============================================

---Bảng danh mục chỉ tiêu
IF(OBJECT_ID('tblDanhmucchitieu','U') is not null)
BEGIN 
	DROP TABLE tblDanhmucchitieu
END
CREATE TABLE tblDanhmucchitieu
(
	PK_iDanhmucchitieuID int identity primary key,
	sTenchuyenmuc nvarchar(100) not null,
	iThutu smallint
)
GO

---Bảng mức độ
IF(OBJECT_ID('tblMucdo','U') is not null)
BEGIN 
	DROP TABLE tblMucdo
END
CREATE TABLE tblMucdo
(
	PK_iMucdoID int identity primary key,
	sTenmucdo varchar(10) not null
)

---Bảng phương pháp kiểm tra
IF(OBJECT_ID('tblPhuongphapkiemtra','U') is not null)
BEGIN 
	DROP TABLE tblPhuongphapkiemtra
END
CREATE TABLE tblPhuongphapkiemtra
(
	PK_iPhuongphapkiemtraID int identity primary key,
	sTenphuongphapkiemtra nvarchar(100)
)

---Bảng chỉ tiêu
IF(OBJECT_ID('tblChitieu','U') is not null)
BEGIN 
	DROP TABLE tblChitieu
END
CREATE TABLE tblChitieu
(
	PK_iChitieuID int identity primary key,
	sNoidung ntext not null,
	sYeucauvietgap ntext,
	iThuthu smallint,
	FK_iMucdoID int references tblMucdo(PK_iMucdoID) not null,
	FK_iPhuongphapkiemtraID int references tblPhuongphapkiemtra(PK_iPhuongphapkiemtraID),
	iKetqua smallint,
	sGhichu ntext
)
GO



---Bảng Đánh giá tổ chức chứng nhận
IF(OBJECT_ID('tblDanhgiatochucchungnhan','U') is not null)
BEGIN 
	DROP TABLE tblDanhgiatochucchungnhan
END
CREATE TABLE tblDanhgiatochucchungnhan
(
	PK_iDanhgiatochucchungnhanID int identity primary key,
	sPhamvinghidinh ntext not null,
	tGiodanhgia datetime not null,
	dNgaydanhgia datetime not null,
	sCancudanhgia ntext not null,
	sNoidungdanhgia ntext not null,
	sKetquadanhgia ntext not null,
	iKetquadanhgia smallint not null,
	sKiennghi ntext,
	FK_iTochucchungnhanID int references tblTochucchungnhan(PK_iTochucchungnhanID) not null,
	FK_iTruongdoandanhgiaID int references tblDanhgiavien(PK_iDanhgiavienID) not null
)
GO

---Bảng Đoàn đánh giá tổ chức chứng nhận
IF(OBJECT_ID('tblDoandanhgiatochucchungnhan','U') is not null)
BEGIN 
	DROP TABLE tblDoandanhgiatochucchungnhan
END
CREATE TABLE tblDoandanhgiatochucchungnhan
(
	PK_iDoandanhgiatochucchungnhanID int identity primary key,
	FK_iDanhgiatochucchungnhanID int references tblDanhgiatochucchungnhan(PK_iDanhgiatochucchungnhanID) not null,
	FK_iDanhgiavienID int references tblDanhgiavien(PK_iDanhgiavienID) not null
)



