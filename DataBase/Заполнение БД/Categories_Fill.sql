USE [BeltelecomDirectory]
GO
DBCC CHECKIDENT (Categories, RESEED, 0);
INSERT INTO [dbo].[Categories]
           ([Category_Type])
     VALUES
           ('Интернет'),
		   ('Телевидение'),
		   ('Мобильная связь'),
		   ('Фиксированая связь'),
		   ('Облачное хранение'),
		   ('Хостинг'),
		   ('Информационная безопасность'),
		   ('ИТ-консалтинг'),
		   ('Разработка ПО')
GO
