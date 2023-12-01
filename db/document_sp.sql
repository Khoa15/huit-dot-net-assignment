USE TaiLieuSo
GO
CREATE PROC SelectAllDocumentIndexByDocumentId (@docId INT)
AS
BEGIN
	SELECT * FROM DocumentIndex WHERE document_id = @docId ORDER BY parent_index_id ASC;
END;
GO

CREATE PROC SelectAllDocuments
AS
BEGIN
	SELECT * FROM Document;
END;
GO

CREATE PROC SelectAllDocumentsWithAuthorName
AS
BEGIN
	SELECT TOP(1000) Document.*, Author.name FROM Document
	LEFT JOIN Author
	On Author.id = Document.author_id;
END;
GO

CREATE PROC SelectDocumentsByFolderID (@folderID INT)
AS
BEGIN
    SELECT * FROM Document WHERE folder_id = @folderID;
END;
GO


CREATE PROC SelectDocumentsByTitle (@title NVARCHAR(255))
AS
BEGIN
    SELECT * FROM Document WHERE title LIKE '%@title%';
END;
GO

CREATE PROC SelectDocumentsByAuthor (@authorID INT)
AS
BEGIN
    SELECT * FROM Document WHERE author_id = @authorID;
END;
GO

CREATE PROC SelectDocumentIndexByDocument (@docID INT)
AS
BEGIN
	SELECT * FROM DocumentIndex WHERE document_id = @docID;
END;
GO

CREATE PROC SelectDocumentsByDateRange (@startDate DATE, @endDate DATE)
AS
BEGIN
    SELECT * FROM Document WHERE created_date BETWEEN @startDate AND @endDate;
END;
GO

CREATE PROCEDURE SelectDocumentsByDateRangeAndStatus (@startDate DATE, @endDate DATE, @status INT)
AS
BEGIN
    SELECT * FROM Document
    WHERE created_date BETWEEN @startDate AND @endDate
      AND document_status = @status;
END;
GO

CREATE PROC UpdateDocumentStatusToApproved
AS
BEGIN
    UPDATE Document SET document_status = 1 WHERE document_status = 0;
END;
GO

CREATE PROC UpdateDocumentTitle (@documentID INT, @newTitle NVARCHAR(255))
AS
BEGIN
    UPDATE Document SET title = @newTitle WHERE id = @documentID;
END;
GO

CREATE PROC UpdateDocumentStatusToRejected (@documentID INT)
AS
BEGIN
    UPDATE Document SET document_status = 2 WHERE id = @documentID;
END;
GO

CREATE PROC UpdateDocumentTitleAndDescription (@documentID INT, @newTitle NVARCHAR(255), @newDescription NTEXT)
AS
BEGIN
    UPDATE Document SET title = @newTitle, description = @newDescription WHERE id = @documentID;
END;
GO

CREATE PROC DeleteDocumentsInFolder (@folderID INT)
AS
BEGIN
    DELETE FROM Document WHERE folder_id = @folderID;
END;
GO

CREATE PROC DeleteDocument (@documentID INT)
AS
BEGIN
    DELETE FROM Document WHERE id = @documentID;
END;
GO


-- Newest - 01/12/2023
CREATE PROC PublicDocumentByIdFolder (@fid INT)
AS
BEGIN
	UPDATE Document SET document_status = 1 WHERE folder_id = @fid
END;
GO

CREATE PROC PrivateDocumentByIdFolder (@fid INT)
AS
BEGIN
	UPDATE Document SET document_status = 0 WHERE folder_id = @fid
END;
GO

CREATE PROC MoveDocToFolder(@docId INT, @fid INT)
AS
BEGIN
	UPDATE Document SET folder_id = @fid WHERE id = @docId
END;
GO