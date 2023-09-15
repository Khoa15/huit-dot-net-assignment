

USE TaiLieuSo
GO

-- Tạo bảng Folder với liên kết đến chính nó
CREATE TABLE Folder (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    description TEXT,
    created_date DATE,
    created_by VARCHAR(50),
    parent_id INT, -- Thêm liên kết với chính nó
    FOREIGN KEY (parent_id) REFERENCES Folder(id)
);
GO

-- Tạo bảng Document với các thay đổi
CREATE TABLE Document (
    id INT PRIMARY KEY,
    name VARCHAR(255),
    description TEXT,
    file_path VARCHAR(255),
    folder_id INT,
    created_date DATE,
    created_by_user_access_id INT, -- Khóa ngoại tới bảng UserAccess
    link_to_image VARCHAR(255), -- Thêm cột Link ảnh (local hoặc URL)
    document_type VARCHAR(50), -- Loại tài liệu
    document_status INT, -- Trạng thái tài liệu
    author_id INT, -- Khóa ngoại tới bảng Author
    FOREIGN KEY (folder_id) REFERENCES Folder(id),
    --FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id), -- Khóa ngoại tới bảng UserAccess
    --FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

-- Tạo bảng UserAccess với các thay đổi
CREATE TABLE UserAccess (
    id INT PRIMARY KEY,
    policy_id INT,
    document_id INT,
    folder_id INT,
    display INT,
    read_limit INT,
    read_full INT,
    download INT,
    page_read INT,
    page_download INT,
    user_type_id INT, -- Liên kết với bảng UserType
    FOREIGN KEY (document_id) REFERENCES Document(id),
    FOREIGN KEY (folder_id) REFERENCES Folder(id)
);
GO

-- Tạo bảng Author
CREATE TABLE Author (
    id INT PRIMARY KEY,
    author_name VARCHAR(255),
    description TEXT
);
GO

-- Khôi phục lại bảng DocumentIndex
CREATE TABLE DocumentIndex (
    index_id INT PRIMARY KEY,
    title VARCHAR(255),
    document_id INT,
    page_number INT,
    parent_index_id INT, -- Thêm cột parent_index_id làm khóa ngoại
    author_id INT, -- Thêm cột author_id làm khóa ngoại
    FOREIGN KEY (document_id) REFERENCES Document(id),
    FOREIGN KEY (parent_index_id) REFERENCES DocumentIndex(index_id), -- Liên kết với chính nó
    FOREIGN KEY (author_id) REFERENCES Author(id)
);
GO

--FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id), -- Khóa ngoại tới bảng UserAccess
    --FOREIGN KEY (author_id) REFERENCES Author(id)
ALTER TABLE Document ADD FOREIGN KEY (created_by_user_access_id) REFERENCES UserAccess(id)
ALTER TABLE Document ADD FOREIGN KEY (author_id) REFERENCES Author(id)