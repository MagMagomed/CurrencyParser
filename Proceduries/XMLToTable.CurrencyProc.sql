USE [CurrencyRate]
GO
/****** Object:  StoredProcedure [dbo].[XMLToTable]    Script Date: 14.09.2019 0:06:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[XMLToTable]
	@x xml = ''
AS
	INSERT INTO CurrencyRate ([Date], Currency, Rate)
SELECT	   
			CONVERT(datetime, GETDATE(), 104),
			T.c.value('CharCode[1]', 'nvarchar(100)'),
			T.c.value('Value[1]', 'nvarchar(100)')
			
	FROM @x.nodes('//ValCurs/Valute') T(c)
RETURN 0
