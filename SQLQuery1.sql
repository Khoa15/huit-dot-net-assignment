use master;
go
create database TaiLieuSo;
go
USE TaiLieuSo;
GO

CREATE TABLE Folder (
    folder_id INT IDENTITY(1,1) CONSTRAINT PK_Folder PRIMARY KEY,
    name_id VARCHAR(10) NULL UNIQUE,
    name NVARCHAR(255) NOT NULL,
    created_date DATE DEFAULT(GETDATE()),
    created_by NVARCHAR(255),
    parent_id INT NULL,
	status BIT DEFAULT(0),
    CONSTRAINT FK_Folder_Parent FOREIGN KEY (parent_id) REFERENCES Folder(folder_id),
    CONSTRAINT CHK_Folder_CreatedDate CHECK (created_date <= GETDATE())
);
GO

CREATE TABLE UserAccess (
    user_type_id INT NOT NULL CONSTRAINT PK_UserAccess PRIMARY KEY, -- foreign key QuanLyHT
    display BIT NOT NULL DEFAULT(0),
    read_limit BIT NOT NULL DEFAULT(0),
    read_full BIT NOT NULL DEFAULT(0),
    download BIT NOT NULL DEFAULT(0),
    page_read INT NOT NULL DEFAULT(0),
    page_download INT NOT NULL DEFAULT(0),
);
GO

CREATE TABLE Author (
    author_id INT IDENTITY(1,1) CONSTRAINT PK_Author PRIMARY KEY,
    author_name NVARCHAR(255) NOT NULL,
    author_email NVARCHAR(255),  -- Add the author's email
    author_phone NVARCHAR(20),  -- Add the author's phone number
    author_description NVARCHAR(1000),
    CONSTRAINT CHK_Author_Email CHECK (LEN(author_email) <= 255),
    CONSTRAINT CHK_Author_Phone CHECK (LEN(author_phone) <= 20)
);
GO

CREATE TABLE Document (
    document_id INT IDENTITY(1,1) CONSTRAINT PK_Document PRIMARY KEY,
    title NVARCHAR(255) NOT NULL,
    description TEXT,
    file_path VARCHAR(255),
    folder_id INT NOT NULL,
    created_date DATE,
	updated_date DATE,
    link_to_image VARCHAR(255) NULL,
    type NVARCHAR(255), -- foreign key QuanLyHT
    author_id INT NULL,
    document_status BIT,
    CONSTRAINT FK_Document_Folder FOREIGN KEY (folder_id) REFERENCES Folder(folder_id),
    CONSTRAINT FK_Document_Author FOREIGN KEY (author_id) REFERENCES Author(author_id),
    CONSTRAINT CHK_Document_CreatedDate CHECK (created_date <= GETDATE())
);
GO
	
CREATE TABLE DocumentIndex (
    index_id INT IDENTITY(1,1) CONSTRAINT PK_DocumentIndex PRIMARY KEY,
    title NVARCHAR(255),
    document_id INT NOT NULL CONSTRAINT FK_DocumentIndex_DocumentID REFERENCES Document(document_id),
    page_number INT,
    parent_index_id INT NULL CONSTRAINT FK_DocumentIndex_ParentIndexID REFERENCES DocumentIndex(index_id),
    author_id INT NULL CONSTRAINT FK_DocumentIndex_AuthorID REFERENCES Author(author_id)
);
GO

---- Tạo trigger cho bảng UserType
--CREATE TRIGGER UserType_BI
--ON UserType
--AFTER INSERT
--AS
--BEGIN
--    -- Thêm defualt value cho các trường 
--    -- Nếu như các trường này không được cung cấp khi chèn bản ghi mới 
--    UPDATE UserType
--    SET description = '',
--        can_create_folder = 0,
--        can_upload_document = 0,
--        can_delete_document = 0,
--        can_edit_document = 0,
--        can_view_document = 0
--    WHERE user_type_id IN (SELECT user_type_id FROM inserted);
--END;
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

-- Tạo trigger cho bảng UserAccess
CREATE TRIGGER UserAccess_BIU
ON UserAccess
AFTER INSERT, UPDATE
AS
BEGIN
    -- Kiểm tra và cập nhật trường display sau khi chèn hoặc cập nhật
    IF UPDATE(display)
    BEGIN
        UPDATE UserAccess
        SET display = COALESCE(i.display, 1)
        FROM UserAccess AS u
        INNER JOIN inserted AS i ON u.user_access_id = i.user_access_id;
    END;
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
        INNER JOIN inserted AS i ON f.folder_id = i.folder_id;
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
        INNER JOIN inserted AS i ON d.document_id = i.document_id;
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
        INNER JOIN inserted AS i ON di.index_id = i.index_id;
    END;
END;
GO




