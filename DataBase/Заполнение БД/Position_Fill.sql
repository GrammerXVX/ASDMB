USE [BeltelecomDirectory]
GO
DBCC CHECKIDENT (Positions, RESEED, 0);
INSERT INTO [dbo].[Positions]
           ([Position_Name]
           ,[Position_Description]
           ,[Unit_ID])
     VALUES
           ('��������� ������������'
           ,'��������� ������������ "�������������-��������� �����" '
           ,1)
GO


