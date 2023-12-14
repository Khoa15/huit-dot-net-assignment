use master;
go

create database TaiLieuSo;
go

USE TaiLieuSo;
GO

-- Tạo bảng Folder với ràng buộc
CREATE TABLE Folder (
    id INT IDENTITY(1,1),
    name_id NVARCHAR(10) NOT NULL UNIQUE,
    name NVARCHAR(255) NOT NULL,
    created_by NVARCHAR(255),
    parent_id INT NULL,
	status BIT DEFAULT(0),
    created_date DATE,
    CONSTRAINT CHK_Folder_CreatedDate CHECK (created_date <= GETDATE()),
	CONSTRAINT PK_Folder PRIMARY KEY (id),	
    CONSTRAINT FK_Folder_Parent FOREIGN KEY (parent_id) REFERENCES Folder(id)
);
GO

-- Tạo bảng UserAccess với ràng buộc
CREATE TABLE UserAccess (
    patron_type_id char(10) NOT NULL,
    page_read INT NOT NULL DEFAULT(0),
    page_download INT NOT NULL DEFAULT(0),
    display BIT NOT NULL DEFAULT(0),
    read_limit BIT NOT NULL DEFAULT(0),
    read_full BIT NOT NULL DEFAULT(0),
    download BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_UserAccess PRIMARY KEY (patron_type_id)
);
GO

-- Create the Author table
--CREATE TABLE Author (
--    id INT IDENTITY(1,1) NOT NULL,
--    name NVARCHAR(255) NOT NULL,
--    email NVARCHAR(255),
--    phone NVARCHAR(20),
--    description NVARCHAR(1000),
--    --CONSTRAINT CHK_Author_Email CHECK (LEN(email) <= 255),
--    CONSTRAINT CHK_Author_Phone CHECK (LEN(phone) = 10),
--	CONSTRAINT PK_Author_AuthorID PRIMARY KEY (id)
--);
--GO

-- Tạo bảng Document với ràng buộc
CREATE TABLE Document (
    id INT IDENTITY(1,1) NOT NULL,--
    folder_id INT NULL,--
    author NVARCHAR(255) NULL,--
    title NVARCHAR(255) NOT NULL,--
    ItemTypeID CHAR(10),
    file_path VARCHAR(255),--
    link_to_image VARCHAR(255) NULL,--
    description NTEXT NULL,--
    document_status BIT,--
	updated_by NVARCHAR(255) DEFAULT('admin') NOT NULL,
    created_date DATE DEFAULT(GETDATE()),--
	updated_date DATE DEFAULT(GETDATE()),---
    CONSTRAINT CHK_Document_CreatedDate CHECK (created_date <= GETDATE()),
	CONSTRAINT PK_Document PRIMARY KEY (id),
    CONSTRAINT FK_Document_Folder FOREIGN KEY (folder_id) REFERENCES Folder(id) ON DELETE CASCADE,
);
GO
	
-- Create the DocumentIndex table
CREATE TABLE DocumentIndex (
    index_id INT IDENTITY(1,1),
    document_id INT NOT NULL,
    page_number INT,
    parent_index_id INT NULL,
    author NVARCHAR(255) NULL,
    title NVARCHAR(255),
	CONSTRAINT PK_DocumentIndex PRIMARY KEY (index_id),
	CONSTRAINT FK_DocumentIndex_DocumentID FOREIGN KEY (document_id) REFERENCES Document(id),
	CONSTRAINT FK_DocumentIndex_ParentIndexID FOREIGN KEY (parent_index_id) REFERENCES DocumentIndex(index_id),
);
GO

--CREATE TABLE DocumentAuthor(
--	document_id INT,
--	author_id INT,
--	CONSTRAINT PK_DocumentAuthor PRIMARY KEY (document_id, author_id),
--	CONSTRAINT FK_DocumentAuthor_Author FOREIGN KEY(author_id) REFERENCES Author(id),
--	CONSTRAINT FK_DocumentAuthor_Document FOREIGN KEY(document_id) REFERENCES Document(id),
--);
GO

--Tạo Trigger cho email
--CREATE TRIGGER CheckValidEmail
--ON Author
--AFTER INSERT, UPDATE
--AS
--BEGIN
--  IF EXISTS (
--      SELECT 1
--      FROM inserted
--      WHERE email NOT LIKE '%@%.%'
--  )
--  BEGIN
--    THROW 50000, 'Email address is not valid. Please enter a valid email address.', 0;
--  END
--END
--GO


