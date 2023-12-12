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

CREATE PROC InsertFolder (@name_id NVARCHAR(10), @name NVARCHAR(255), @created_by NVARCHAR(255), @status BIT)
AS
BEGIN
	INSERT INTO Folder (name_id, name, created_by, parent_id, status)
		VALUES
		(@name_id, @name, @created_by, NULL, @status)
END;
GO

CREATE PROC UpdateFolder (@id INT, @name_id NVARCHAR(10), @name NVARCHAR(255), @created_by NVARCHAR(255), @parent_id INT, @status BIT)
AS
BEGIN
	UPDATE Folder SET
		name_id = @name_id,
		name = @name,
		created_by = @created_by,
		parent_id = @parent_id,
		status = @status
		
		WHERE
			id =	@id
END;
GO