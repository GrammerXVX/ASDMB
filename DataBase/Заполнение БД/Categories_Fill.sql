USE [BeltelecomDirectory]
GO
DBCC CHECKIDENT (Categories, RESEED, 0);
INSERT INTO [dbo].[Categories]
           ([Category_Type])
     VALUES
           ('��������'),
		   ('�����������'),
		   ('��������� �����'),
		   ('������������ �����'),
		   ('�������� ��������'),
		   ('�������'),
		   ('�������������� ������������'),
		   ('��-����������'),
		   ('���������� ��')
GO