--DISABLE TRIGGER CheckValidEmail ON Author;
--DROP TRIGGER CheckValidEmail ON Author;
--DROP TRIGGER CheckValidEmail ON DATABASE
--GO
-- Tạo trigger cho bảng Document
CREATE TRIGGER Document_BI
ON Document
AFTER INSERT
AS
BEGIN
    -- Thêm default value cho trường created_date và document_status
    -- Sử dụng getdate() cho created_date và 0 cho document_status
    UPDATE Document
    SET created_date = GETDATE(),
        updated_date = GETDATE(),
        document_status = 0
    WHERE id IN (SELECT id FROM inserted);
END;
GO

-- Tạo trigger cho bảng DocumentIndex
CREATE TRIGGER DocumentIndex_BI
ON DocumentIndex
AFTER INSERT
AS
BEGIN
    -- Thêm default value cho trường page_number
    -- Nếu như trường này không được cung cấp khi chèn bản ghi mới 
    UPDATE DocumentIndex
    SET page_number = 0
    WHERE index_id IN (SELECT index_id FROM inserted);
END;
GO


-- Tạo trigger cho bảng Folder
CREATE TRIGGER Folder_BIU
ON Folder
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra và cập nhật các trường mặc định sau khi chèn hoặc cập nhật
    IF UPDATE(created_date) OR UPDATE(created_by)
    BEGIN
        UPDATE Folder
        SET created_date = COALESCE(i.created_date, GETDATE()),
            created_by = COALESCE(i.created_by, SUSER_NAME())
        FROM Folder AS f
        JOIN inserted AS i ON f.id = i.id;
    END;
END;
GO

-- Tạo trigger cho bảng Document
CREATE TRIGGER Document_BIU
ON Document
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra và cập nhật các trường mặc định sau khi chèn hoặc cập nhật
    IF UPDATE(created_date) OR UPDATE(document_status)
    BEGIN
        UPDATE Document
        SET created_date = COALESCE(i.created_date, GETDATE()),
            document_status = COALESCE(i.document_status, 0)
        FROM Document AS d
        JOIN inserted AS i ON d.id = i.id;
    END;
END;
GO

-- Tạo trigger cho bảng DocumentIndex
CREATE TRIGGER DocumentIndex_BIU
ON DocumentIndex
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra và cập nhật trường page_number sau khi chèn hoặc cập nhật
    IF UPDATE(page_number)
    BEGIN
        UPDATE DocumentIndex
        SET page_number = COALESCE(i.page_number, 0)
        FROM DocumentIndex AS di
        JOIN inserted AS i ON di.index_id = i.index_id;
    END;
END;
GO


--select * from Author

--INSERT INTO Author (name, email, phone, description)
--VALUES 
--(N'Nguyễn Nhật Ánh', 'nhatanh@gmail.com', '0987654321', N'Tác giả của cuốn sách "Cho tôi xin một vé đi tuổi thơ".'),
--(N'Trần Thị Rò', 'thiro@gmail.com', '0987654321', N'Tác giả của cuốn sách "Những người khổng lồ tốt".'),
--(N'Bùi Ngọc Tân', 'buingoctan@gmail.com', '0123456789', N'Tác giả của cuốn sách "Thánh Gióng".'),
--(N'Nguyễn Thành Long', 'thanhlong@gmail.com', '0912345678', N'Tác giả của cuốn sách "Cây chuối non".'),
--(N'Nguyễn Nhật Ánh', 'nhatanh@gmail.com.', '0987654321', N'Tác giả của cuốn sách "Kính vạn hoa".'),
--(N'Hồ Anh Thái', 'hoanhthai@gmail.com', '0912345678', N'Tác giả của cuốn sách "Người giàu cũng khó khăn".'),
--(N'Lê Thành Sơn', 'thanhson@gmail.com', '0987654321', N'Tác giả của cuốn sách "Chiếc lá cuối cùng".'),
--(N'Phạm Viết Đức', 'vietduc@gmail.com', '0912345678', N'Tác giả của cuốn sách "Sự tích tâm và tình".'),
--(N'Nguyễn Hùng Việt', 'hungviet@gmail.com', '0987654321', N'Tác giả của cuốn sách "Cánh đồng bất tận".'),
--(N'Nguyễn Trung Trực', 'trungtruc@gmail.com', '0912345678', N'Tác giả của cuốn sách "Sông tre".');
GO

