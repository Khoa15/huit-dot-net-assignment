USE TaiLieuSo
GO
CREATE PROC SelectDocumentIndexByDocId (@docId INT)
AS
BEGIN
	SELECT * FROM DocumentIndex WHERE document_id = @docId ORDER BY parent_index_id ASC;
END;
GO

CREATE PROC InsertDocumentIndex(@document_id INT, @page_number INT, @parent_index_id INT, @author NVARCHAR(255), @title NVARCHAR(255))
AS
BEGIN
	INSERT INTO DocumentIndex
		(document_id, page_number, parent_index_id, author, title)
		VALUES
			(@document_id, @page_number, @parent_index_id, @author, @title)
END;
GO

CREATE PROC UpdateDocumentIndex(@id INT, @document_id INT, @page_number INT, @parent_index_id INT, @author NVARCHAR(255), @title NVARCHAR(255))
AS
BEGIN
	UPDATE DocumentIndex SET
		document_id = @document_id,
        page_number = @page_number,
        parent_index_id = @parent_index_id,
        author = @author,
        title = @title

        WHERE index_id = @id
END;