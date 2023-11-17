use master;
go

create database TaiLieuSo;
go

USE TaiLieuSo;
GO

-- Tạo bảng Folder với ràng buộc
CREATE TABLE Folder (
    folder_id INT IDENTITY(1,1),
    name_id NVARCHAR(10) NOT NULL,
    name NVARCHAR(255) NOT NULL,
    created_by NVARCHAR(255),
    parent_id INT NULL,
	status BIT DEFAULT(0),
    created_date DATE,
    CONSTRAINT CHK_Folder_CreatedDate CHECK (created_date <= GETDATE()),
	CONSTRAINT PK_Folder PRIMARY KEY (folder_id),	
    CONSTRAINT FK_Folder_Parent FOREIGN KEY (parent_id) REFERENCES Folder(folder_id)
);
GO

-- Tạo bảng UserAccess với ràng buộc
CREATE TABLE UserAccess (
    user_type_id INT IDENTITY(1,1) NOT NULL,-- foreign key QuanLyHT
    page_read INT NOT NULL DEFAULT(0),
    page_download INT NOT NULL DEFAULT(0),
    display BIT NOT NULL DEFAULT(0),
    read_limit BIT NOT NULL DEFAULT(0),
    read_full BIT NOT NULL DEFAULT(0),
    download BIT NOT NULL DEFAULT(0),
	CONSTRAINT PK_UserAccess PRIMARY KEY (user_type_id)
);
GO

-- Create the Author table
CREATE TABLE Author (
    id INT IDENTITY(1,1) NOT NULL,
    name NVARCHAR(255) NOT NULL,
    email NVARCHAR(255),
    phone NVARCHAR(20),
    description NVARCHAR(1000),
    CONSTRAINT CHK_Author_Email CHECK (LEN(email) <= 255),
    CONSTRAINT CHK_Author_Phone CHECK (LEN(phone) <= 20),
	CONSTRAINT PK_Author_AuthorID PRIMARY KEY (id)
);
GO

