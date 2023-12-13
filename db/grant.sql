USE TaiLieuSo;
CREATE LOGIN tailieuso WITH PASSWORD = '123';
GO

CREATE USER tailieuso FOR LOGIN tailieuso;
GO
ALTER ROLE db_datareader ADD MEMBER tailieuso;
GO
ALTER ROLE db_datawriter ADD MEMBER tailieuso;
GO
ALTER ROLE db_ddladmin ADD MEMBER tailieuso;

GO
GRANT SELECT, DELETE, UPDATE ON Document TO tailieuso;
GO
GRANT SELECT, DELETE, UPDATE ON DocumentIndex TO tailieuso;
GO
GRANT SELECT, DELETE, UPDATE ON Folder TO tailieuso;
GO
GRANT SELECT, DELETE, UPDATE ON ItemTypes TO tailieuso;
GO
GRANT SELECT, DELETE, UPDATE ON PatronTypes TO tailieuso;
GO
GRANT SELECT, DELETE, UPDATE ON UserAccess TO tailieuso;
GO

CREATE LOGIN nguoidung_tailieuso WITH PASSWORD = '123';
GO

CREATE USER nguoidung_tailieuso FOR LOGIN nguoidung_tailieuso;
GO
ALTER ROLE db_datareader ADD MEMBER nguoidung_tailieuso;
GO

GRANT SELECT ON Document TO nguoidung_tailieuso;
GO
GRANT SELECT ON DocumentIndex TO nguoidung_tailieuso;
GO
GRANT SELECT ON Folder TO nguoidung_tailieuso;
GO
GRANT SELECT ON ItemTypes TO nguoidung_tailieuso;
GO
GRANT SELECT ON PatronTypes TO nguoidung_tailieuso;
GO
GRANT SELECT ON UserAccess TO nguoidung_tailieuso;
