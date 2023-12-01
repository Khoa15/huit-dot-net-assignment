USE TaiLieuSo
GO
CREATE PROC SelectAllFolder
AS
BEGIN
	SELECT * FROM Folder ORDER BY parent_id ASC;
END;
