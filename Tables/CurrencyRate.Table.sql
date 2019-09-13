USE [CurrencyRate]
GO

/****** Object:  Table [dbo].[CurrencyRate]    Script Date: 14.09.2019 0:04:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CurrencyRate](
	[Date] [date] NOT NULL,
	[Currency] [nvarchar](50) NOT NULL,
	[Rate] [nvarchar](50) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CurrencyRate] ADD  CONSTRAINT [DF_CurrencyRate_Date]  DEFAULT (getdate()) FOR [Date]
GO


