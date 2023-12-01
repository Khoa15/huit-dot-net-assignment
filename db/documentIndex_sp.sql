USE TaiLieuSo
GO
CREATE PROC SelectDocumentIndexByDocId (@docId INT)
AS
BEGIN
	SELECT * FROM DocumentIndex WHERE document_id = @docId ORDER BY parent_index_id ASC;
END;
GO