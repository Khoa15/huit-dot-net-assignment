

USE TaiLieuSo
GO

-- Tạo bảng Thư mục (Folder)
CREATE TABLE Folder (
    FolderID INT PRIMARY KEY,
    FolderName VARCHAR(255),
    Description TEXT,
    CreatedDate DATE,
    CreatedBy VARCHAR(50)
);
GO

-- Tạo bảng Tài liệu (Document)
CREATE TABLE Document (
    DocumentID INT PRIMARY KEY,
    DocumentName VARCHAR(255),
    Description TEXT,
    FilePath VARCHAR(255),
    FolderID INT,
    CreatedDate DATE,
    CreatedBy VARCHAR(50),
    FOREIGN KEY (FolderID) REFERENCES Folder(FolderID)
);
GO

-- Tạo bảng Chính sách Phân quyền (AccessPolicy)
CREATE TABLE AccessPolicy (
    PolicyID INT PRIMARY KEY,
    PolicyName VARCHAR(255),
    Description TEXT,
    AccessRights VARCHAR(255) -- Có thể sử dụng một kiểu dữ liệu phù hợp cho quyền truy cập
);
GO

-- Tạo bảng Phân quyền Người dùng (UserAccess)
CREATE TABLE UserAccess (
    UserAccessID INT PRIMARY KEY,
    UserID INT, -- Đặt các trường liên quan đến người dùng ở đây
    PolicyID INT,
    DocumentID INT,
    FolderID INT,
    FOREIGN KEY (PolicyID) REFERENCES AccessPolicy(PolicyID),
    FOREIGN KEY (DocumentID) REFERENCES Document(DocumentID),
    FOREIGN KEY (FolderID) REFERENCES Folder(FolderID)
);
GO

-- Tạo trigger 
-- Procedure để thêm mới một thư mục
CREATE PROCEDURE AddFolder
    @FolderID INT,
    @FolderName VARCHAR(255),
    @Description TEXT,
    @CreatedDate DATE,
    @CreatedBy VARCHAR(50)
AS
BEGIN
    INSERT INTO Folder (FolderID, FolderName, Description, CreatedDate, CreatedBy)
    VALUES (@FolderID, @FolderName, @Description, @CreatedDate, @CreatedBy);
END;
GO

-- Procedure để xóa một thư mục bằng FolderID
CREATE PROCEDURE DeleteFolder
    @FolderID INT
AS
BEGIN
    DELETE FROM Folder WHERE FolderID = @FolderID;
END;
GO

-- Procedure để sửa thông tin của một thư mục bằng FolderID
CREATE PROCEDURE UpdateFolder
    @FolderID INT,
    @FolderName VARCHAR(255),
    @Description TEXT,
    @CreatedDate DATE,
    @CreatedBy VARCHAR(50)
AS
BEGIN
    UPDATE Folder
    SET FolderName = @FolderName, Description = @Description, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy
    WHERE FolderID = @FolderID;
END;
GO

-- Procedure để thêm mới một tài liệu
CREATE PROCEDURE AddDocument
    @DocumentID INT,
    @DocumentName VARCHAR(255),
    @Description TEXT,
    @FilePath VARCHAR(255),
    @FolderID INT,
    @CreatedDate DATE,
    @CreatedBy VARCHAR(50)
AS
BEGIN
    INSERT INTO Document (DocumentID, DocumentName, Description, FilePath, FolderID, CreatedDate, CreatedBy)
    VALUES (@DocumentID, @DocumentName, @Description, @FilePath, @FolderID, @CreatedDate, @CreatedBy);
END;
GO

-- Procedure để xóa một tài liệu bằng DocumentID
CREATE PROCEDURE DeleteDocument
    @DocumentID INT
AS
BEGIN
    DELETE FROM Document WHERE DocumentID = @DocumentID;
END;
GO

-- Procedure để sửa thông tin của một tài liệu bằng DocumentID
CREATE PROCEDURE UpdateDocument
    @DocumentID INT,
    @DocumentName VARCHAR(255),
    @Description TEXT,
    @FilePath VARCHAR(255),
    @FolderID INT,
    @CreatedDate DATE,
    @CreatedBy VARCHAR(50)
AS
BEGIN
    UPDATE Document
    SET DocumentName = @DocumentName, Description = @Description, FilePath = @FilePath,
        FolderID = @FolderID, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy
    WHERE DocumentID = @DocumentID;
END;
GO

-- Procedure để thêm mới một chính sách phân quyền
CREATE PROCEDURE AddAccessPolicy
    @PolicyID INT,
    @PolicyName VARCHAR(255),
    @Description TEXT,
    @AccessRights VARCHAR(255)
AS
BEGIN
    INSERT INTO AccessPolicy (PolicyID, PolicyName, Description, AccessRights)
    VALUES (@PolicyID, @PolicyName, @Description, @AccessRights);
END;
GO

-- Procedure để xóa một chính sách phân quyền bằng PolicyID
CREATE PROCEDURE DeleteAccessPolicy
    @PolicyID INT
AS
BEGIN
    DELETE FROM AccessPolicy WHERE PolicyID = @PolicyID;
END;
GO

-- Procedure để sửa thông tin của một chính sách phân quyền bằng PolicyID
CREATE PROCEDURE UpdateAccessPolicy
    @PolicyID INT,
    @PolicyName VARCHAR(255),
    @Description TEXT,
    @AccessRights VARCHAR(255)
AS
BEGIN
    UPDATE AccessPolicy
    SET PolicyName = @PolicyName, Description = @Description, AccessRights = @AccessRights
    WHERE PolicyID = @PolicyID;
END;
GO

-- Procedure để thêm mới một quyền truy cập của người dùng
CREATE PROCEDURE AddUserAccess
    @UserAccessID INT,
    @UserID INT,
    @PolicyID INT,
    @DocumentID INT,
    @FolderID INT
AS
BEGIN
    INSERT INTO UserAccess (UserAccessID, UserID, PolicyID, DocumentID, FolderID)
    VALUES (@UserAccessID, @UserID, @PolicyID, @DocumentID, @FolderID);
END;
GO

-- Procedure để xóa quyền truy cập của người dùng bằng UserAccessID
CREATE PROCEDURE DeleteUserAccess
    @UserAccessID INT
AS
BEGIN
    DELETE FROM UserAccess WHERE UserAccessID = @UserAccessID;
END;
GO

-- Procedure để sửa thông tin quyền truy cập của người dùng bằng UserAccessID
CREATE PROCEDURE UpdateUserAccess
    @UserAccessID INT,
    @UserID INT,
    @PolicyID INT,
    @DocumentID INT,
    @FolderID INT
AS
BEGIN
    UPDATE UserAccess
    SET UserID = @UserID, PolicyID = @PolicyID, DocumentID = @DocumentID, FolderID = @FolderID
    WHERE UserAccessID = @UserAccessID;
END;
GO
