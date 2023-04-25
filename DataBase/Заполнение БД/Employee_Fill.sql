USE [BeltelecomDirectory]
GO
DBCC CHECKIDENT (Employees, RESEED, 0);
INSERT INTO [dbo].[Employees]
           ([First_Name]
           ,[Last_Name]
           ,[Unique_Number]
           ,[Position_ID]
           ,[Department_ID]
           ,[Email]
           ,[PhoneNumber])
     VALUES
           ('Дмитрий'
           ,'Горбуков'
           ,'A1001'
           ,1
           ,2
           ,'dmitriygorbukov@gmail.com'
           ,'+375 33 1234567')
GO


