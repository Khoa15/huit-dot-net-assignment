USE TaiLieuSo
GO

CREATE PROC SelectAllItemTypes
AS
BEGIN
	SELECT * FROM ItemTypes
END;
GO

CREATE PROC SelectItemTypeByTypeName (@typeName NVARCHAR(50))
AS
BEGIN
	SELECT * FROM ItemTypes WHERE TypeName = @typeName
END;
GO