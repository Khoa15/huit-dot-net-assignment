USE TaiLieuSo
GO
CREATE PROC SelectAllDocumentIndexByDocumentId (@docId INT)
AS
BEGIN
	SELECT * FROM DocumentIndex WHERE document_id = @docId ORDER BY parent_index_id ASC;
END;
GO

CREATE PROC SelectDocumentsByTitle (@title NVARCHAR(255))
AS
BEGIN
    SELECT * FROM Document WHERE title LIKE '%@title%';
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
	BEGIN TRANSACTION
	BEGIN TRY
		DELETE FROM DocumentIndex WHERE document_id = @documentID;
		DELETE FROM Document WHERE id = @documentID;

		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH

END;
GO

-- Newest - 01/12/2023 - BY KHOA // Using
CREATE PROC SelectAllDocuments
AS
BEGIN
	SELECT Document.*, ItemTypes.*, Folder.id AS fid FROM Document
	LEFT JOIN ItemTypes
	ON Document.ItemTypeID = ItemTypes.ItemTypeID
	LEFT JOIN Folder
	ON Folder.id = Document.folder_id
END;
GO

CREATE PROC SelectDocument(@docId INT)
AS
BEGIN
	SELECT Document.*, ItemTypes.*, Folder.id AS fid FROM Document
	LEFT JOIN ItemTypes
	ON Document.ItemTypeID = ItemTypes.ItemTypeID
	LEFT JOIN Folder
	ON Folder.id = Document.folder_id
	WHERE Document.id = @docId
END;
GO

CREATE PROC SelectDocumentsByFolderId (@fid INT)
AS
BEGIN
	SELECT Document.*, ItemTypes.*, Folder.id AS fid FROM Document
	LEFT JOIN ItemTypes
	ON Document.ItemTypeID = ItemTypes.ItemTypeID
	LEFT JOIN Folder
	ON Folder.id = Document.folder_id
	WHERE folder_id = @fid
END;
GO

CREATE PROC SelectDocumentByStatus (@status BIT)
AS
BEGIN
	SELECT Document.*, ItemTypes.*, Folder.id AS fid FROM Document
	LEFT JOIN ItemTypes
	ON Document.ItemTypeID = ItemTypes.ItemTypeID
	LEFT JOIN Folder
	ON Folder.id = Document.folder_id
	WHERE document_status = @status
END;
GO

CREATE PROC PublicDocumentById(@docId INT)
AS
BEGIN
	UPDATE Document SET document_status = 1 WHERE id = @docId
END;
GO

CREATE PROC PrivateDocumentByid(@docId INT)
AS
BEGIN
	UPDATE Document SET document_status = 0 WHERE id = @docId
END;
GO

CREATE PROC PublicDocumentByIdFolder (@fid INT)
AS
BEGIN
	CREATE TABLE #ParentFolders (id INT);

    INSERT INTO #ParentFolders
    EXEC SelectAllChildFolder @fid;
	
	UPDATE Document SET document_status = 1 WHERE folder_id = @fid OR folder_id IN (SELECT id FROM #ParentFolders)

	DROP TABLE #ParentFolders;
END;
GO

CREATE PROC PrivateDocumentByIdFolder (@fid INT)
AS
BEGIN
	CREATE TABLE #ParentFolders (id INT);

    INSERT INTO #ParentFolders
    EXEC SelectAllChildFolder @fid;
	
	UPDATE Document SET document_status = 0 WHERE folder_id = @fid OR folder_id IN (SELECT id FROM #ParentFolders)

	DROP TABLE #ParentFolders;

END;
GO

CREATE PROC MoveDocToFolder(@docId INT, @fid INT)
AS
BEGIN
	UPDATE Document SET folder_id = @fid WHERE id = @docId
END;
GO


CREATE PROC UpdateDocument(
	@docId INT,
	@title NVARCHAR(255),
	@itemTypeID CHAR(10),
	@author NVARCHAR(255),
	@file_path VARCHAR(255),
	@link_to_image VARCHAR(255),
	@description NTEXT,
	@status BIT,
	@updated_by NVARCHAR(255)
)
AS
BEGIN
	UPDATE Document SET
		ItemTypeID= @itemTypeID,
		file_path= @file_path,
		author = @author,
		title =  @title,
		link_to_image= @link_to_image,
		description =  @description,
		document_status= @status,
		updated_by = @updated_by
	WHERE
		id = @docId
END;
GO

CREATE PROC InsertDocument(
	@fid INT,
	@itemTypeID CHAR(10),
	@file_path VARCHAR(255),
	@author NVARCHAR(255),
	@title NVARCHAR(255),
	@link_to_image VARCHAR(255),
	@description NTEXT,
	@status BIT,
	@updated_by NVARCHAR(255)
)
AS
BEGIN
	INSERT INTO Document
		(folder_id, author, ItemTypeID, file_path, title, link_to_image, description, document_status, updated_by)
	VALUES
		(
			@fid,
			@author,
			@itemTypeID,
			@file_path,
			@title,
			@link_to_image,
			@description,
			@status,
			@updated_by
		)
END;
GO

CREATE PROC PublicAllDocument
AS
BEGIN
	UPDATE Document SET document_status = 1
END;
GO

CREATE PROC PrivateAllDocument
AS
BEGIN
	UPDATE Document SET document_status = 0
END;
GO

CREATE PROC DeleteDocumentsByStatus (@status BIT)
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
		DELETE FROM DocumentIndex WHERE document_id IN (SELECT id FROM Document WHERE document_status = @status)

		DELETE FROM Document WHERE document_status = @status

		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END;
GO

CREATE PROC DeleteAllDocuments 
AS
BEGIN
	BEGIN TRANSACTION
	BEGIN TRY
		DELETE FROM DocumentIndex
		DELETE FROM Document

		COMMIT
	END TRY
	BEGIN CATCH
		ROLLBACK
	END CATCH
END;
GO
