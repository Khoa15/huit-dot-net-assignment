use master
go
create database TaiLieuSo
go
USE TaiLieuSo
GO
GO
-- Tạo bảng Folder với liên kết đến chính nó
CREATE TABLE Folder (
<<<<<<< HEAD
	id int IDENTITY(1,1),
    name_id VARCHAR(10),
    parent_id int, -- Thêm liên kết với chính nó
=======
	ID int IDENTITY(1,1),
    name_id VARCHAR(10),
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
    name NVARCHAR(255),
    created_date DATE,
    created_by NVARCHAR(255), -- foregin key?
<<<<<<< HEAD
=======
    parent_id int, -- Thêm liên kết với chính nó
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
	CONSTRAINT PK_FOLDER PRIMARY KEY (id),
    CONSTRAINT FK_FOLDER FOREIGN KEY (parent_id) REFERENCES Folder(id)
);
GO

-- Tạo bảng Document với các thay đổi
CREATE TABLE Document (
    id INT IDENTITY(1,1),
    name NVARCHAR(255),
    description TEXT,
    file_path VARCHAR(255),
    folder_id int,
    created_date DATE,
    created_by_user_access_id INT, -- Khóa ngoại tới bảng UserAccess
    link_to_image VARCHAR(255), -- Thêm cột Link ảnh (local hoặc URL)
    document_type NVARCHAR(255), -- Loại tài liệu
    document_status INT, -- Trạng thái tài liệu
    author_id INT, -- Khóa ngoại tới bảng Author
	CONSTRAINT PK_DOCUMENT PRIMARY KEY (id),
    CONSTRAINT FK_DOCUMENT_FOLDER FOREIGN KEY (folder_id) REFERENCES Folder(id),
    --FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id), -- Khóa ngoại tới bảng UserAccess
    --FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

-- Tạo bảng UserAccess với các thay đổi
CREATE TABLE UserAccess (
    id INT IDENTITY(1,1),
    display INT,
    read_limit INT,
    read_full INT,
    download INT,
    page_read INT,
    page_download INT,
    user_type_id INT,
	CONSTRAINT PK_USERACCESS PRIMARY KEY (id)-- Liên kết với bảng UserType
<<<<<<< HEAD
    --FOREIGN KEY (document_id) REFERENCES Document(id),
    --FOREIGN KEY (folder_id) REFERENCES Folder(id)
=======
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
);
GO

-- Tạo bảng Author
CREATE TABLE Author (
    id INT IDENTITY(1,1),
    author_name NVARCHAR(255),
    description TEXT,
	CONSTRAINT PK_AUTHOR PRIMARY KEY (id)
);
GO

-- Khôi phục lại bảng DocumentIndex
CREATE TABLE DocumentIndex (
    id INT IDENTITY(1,1),
    title NVARCHAR(255),
    document_id INT,
    page_number INT,
    parent_id INT, -- Thêm cột parent_index_id làm khóa ngoại
    author_id INT, -- Thêm cột author_id làm khóa ngoại
<<<<<<< HEAD
	CONSTRAINT PK_DOCUMENTINDEX PRIMARY KEY (index_id),
    CONSTRAINT FK_DOCUMENTINDEX_DOCUMENT FOREIGN KEY (document_id) REFERENCES Document(id),
    CONSTRAINT FK_DOCUMENTINDEX FOREIGN KEY (parent_index_id) REFERENCES DocumentIndex(index_id), -- Liên kết với chính nó
=======
	CONSTRAINT PK_DOCUMENTINDEX PRIMARY KEY (id),
    CONSTRAINT FK_DOCUMENTINDEX_DOCUMENT FOREIGN KEY (document_id) REFERENCES Document(id),
    CONSTRAINT FK_DOCUMENTINDEX FOREIGN KEY (parent_id) REFERENCES DocumentIndex(id), -- Liên kết với chính nó
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
    CONSTRAINT FK_DOCUMENTINDEX_AUTHOR FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

ALTER TABLE Document ADD CONSTRAINT FK_DOCUMENT_USERACCESS FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id)
GO
ALTER TABLE Document ADD CONSTRAINT FK_DOCUMENT_AUTHOR FOREIGN KEY (author_id) REFERENCES Author(id)
<<<<<<< HEAD
GO
SET IDENTITY_INSERT Folder ON;


--cài đặt trigger 
CREATE TRIGGER trg_Folder_InsertUpdate
ON Folder
AFTER INSERT, UPDATE
AS
BEGIN
    -- Thêm mã logic của bạn ở đây
    -- Ví dụ: LOG thay đổi hoặc kiểm tra ràng buộc

    -- Ví dụ: LOG thay đổi vào bảng History
    INSERT INTO FolderHistory (FolderID, ChangeDate, ChangeType)
    SELECT i.id, GETDATE(), 'INSERT' FROM inserted i
    UNION ALL
    SELECT u.id, GETDATE(), 'UPDATE' FROM deleted d
    INNER JOIN inserted i ON d.id = i.id;
END;
=======
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
GO
SET IDENTITY_INSERT Folder ON;

<<<<<<< HEAD
CREATE TRIGGER trg_Document_InsertUpdate
ON Document
AFTER INSERT, UPDATE
AS
BEGIN
    -- Thêm mã logic của bạn ở đây
    -- Ví dụ: LOG thay đổi hoặc kiểm tra ràng buộc

    -- Ví dụ: LOG thay đổi vào bảng DocumentHistory
    INSERT INTO DocumentHistory (DocumentID, ChangeDate, ChangeType)
    SELECT i.id, GETDATE(), 'INSERT' FROM inserted i
    UNION ALL
    SELECT u.id, GETDATE(), 'UPDATE' FROM deleted d
    INNER JOIN inserted i ON d.id = i.id;
END;
GO

CREATE TRIGGER trg_UserAccess_InsertUpdate
ON UserAccess
AFTER INSERT, UPDATE
AS
BEGIN
    -- Thêm mã logic của bạn ở đây
    -- Ví dụ: LOG thay đổi hoặc kiểm tra ràng buộc

    -- Ví dụ: LOG thay đổi vào bảng UserAccessHistory
    INSERT INTO UserAccessHistory (UserAccessID, ChangeDate, ChangeType)
    SELECT i.id, GETDATE(), 'INSERT' FROM inserted i
    UNION ALL
    SELECT u.id, GETDATE(), 'UPDATE' FROM deleted d
    INNER JOIN inserted i ON d.id = i.id;
END;
GO

----
=======
>>>>>>> 0d96181420f179b7fda2c1dc00011d82a24ebd54
INSERT INTO Folder (ID, name_id, name, description, created_date, created_by, parent_id)
VALUES
    (1, 'DBH', N'Đã ban hành', NULL, '2023-09-06', 'admin', NULL),
    (2, 'CBH', N'Chưa ban hành', NULL, '2023-09-06', 'admin', NULL),
    (3, 'CBM', N'Chưa biên mục', NULL, '2023-09-06', 'admin', NULL),
    (4, 'CN', N'Công nghiệp', NULL, '2023-09-06', 'admin', NULL),
    (5, 'CN1', N'Công nghiệp', NULL, '2023-09-06', 'admin', 4),
    (6, 'CN2', N'Công nghiệp hóa chất', NULL, '2023-09-06', 'admin', 4),
    (7, 'CN3', N'Công nghiệp sx hàng tiêu dùng', NULL, '2023-09-06', 'admin', 4),
    (8, 'CN4', N'Công nghiệp thực phẩm', NULL, '2023-09-06', 'admin', 4);

SET IDENTITY_INSERT Folder OFF;

GO

--SELECT * FROM Folder