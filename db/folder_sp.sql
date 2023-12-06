USE TaiLieuSo
GO
CREATE PROC SelectAllFolder
AS
BEGIN
	SELECT * FROM Folder ORDER BY id ASC;
END;
GO

CREATE PROC MoveFolder (@id INT, @desId INT)
AS
BEGIN
	UPDATE Folder SET parent_id = @desId WHERE id = @id;
END;
GO