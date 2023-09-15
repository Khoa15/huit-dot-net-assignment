

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