-- Tạo bảng Document với ràng buộc
CREATE TABLE Document (
    document_id INT IDENTITY(1,1) NOT NULL,--
    folder_id INT NOT NULL,--
    author_id INT NULL,--
    title NVARCHAR(255) NOT NULL,--
    type NVARCHAR(255), -- foreign key QuanLyHT--
    file_path VARCHAR(255),--
    link_to_image VARCHAR(255) NULL,--
    description TEXT,--
    document_status BIT,--
    created_date DATE,--
	updated_date DATE,---
    CONSTRAINT CHK_Document_CreatedDate CHECK (created_date <= GETDATE()),
	CONSTRAINT PK_Document PRIMARY KEY (document_id),
    CONSTRAINT FK_Document_Folder FOREIGN KEY (folder_id) REFERENCES Folder(folder_id),
    CONSTRAINT FK_Document_Author FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO
	
-- Create the DocumentIndex table
CREATE TABLE DocumentIndex (
    index_id INT IDENTITY(1,1),
    document_id INT NOT NULL,
    page_number INT,
    parent_index_id INT NULL,
    author_id INT NULL,
    title NVARCHAR(255),
	CONSTRAINT PK_DocumentIndex PRIMARY KEY (index_id),
	CONSTRAINT FK_DocumentIndex_DocumentID FOREIGN KEY (document_id) REFERENCES Document(document_id),
	CONSTRAINT FK_DocumentIndex_ParentIndexID FOREIGN KEY (parent_index_id) REFERENCES DocumentIndex(index_id),
	CONSTRAINT FK_DocumentIndex_AuthorID FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

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
        document_status = 0
    WHERE document_id IN (SELECT document_id FROM inserted);
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
        JOIN inserted AS i ON f.folder_id = i.folder_id;
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
        JOIN inserted AS i ON d.document_id = i.document_id;
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


-- INSERT dữ liệu vào bảng Author
INSERT INTO Author (name, email, phone, description)
VALUES 
('Nguyễn Nhật Ánh', 'nhatanh@gmail.com', '0987654321', 'Tác giả của cuốn sách "Cho tôi xin một vé đi tuổi thơ".'),
('Bùi Ngọc Tân', 'buingoctan@gmail.com', '0123456789', 'Tác giả của cuốn sách "Thánh Gióng".'),
('Nguyễn Thành Long', 'thanhlong@gmail.com', '0912345678', 'Tác giả của cuốn sách "Cây chuối non".'),
('Nguyễn Nhật Ánh', 'nhatanh@gmail.com', '0987654321', 'Tác giả của cuốn sách "Kính vạn hoa".'),
('Trần Thị Rò', 'thiro@gmail.com', '0987654321', 'Tác giả của cuốn sách "Những người khổng lồ tốt".'),
('Hồ Anh Thái', 'hoanhthai@gmail.com', '0912345678', 'Tác giả của cuốn sách "Người giàu cũng khó khăn".'),
('Lê Thành Sơn', 'thanhson@gmail.com', '0987654321', 'Tác giả của cuốn sách "Chiếc lá cuối cùng".'),
('Phạm Viết Đức', 'vietduc@gmail.com', '0912345678', 'Tác giả của cuốn sách "Sự tích tâm và tình".'),
('Nguyễn Hùng Việt', 'hungviet@gmail.com', '0987654321', 'Tác giả của cuốn sách "Cánh đồng bất tận".'),
('Nguyễn Trung Trực', 'trungtruc@gmail.com', '0912345678', 'Tác giả của cuốn sách "Sông tre".');
GO

-- INSERT dữ liệu vào bảng Folder
INSERT INTO Folder (name_id, name, created_by, parent_id, status, created_date)
VALUES
('FDR001', 'Công nghiệp', 'admin', NULL, 1, '2023-07-20'),
('FDR002', 'Máy móc thiết bị', 'admin', NULL, 1, '2023-07-20'),
('FDR003', 'Đổi mới công nghệ', 'admin', NULL, 1, '2023-07-20'),
('FDR004', '500 Khoa học - tự nhiên', 'admin', NULL, 1, '2023-07-20'),
('FDR005', '300 Khoa học - xã hội', 'admin', NULL, 1, '2023-07-20'),
('FDR006', 'Tài liệu thực tập', 'admin', NULL, 1, '2023-07-20'),
('FDR007', 'Tài liệu số Lạc Việt', 'admin', NULL, 1, '2023-07-20'),
('FDR008', 'Tin học', 'admin', NULL, 1, '2023-07-20'),
('FDR009', 'Audio', 'admin', NULL, 1, '2023-07-20'),
('FDR010', 'Video', 'admin', NULL, 1, '2023-07-20'),
('FDR011', 'nghệ thuật gốm sứ', 'admin', 3, 1, '2023-07-20'),
('FDR012', 'tài liệu khác', 'admin', 3, 1, '2023-07-20');

GO

-- INSERT dữ liệu vào bảng Document
INSERT INTO Document (folder_id, author_id, title, type, file_path, link_to_image, description)
VALUES 
(1, 1, 'Cho tôi xin một vé đi tuổi thơ', 'Tiểu thuyết', 'C:\Documents\ChoToiXinMotVeDiTuoiTho.pdf', NULL, 'Tên sách nói lên tất cả, cuốn sách của tác giả Nguyễn Nhật Ánh sẽ đưa bạn trở lại tuổi thơ ngọt ngào nhất của mình.'),
(1, 1, 'Kính vạn hoa', 'Tiểu thuyết', 'C:\Documents\KinhVanHoa.pdf', NULL, 'Cuốn tiểu thuyết của tác giả Nguyễn Nhật Ánh là một câu chuyện tình nhẹ nhàng, ấm áp và đầy cảm hứng.'),
(2, 2, 'Thánh Gióng', 'Truyện tranh', 'C:\Documents\ThanhGiong.pdf', NULL, 'Thanh Giong la mot trong nhung nhan vat lich su noi tieng cua Viet Nam. Nhan vat nay duoc khen la anh hung mang lai nhieu loi ich co ban cho dan toc Viet Nam.'),
(2, 2, 'Đọc hiểu lớp 2', 'Giáo khoa', 'C:\Documents\DocHieuLop2.pdf', NULL, 'Cuốn sách các bài tập đọc hiểu cho học sinh lớp 2 giúp các em nắm vững kỹ năng đọc hiểu và rèn luyện tư duy.'),
(3, 3, 'Chiến lược dài hạn trong kinh doanh', 'Kinh doanh', 'C:\Documents\ChienluocDaihan.pdf', NULL, 'Cuốn sách này sẽ giúp bạn hiểu rõ hơn về chiến lược dài hạn trong kinh doanh và giúp bạn xây dựng và triển khai một chiến lược hiệu quả.'),
(3, 3, 'Làm giàu không khó', 'Kinh doanh', 'C:\Documents\LamGiauKhongKho.pdf', NULL, 'Cuốn sách này sẽ giúp bạn hiểu rõ hơn về cách làm giàu thông qua kinh doanh và đầu tư.'),
(4, 4, 'Tôi là số 4', 'Tiểu thuyết', 'C:\Documents\ToiLaSo4.pdf', NULL, 'Cuốn tiểu thuyết dành cho lứa tuổi thiếu niên với cốt truyện hấp dẫn, cuốn hút.'),
(4, 4, 'Harry Potter và Hòn đá Phù thủy', 'Tiểu thuyết', 'C:\Documents\HarryPotterVaHonDaPhuThuy.pdf', NULL, 'Cuốn tiểu thuyết nổi tiếng dành cho lứa tuổi thiếu niên với những phép thuật, bí mật và những cuộc phiêu lưu ly kỳ.'),
(5, 5, 'Sách giáo khoa lớp 1', 'Giáo khoa', 'C:\Documents\SachGiaoKhoaLop1.pdf', NULL, 'Cuốn sách giáo khoa dành cho học sinh lớp 1 với đầy đủ các kiến thức về Tiếng Việt, Toán, Tự nhiên và Xã hội.'),
(5, 5, 'Sách giáo khoa lớp 2', 'Giáo khoa', 'C:\Documents\SachGiaoKhoaLop2.pdf', NULL, 'Cuốn sách giáo khoa dành cho học sinh lớp 2 với đầy đủ các kiến thức về Tiếng Việt, Toán, Tự nhiên và Xã hội.');
GO

-- INSERT dữ liệu vào bảng DocumentIndex
INSERT INTO DocumentIndex (document_id, page_number, parent_index_id, author_id, title)
VALUES 
(1, 1, NULL, 1, 'Giới thiệu'),
(1, 2, NULL, 1, 'Chương 1'),
(1, 4, 2, 1, 'Phần 1.1'),
(1, 5, 2, 1, 'Phần 1.2'),
(2, 1, NULL, 1, 'Giới thiệu'),
(2, 2, NULL, 1, 'Chương 1'),
(2, 3, NULL, 1, 'Chương 2'),
(2, 4, NULL, 1, 'Chương 3'),
(3, 1, NULL, 2, 'Trang trước'),
(3, 3, NULL, 2, 'Trang sau');
GO

-- INSERT dữ liệu vào bảng UserAccess
INSERT INTO UserAccess (page_read, page_download, display, read_limit, read_full, download)
VALUES 
(1, 1, 1, 0, 1, 0),
(1, 1, 1, 1, 1, 1),
(1, 1, 1, 1, 0, 1),
(1, 1, 0, 0, 0, 0),
(1, 0, 0, 0, 0, 0),
(0, 0, 1, 0, 0, 0),
(0, 1, 1, 1, 0, 1),
(1, 1, 1, 1, 1, 1),
(1, 0, 1, 0, 0, 0),
(1, 1, 1, 1, 1, 1);
GO
