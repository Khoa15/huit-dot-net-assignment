USE TaiLieuSo
GO
CREATE PROC SelectAllUserAccess
AS
BEGIN
	SELECT u.*, p.TypeName as Name FROM UserAccess u
	LEFT JOIN PatronTypes p
	ON u.patron_type_id = p.PatronTypeID
	
END;