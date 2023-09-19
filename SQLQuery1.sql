
USE TaiLieuSo
GO

-- Tạo bảng Folder với liên kết đến chính nó
CREATE TABLE Folder (
    id CHAR(10),
    name NVARCHAR(255),
    description TEXT,
    created_date DATE,
    created_by NVARCHAR(255),
    parent_id NVARCHAR(255), -- Thêm liên kết với chính nó
	CONSTRAINT pk_Folder PRIMARY KEY (name),
    CONSTRAINT fk_Folder FOREIGN KEY (parent_id) REFERENCES Folder(name)
);
GO

-- Tạo bảng Document với các thay đổi
CREATE TABLE Document (
    id INT IDENTITY(1,1),
    name NVARCHAR(255),
    description TEXT,
    file_path VARCHAR(255),
    folder_id NVARCHAR(255),
    created_date DATE,
    created_by_user_access_id INT, -- Khóa ngoại tới bảng UserAccess
    link_to_image VARCHAR(255), -- Thêm cột Link ảnh (local hoặc URL)
    document_type NVARCHAR(255), -- Loại tài liệu
    document_status INT, -- Trạng thái tài liệu
    author_id CHAR(10), -- Khóa ngoại tới bảng Author
	CONSTRAINT pk_Document PRIMARY KEY (id),
    CONSTRAINT fk_Document_Folder FOREIGN KEY (folder_id) REFERENCES Folder(name),
    --FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id), -- Khóa ngoại tới bảng UserAccess
    --FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

-- Tạo bảng UserAccess với các thay đổi
CREATE TABLE UserAccess (
    id INT IDENTITY(1,1),
    --policy_id INT,
    --document_id INT,
    --folder_id INT,
    display INT,
    read_limit INT,
    read_full INT,
    download INT,
    page_read INT,
    page_download INT,
    user_type_id INT,
	CONSTRAINT pk_UserAccess PRIMARY KEY (id)-- Liên kết với bảng UserType
    --FOREIGN KEY (document_id) REFERENCES Document(id),
    --FOREIGN KEY (folder_id) REFERENCES Folder(id)
);
GO

-- Tạo bảng Author
CREATE TABLE Author (
    id INT IDENTITY(1,1),
    author_name NVARCHAR(255),
    description TEXT,
	CONSTRAINT pk_Author PRIMARY KEY (id)
);
GO

-- Khôi phục lại bảng DocumentIndex
CREATE TABLE DocumentIndex (
    index_id INT IDENTITY(1,1),
    title NVARCHAR(255),
    document_id INT,
    page_number INT,
    parent_index_id INT, -- Thêm cột parent_index_id làm khóa ngoại
    author_id INT, -- Thêm cột author_id làm khóa ngoại
	CONSTRAINT pk_DocumentIndex PRIMARY KEY (index_id),
    CONSTRAINT fk_DocumentIndex_Document FOREIGN KEY (document_id) REFERENCES Document(id),
    CONSTRAINT fk_DocumentIndex FOREIGN KEY (parent_index_id) REFERENCES DocumentIndex(index_id), -- Liên kết với chính nó
    CONSTRAINT fk_DocumentIndex_Author FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

ALTER TABLE Document ADD CONSTRAINT fk_Document_UserAccess FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id)
GO
ALTER TABLE Document ADD CONSTRAINT fk_Document_Author FOREIGN KEY (author_id) REFERENCES Author(id)
GO

INSERT INTO Folder (id, name, description, created_date, created_by, parent_id)
VALUES
    ('DBH', N'Đã ban hành', NULL, '2023-09-06', 'admin', NULL),
    ('CBH', N'Chưa ban hành', NULL, '2023-09-06', 'admin', NULL),
    ('CBM', N'Chưa biên mục', NULL, '2023-09-06', 'admin', NULL),
    ('CN', N'Công nghiệp', NULL, '2023-09-06', 'admin', NULL),
    ('CN1', N'Công nghiệp', NULL, '2023-09-06', 'admin', N'Công nghiệp'),
    ('CN2', N'Công nghiệp hóa chất', NULL, '2023-09-06', 'admin', N'Công nghiệp'),
    ('CN3', N'Công nghiệp sx hàng tiêu dùng', NULL, '2023-09-06', 'admin', N'Công nghiệp'),
    ('CN4', N'Công nghiệp thực phẩm', NULL, '2023-09-06', 'admin', N'Công nghiệp');
GO

--SELECT * FROM Folder