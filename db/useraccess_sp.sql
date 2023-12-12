USE TaiLieuSo
GO
CREATE PROC SelectAllUserAccess
AS
BEGIN
	SELECT u.*, p.TypeName as Name FROM UserAccess u
	LEFT JOIN PatronTypes p
	ON u.patron_type_id = p.PatronTypeID
	
END;

GO
CREATE PROC UpdateUserAccess (@id CHAR(10), @page_read INT, @page_download INT, @display BIT, @read_limit BIT, @read_full BIT, @download BIT)
AS
BEGIN
	UPDATE UserAccess SET page_read = @page_read,
						page_download = @page_download,
						display = @display,
						read_limit = @read_limit,
						read_full = @read_full,
						download = @download
					WHERE patron_type_id = @id

END;

GO
CREATE PROC DeleteUserAccess (@id CHAR(10))
AS
BEGIN
	DELETE UserAccess Where patron_type_id=@id
END;
GO