-- INSERT dữ liệu vào bảng Folder
INSERT INTO Folder (name_id, name, created_by, parent_id, status, created_date)
VALUES
('FDR001', N'Công nghiệp', 'admin', NULL, 1, '2023-07-20'),
('FDR002', N'Máy móc thiết bị', 'admin', NULL, 1, '2023-07-20'),
('FDR003', N'Đổi mới công nghệ', 'admin', NULL, 1, '2023-07-20'),
('FDR004', N'500 Khoa học - tự nhiên', 'admin', NULL, 1, '2023-07-20'),
('FDR005', N'300 Khoa học - xã hội', 'admin', NULL, 1, '2023-07-20'),
('FDR006', N'Tài liệu thực tập', 'admin', NULL, 1, '2023-07-20'),
('FDR007', N'Tài liệu số Lạc Việt', 'admin', NULL, 1, '2023-07-20'),
('FDR008', N'Tin học', 'admin', NULL, 1, '2023-07-20'),
('FDR009', N'Audio', 'admin', NULL, 1, '2023-07-20'),
('FDR010', N'Video', 'admin', NULL, 1, '2023-07-20'),
('FDR011', N'nghệ thuật gốm sứ', 'admin', 3, 1, '2023-07-20'),
('FDR012', N'tài liệu khác', 'admin', 3, 1, '2023-07-20');
GO

-- INSERT dữ liệu vào bảng Document
INSERT INTO Document (folder_id, title, ItemTypeID, file_path, link_to_image, description, updated_by, author)
VALUES 
(1, N'Cho tôi xin một vé đi tuổi thơ', 'b',         'C:\Documents\ChoToiXinMotVeDiTuoiTho.pdf', NULL, N'Tên sách nói lên tất cả, cuốn sách của tác giả Nguyễn Nhật Ánh sẽ đưa bạn trở lại tuổi thơ ngọt ngào nhất của mình.', 'Khoa', N'Nguyễn Nhật Ánh'),
(1, N'Kính vạn hoa', 'b',                           'C:\Documents\KinhVanHoa.pdf', NULL, N'Cuốn tiểu thuyết của tác giả Nguyễn Nhật Ánh là một câu chuyện tình nhẹ nhàng, ấm áp và đầy cảm hứng.', 'Khoa', N'Nguyễn Nhật Ánh'),
(2, N'Thánh Gióng', 'b',                            'C:\Documents\ThanhGiong.pdf', NULL, N'Thanh Giong là một trong những nhân vật lịch sử nổi tiếng của Việt Nam. Nhân vật này được khen là anh hùng mang lại nhiều lợi ích cơ bản cho dân tộc Việt Nam.', 'Khoa', N'Nguyễn Nhật Ánh'),
(2, N'Đọc hiểu lớp 2', 'b',                         'C:\Documents\DocHieuLop2.pdf', NULL, N'Cuốn sách các bài tập đọc hiểu cho học sinh lớp 2 giúp các em nắm vững kỹ năng đọc hiểu và rèn luyện tư duy.', 'Khoa', N'Không có tác giả'),
(3, N'Chiến lược dài hạn trong kinh doanh', 'b',    'C:\Documents\ChienluocDaihan.pdf', NULL, N'Cuốn sách này sẽ giúp bạn hiểu rõ hơn về chiến lược dài hạn trong kinh doanh và giúp bạn xây dựng và triển khai một chiến lược hiệu quả.', 'Khoa', NULL),
(3, N'Làm giàu không khó', 'b',                     'C:\Documents\LamGiauKhongKho.pdf', NULL, N'Cuốn sách này sẽ giúp bạn hiểu rõ hơn về cách làm giàu thông qua kinh doanh và đầu tư.', 'Khoa', NULL),
(4, N'Tôi là số 4', 'b',                            'C:\Documents\ToiLaSo4.pdf', NULL, N'Cuốn tiểu thuyết dành cho lứa tuổi thiếu niên với cốt truyện hấp dẫn, cuốn hút.', 'Khoa', NULL),
(4, N'Harry Potter và Hòn đá Phù thủy', 'b',        'C:\Documents\HarryPotterVaHonDaPhuThuy.pdf', NULL, N'Cuốn tiểu thuyết nổi tiếng dành cho lứa tuổi thiếu niên với những phép thuật, bí mật và những cuộc phiêu lưu ly kỳ.', 'Khoa', NULL),
(5, N'Sách giáo khoa lớp 1', 'b',                   'C:\Documents\SachGiaoKhoaLop1.pdf', NULL, N'Cuốn sách giáo khoa dành cho học sinh lớp 1 với đầy đủ các kiến thức về Tiếng Việt, Toán, Tự nhiên và Xã hội.', 'Khoa', NULL),
(5, N'Sách giáo khoa lớp 2', 'b',                   'C:\Documents\SachGiaoKhoaLop2.pdf', NULL, N'Cuốn sách giáo khoa dành cho học sinh lớp 2 với đầy đủ các kiến thức về Tiếng Việt, Toán, Tự nhiên và Xã hội.', 'Khoa', NULL);

GO

-- INSERT dữ liệu vào bảng DocumentIndex
INSERT INTO DocumentIndex (document_id, page_number, parent_index_id, title)
VALUES 
(1, 1, NULL,  N'Giới thiệu'),
(1, 2, NULL,  N'Chương 1'),
(1, 4, 2,  N'Phần 1.1'),
(1, 5, 2,  N'Phần 1.2'),
(2, 1, NULL,  N'Giới thiệu'),
(2, 2, NULL,  N'Chương 1'),
(2, 3, NULL,  N'Chương 2'),
(2, 4, NULL,  N'Chương 3'),
(3, 1, NULL,  N'Trang trước'),
(3, 3, NULL,  N'Trang sau');
GO

-- INSERT dữ liệu vào bảng UserAccess
INSERT INTO UserAccess (patron_type_id, page_read, page_download, display, read_limit, read_full, download)
VALUES 
('CB', 1, 1, 1, 0, 1, 0),
('TS', 1, 1, 1, 1, 1, 1),
('SV', 1, 1, 1, 1, 0, 1);
GO


--STORED PROCEDURES

---./Folder

---./Folder

---./UserAccess

---./UserAccess

-- SELECT
-- select all documents:



-- UPDATE
-- update the document status to approved


-- Tạo stored procedure để select cho mục lục của Document

--CREATE PROC sp_SelectDocumentIndex
--(
--  @DocumentID INT
--)
--AS
--BEGIN
--  -- Khai báo biến để lưu trữ kết quả trả về
--  DECLARE @DocumentIndex TABLE
--  (
--    index_id INT,
--    document_id INT,
--    page_number INT,
--    parent_index_id INT,
--    author_id INT,
--    title NVARCHAR(255)
--  );

--  -- Thêm dữ liệu vào bảng tạm thời @DocumentIndex
--  INSERT INTO @DocumentIndex
--  SELECT
--    DI.index_id,
--    DI.document_id,
--    DI.page_number,
--    DI.parent_index_id,
--    DI.author_id,
--    DI.title
--  FROM DocumentIndex DI
--  WHERE DI.document_id = @DocumentID;

--  -- Trả về kết quả
--  SELECT *
--  FROM @DocumentIndex;
--END;
--GO

-- Lấy mục lục của tài liệu có ID = 1
--EXEC sp_SelectDocumentIndex 1;
go




-- Hàm trả về tất cả các tài liệu trong thư mục có ID đã cho
CREATE FUNCTION GetDocumentsByFolderID (@folderID INT)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Document
    WHERE folder_id = @folderID
);
GO

-- Hàm trả về ngày tạo của tài liệu mới nhất
CREATE FUNCTION GetLatestDocumentCreatedDate()
RETURNS DATE
AS
BEGIN
    DECLARE @latestDate DATE;
    SELECT @latestDate = MAX(created_date)
    FROM Document
    WHERE document_status = 1;
    RETURN @latestDate;
END;
GO

-- Hàm trả về ngày tạo của tài liệu cũ nhất
CREATE FUNCTION GetOldestDocumentCreatedDate()
RETURNS DATE
AS
BEGIN
    DECLARE @oldestDate DATE;
    SELECT @oldestDate = MIN(created_date)
    FROM Document
    WHERE document_status = 1;
    RETURN @oldestDate;
END;
GO

-- Hàm trả về số lượng tài liệu có trạng thái đã phê duyệt
CREATE FUNCTION CountApprovedDocuments()
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*)
    FROM Document
    WHERE document_status = 1;
    RETURN @count;
END;
GO

-- Hàm trả về tất cả các tài liệu được tạo trong khoảng thời gian từ ngày 1 tháng 1 năm 2023 đến ngày 31 tháng 12 năm 2023
CREATE FUNCTION GetDocumentsInDateRange (@startDate DATE, @endDate DATE)
RETURNS TABLE
AS
RETURN
(
    SELECT *
    FROM Document
    WHERE created_date BETWEEN @startDate AND @endDate
);
GO

-- Hàm trả về ngày có tài liệu được duyệt nhiều nhất
CREATE FUNCTION GetDateWithMostApprovedDocuments()
RETURNS DATE
AS
BEGIN
    DECLARE @maxDate DATE;
    DECLARE @maxCount INT;
    SELECT @maxDate = MAX(created_date), @maxCount = COUNT(*)
    FROM Document
    WHERE document_status = 1;
    RETURN @maxDate;
END;
GO

-- Hàm trả về ngày có tài liệu được duyệt ít nhất
CREATE FUNCTION GetDateWithLeastApprovedDocuments()
RETURNS DATE
AS
BEGIN
    DECLARE @minDate DATE;
    DECLARE @minCount INT;
    SELECT @minDate = MIN(created_date), @minCount = COUNT(*)
    FROM Document
    WHERE document_status = 1;
    RETURN @minDate;
END;
GO

-- Hàm trả về số lượng tài liệu được duyệt trong một ngày
CREATE FUNCTION GetNumberOfApprovedDocumentsByDate (@date DATE)
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*)
    FROM Document
    WHERE created_date = @date
    AND document_status = 1;
    RETURN @count;
END;
GO

-- Hàm trả về số lượng tài liệu được tạo trong một ngày
CREATE FUNCTION GetNumberOfDocumentsCreatedByDate (@date DATE)
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*)
    FROM Document
    WHERE created_date = @date;
    RETURN @count;
END;
GO

-- Hàm trả về ngày có tài liệu được duyệt nhiều nhất trong một thư mục
CREATE FUNCTION GetDateWithMostApprovedDocumentsInFolder (@folderID INT)
RETURNS DATE
AS
BEGIN
    DECLARE @maxDate DATE;
    DECLARE @maxCount INT;
    SELECT @maxDate = MAX(created_date), @maxCount = COUNT(*)
    FROM Document
    WHERE folder_id = @folderID
    AND document_status = 1;
    RETURN @maxDate;
END;
GO






------------------System Mangement

CREATE TABLE PatronTypes(
	PatronTypeID char(10) NOT NULL,
	TypeName nvarchar(50) NOT NULL,
	Note text NULL,
	CONSTRAINT PK_PatronTypes PRIMARY KEY (PatronTypeID)
);
GO

CREATE TABLE ItemTypes(
	ItemTypeID CHAR(10),
	TypeName NVARCHAR(50) NOT NULL UNIQUE,
	CONSTRAINT PK_ItemTypes PRIMARY KEY(ItemTypeID),
);
GO

INSERT INTO ItemTypes (ItemTypeID, TypeName)
VALUES
('b', N'Books - Sách'),
('cf', N'Computer file - Tập tin'),
('d', N'Đề tài'),
('h', N'Hội thảo'),
('o', N'Ngoại văn'),
('m', N'Maps - Bản đồ'),
('s', N'Serials - Ấn phẩm định kỳ'),
('x', N'Mixed Material - Tài liệu hỗn hợp');
GO
INSERT INTO PatronTypes (PatronTypeID, TypeName) VALUES
	('CB', N'Cán bộ'),
	('GV', N'Giảng viên'), 
	('NCS', N'Học viên cao học'),
	('SV', N'Sinh viên'),
	('TS', N'Tiến sĩ');


-----------Update My Own
ALTER TABLE UserAccess
ADD CONSTRAINT FK_UserAccess_PatronTypes FOREIGN KEY (patron_type_id) REFERENCES PatronTypes(PatronTypeID)
GO

ALTER TABLE Document
ADD CONSTRAINT FK_Document_ItemTypes FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)
GO

------FUNCTION NEWEST 12/12

-- Hàm trả về số lượng tài liệu trong thư mục có ID đã cho
CREATE FUNCTION CountDocumentsByFolderID (@folder_id INT)
RETURNS INT
AS
BEGIN
    DECLARE @count INT;
    SELECT @count = COUNT(*)
    FROM Document
    WHERE folder_id = @folder_id;
    RETURN @count;
END;
GO

CREATE FUNCTION CountDocumentIsPublic()
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	SELECT @count = COUNT(*)
	FROM Document
	WHERE document_status = 1
	RETURN @count
END;
GO

CREATE FUNCTION CountDocumentUnPublic()
RETURNS INT
AS
BEGIN
	DECLARE @count INT
	SELECT @count = COUNT(*)
	FROM Document
	WHERE document_status = 0
	RETURN @count
END;
GO